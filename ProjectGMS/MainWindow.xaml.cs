using System;
using System.Collections.Generic;
using System.Linq;
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
            string FirstName = tbx_AddFirstName.Text.ToString();
            string SecondName = tbx_AddSecondName.Text.ToString();
            //DataAccessLayer.newHireAsset(hireName, hireType, hireDailyRate);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c;
            var customers = query.ToList();
            dagCustomer.ItemsSource = customers;
                       
        }

      
    }
}
