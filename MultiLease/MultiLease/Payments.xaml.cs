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
using System.Data;
using System.Data.SqlClient;



namespace MultiLease
{
    /// <summary>
    /// Interaction logic for Payments.xaml
    /// </summary>
    public partial class Payments : Window
    {

       
        public Payments()
        {
            InitializeComponent();
        }

        private void SubmitPaymentButton_Click(object sender, RoutedEventArgs e)
        {
           

            string connectionString;
            connectionString =
"Data Source=(local);Initial Catalog=MLJPJ;"
+ "Integrated Security=true";
            
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmInsertLease = connection.CreateCommand();

            cmInsertLease.CommandText = "INSERT INTO Payments(DateofPayment,AmountofPayment,PaidLeaseID) VALUES(@Datepay,@Amount,@LeaseID)";
            cmInsertLease.Parameters.AddWithValue("@Datepay", DateBox.Text);
            cmInsertLease.Parameters.AddWithValue("@Amount", AmountBox.Text);
            cmInsertLease.Parameters.AddWithValue("@LeaseID", LeaseIDBox.Text);


            try
            {
                connection.Open();
                cmInsertLease.ExecuteNonQuery();

                MessageBox.Show("Payment Added");
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            finally
            {
                connection.Close();
            }                     
            
            DateBox.Text = "";
            AmountBox.Text = "";
            LeaseIDBox.Text = "";


        }

        private void VoidPaymentBox_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString =
"Data Source=(local);Initial Catalog=MLJPJ;"
+ "Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmVoidPayment = connection.CreateCommand();
            cmVoidPayment.CommandText = "UPDATE Payments SET AmountofPayment = 0 WHERE PaymentID =@PayID ";
            cmVoidPayment.Parameters.AddWithValue("@PayID", PaymentIDBox.Text);

            try
            {
                connection.Open();
                cmVoidPayment.ExecuteNonQuery();

                MessageBox.Show("Payment Voided");
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
            finally
            {
                connection.Close();
            }   


        }
    }
}
