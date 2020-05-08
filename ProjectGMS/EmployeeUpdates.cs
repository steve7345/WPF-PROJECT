using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectGMS
{
    public class EmployeeUpdates
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public System.DateTime StartDate { get; set; }
        public double Salery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        public static DataTable AllEmployees()
        {
            // Method that returns a datatable of all Employees.
            DataTable tbl = new DataTable();

            tbl.Columns.Add("Employee ID", typeof(int));
            tbl.Columns.Add("Employee First Name", typeof(string));
            tbl.Columns.Add("Employee Second Name", typeof(string));
            tbl.Columns.Add("Gender", typeof(string));
            tbl.Columns.Add("Email", typeof(string));
            tbl.Columns.Add("Phone Number", typeof(int));
            tbl.Columns.Add("Start Date", typeof(DateTime));
            tbl.Columns.Add("Salery", typeof(double));

            using (var context = new GymContainer())
            {
                var query = (from Employee in context.Employees
                             select Employee).ToList();

                 //Loop over the customer objects in query and add each piece of data on a header in a row.
                foreach (var employee in query)
                {
                    tbl.Rows.Add(employee.Id, employee.FirstName, employee.SecondName, employee.Gender, employee.Email, employee.PhoneNumber, employee.StartDate, employee.Salery);
                }

            }
            return tbl;


        }
        // Remove an employee from DB
        public static void RemoveEmoployeeByID(int selectedEmployee)
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove employee {selectedEmployee.ToString()}", "Are you sure?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    using (var context = new GymContainer())
                    {
                        try
                        {
                            var employee = context.Employees.Find(selectedEmployee);
                            context.Employees.Remove(employee);
                            context.SaveChanges();
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show($"Exception: {ex}");
                        }
                    }
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Employee Not Removed");
                    break;
            }


        }
    }

}
