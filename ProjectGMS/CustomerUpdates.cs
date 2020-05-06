using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual Employee Employee { get; set; }
    }

    [Obsolete]
    public static void AddCust(string FName, string LName)
    {
            SqlConnection sql = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\DATABASES\MULTIHIREDB.MDF;");
            sql.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Customer (FirstName, LastName) VALUES (@FirstName, @LastName, @dailyRate)", sql);
            sqlCommand.Parameters.Add("@FirstName", FName);
            sqlCommand.Parameters.Add("@SecondName", LName);
            sqlCommand.ExecuteNonQuery();
        
    }
}
