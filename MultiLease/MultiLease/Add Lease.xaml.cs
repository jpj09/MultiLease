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

namespace MultiLease
{
    /// <summary>
    /// Interaction logic for Add_Lease.xaml
    /// </summary>
    public partial class Add_Lease : Window
    {
        public Add_Lease()
        {
            InitializeComponent();

            

        }

        string DateBegin, FirstPay, AmountPay, NumbPay, stVehiculeLeased, CustLeasing, stLeaseTerms;
        string LeaseIdST;


        private void DateLeaseBeginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           DateBegin = DateLeaseBeginBox.Text;
        }
       
        private void FirstPaymentDueBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           FirstPay = FirstPaymentDueBox.Text;
        }

        private void AmountMonthPayBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           AmountPay = AmountMonthPayBox.Text;
        }

        private void NumbMonthlyPayBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           NumbPay = NumbMonthlyPayBox.Text;
        }

        private void VehicleLeasedBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          stVehiculeLeased = VehicleLeasedBox.Text;
        }

        private void CustLeasingBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           CustLeasing = CustLeasingBox.Text;
        }

        private void LeaseTermsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           stLeaseTerms = LeaseTermsBox.Text;
        }

        private void SubmitAddLease_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
                connectionString =
    "Data Source=(local);Initial Catalog=MLJPJ;"
    + "Integrated Security=true";          

            SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmInsertLease = connection.CreateCommand();

            
            cmInsertLease.CommandText = "INSERT INTO Leases(DateBegins ,FirstPaymentDue ,AmountMonthlyPay ,NumberOfMonthlyPay,VehiculeLeased ,CustumerLeasing,LeaseTerms) VALUES(@DateBegins,@DateFirstPay,@MonthlyPay ,@NumbMonthlyPay ,@VehiculeLeased ,@CustLeasing ,@LeaseTerms)";
            cmInsertLease.Parameters.AddWithValue("@DateBegins", DateBegin);
            cmInsertLease.Parameters.AddWithValue("@DateFirstPay", FirstPay);
            cmInsertLease.Parameters.AddWithValue("@MonthlyPay", AmountPay);
            cmInsertLease.Parameters.AddWithValue("@NumbMonthlyPay", NumbPay);
            cmInsertLease.Parameters.AddWithValue("@VehiculeLeased", stVehiculeLeased);
            cmInsertLease.Parameters.AddWithValue("@CustLeasing", CustLeasing);
            cmInsertLease.Parameters.AddWithValue("@LeaseTerms", stLeaseTerms);

            connection.Open();
            cmInsertLease.ExecuteNonQuery();
            connection.Close();

        }

        private void UpdateLease_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            connectionString =
"Data Source=(local);Initial Catalog=MLJPJ;"
+ "Integrated Security=true";

            SqlConnection connection = new SqlConnection(connectionString); 
            SqlCommand cmUpdateLease = connection.CreateCommand();

            try
            {
                cmUpdateLease.CommandText = "UPDATE Leases SET DateBegins = @DateBegins,FirstPaymentDue=@DateFirstPay,AmountMonthlyPay=@MonthlyPay,NumberOfMonthlyPay=@NumbMonthlyPay,VehiculeLeased=@VehiculeLeased,CustumerLeasing=@CustLeasing,LeaseTerms=@LeaseTerms WHERE LeaseID = @LeaseID ";
                cmUpdateLease.Parameters.AddWithValue("@DateBegins", DateBegin);
                cmUpdateLease.Parameters.AddWithValue("@DateFirstPay", FirstPay);
                cmUpdateLease.Parameters.AddWithValue("@MonthlyPay", AmountPay);
                cmUpdateLease.Parameters.AddWithValue("@NumbMonthlyPay", NumbPay);
                cmUpdateLease.Parameters.AddWithValue("@VehiculeLeased", stVehiculeLeased);
                cmUpdateLease.Parameters.AddWithValue("@CustLeasing", CustLeasing);
                cmUpdateLease.Parameters.AddWithValue("@LeaseTerms", stLeaseTerms);
                cmUpdateLease.Parameters.AddWithValue("@LeaseID", LeaseIdST);

                connection.Open();
                cmUpdateLease.ExecuteNonQuery();


                MessageBox.Show("You updated successfuly the lease");
            }

            catch
            {
                MessageBox.Show("Something went wrong! Try Again");
            }
            finally
            {
                connection.Close();
            }


        }

        private void LeaseIDBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LeaseIdST = LeaseIDBox.Text;
        }


        
      
    }
}
