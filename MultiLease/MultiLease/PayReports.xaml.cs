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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for PayReports.xaml
    /// </summary>
    public partial class PayReports : Window
    {
        public PayReports()
        {
            InitializeComponent();

            FillGridData();
        }               

        public void FillGridData()
        {
            string connectionString;
            connectionString =
"Data Source=(local);Initial Catalog=MLJPJ;"
+ "Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "select * from vwPayments";
                SqlCommand comm = new SqlCommand(queryString,connection);
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                DataTable dt = new DataTable("vwPayments");
                sda.Fill(dt);
                datagrid111.ItemsSource = dt.DefaultView;
                
            }


        }


    }
}
