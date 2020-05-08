using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace ProjectGMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GymContainer db = new GymContainer();
        

        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void Btn_AddNewCustomer_Click_1(object sender, RoutedEventArgs e)
        {
            
           
            Customer c1 = new Customer();
            
            c1.FirstName = tbx_AddFirstName.Text;
            c1.SecondName = tbx_AddSecondName.Text;
            c1.Gender = tbx_AddGender.Text;
            c1.Email = tbx_AddEmail.Text;
            c1.PhoneNumber = int.Parse(tbx_AddPhoneNumber.Text);
            c1.MembershipInMonths = int.Parse(tbx_AddMembership.Text);
            c1.StartDate = DateTime.Now;
            c1.EmployeeId = int.Parse(tbx_AddEmployeeId.Text);
                db.Customers.Add(c1);
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c;
            var customers = query.ToList();
            dagCustomer.ItemsSource = customers;
            

        }


        //method used to delete a cunstomer from the database by entering customer ID
        private void Btn_deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            int selectedCustomer = 0;
            try
            {
                int.TryParse(Tbx_SelectedCustomer.Text, out selectedCustomer);
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"Invalid Input Exception: {ex}");
            }
            CustomerUpdates.RemoveEmoployeeByID(selectedCustomer);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Employees
                        select c;
            var employees = query.ToList();
            dagEmployee.ItemsSource = employees;
        }

        private void Btn_AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee e1 = new Employee();

            e1.FirstName = tbx_AddFirstName.Text;
            e1.SecondName = tbx_AddSecondName.Text;
            e1.Gender = tbx_AddGender.Text;
            e1.Email = tbx_AddEmail.Text;
            e1.PhoneNumber = int.Parse(tbx_AddPhoneNumber.Text);
            e1.StartDate = DateTime.Now;
            e1.Salery = double.Parse(tbx_AddSalery.Text);
            db.Employees.Add(e1);
            db.SaveChanges();
            
        }

        private void DagEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //delete employee by entering ID
        private void Btn_deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            int selectedEmployee = 0;
            try
            {
                int.TryParse(Tbx_SelectedEmployee.Text, out selectedEmployee);
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"Invalid Input Exception: {ex}");
            }
            EmployeeUpdates.RemoveEmoployeeByID(selectedEmployee);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //shows how much membership customers have
        private void BtnGetMembership_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        orderby c.MembershipInMonths descending
                        select new { Firstname = c.FirstName, Secondname = c.SecondName, MembershipInMonths = c.MembershipInMonths };
            var customers = query.ToList();
            Dta_HowManyMonthsLeft.ItemsSource = customers;
        }


        //show employees salerys
        private void BtnGetSalerys_Click(object sender, RoutedEventArgs e)
        {
            var query = from f in db.Employees
                        orderby f.Salery descending
                        select new { Firstname = f.FirstName, Secondname = f.SecondName, Salery = f.Salery };
            var employees = query.ToList();
            Dta_Salerys.ItemsSource = employees;
        }

        private void Btn_GetCustomerWithTrainer_Click(object sender, RoutedEventArgs e)
        {
            var query = from g in db.Employees
                        from h in db.Customers
                        where Customer 
                        orderby h.FirstName ascending
                        select new { Firstname = h.FirstName, Secondname = h.SecondName, h.EmployeeId, g.Id };
            var results = query.ToList();
            Dta_GetCustomerWithTrainer.ItemsSource = results;
        }
    }
}
