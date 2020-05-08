using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace ProjectGMS
{
    public class CustomerUpdates
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int MembershipInMonths { get; set; }
        public System.DateTime StartDate { get; set; }
        public int EmployeeId { get; set; }

        //public virtual Employee Employee { get; set; }

        public static DataTable AllCustomers()
        {
            // Method that returns a datatable of all customers.
            DataTable tbl = new DataTable();

            tbl.Columns.Add("Customer ID", typeof(int));
            tbl.Columns.Add("Customer First Name", typeof(string));
            tbl.Columns.Add("Customer Second Name", typeof(string));
            tbl.Columns.Add("Gender", typeof(string));
            tbl.Columns.Add("Email", typeof(string));
            tbl.Columns.Add("Phone Number", typeof(int));
            tbl.Columns.Add("membership", typeof(int));
            tbl.Columns.Add("Start Date", typeof(DateTime));
            tbl.Columns.Add("Employee ID", typeof(int));

            using (var context = new GymContainer())
            {
                var query = (from customer in context.Customers
                             select customer).ToList();

                // Loop over the customer objects in query and add each piece of data on a header in a row.
                foreach (var customer in query)
                {
                    tbl.Rows.Add(customer.Id, customer.FirstName, customer.SecondName, customer.Gender, customer.Email, customer.PhoneNumber, customer.MembershipInMonths, customer.StartDate, customer.EmployeeId);
                }

            }
            return tbl;


        }
        // Remove an `customer from DB
        public static void RemoveEmoployeeByID(int selectedCustomer)
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove customer {selectedCustomer.ToString()}", "Are you sure?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    using (var context = new GymContainer())
                    {
                        try
                        {
                            var customer = context.Customers.Find(selectedCustomer);
                            context.Customers.Remove(customer);
                            context.SaveChanges();
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show($"Exception: {ex}");
                        }
                    }
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Customer Not Remove");
                    break;
            }


        }
    }

    
}
