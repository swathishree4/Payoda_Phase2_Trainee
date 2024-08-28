using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Project
{
    public partial class Form4 : Form
    {

        static SqlConnection conn;
        static SqlCommand cmd;
        public Form4()
        {
            InitializeComponent();
        }
        static void GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=VehicleRentalDB;integrated security=true;");
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();


            int rentalID = Convert.ToInt32(textBox1.Text);
            int customerID = Convert.ToInt32(textBox2.Text);
            int vehicleID = Convert.ToInt32(textBox3.Text);
            DateTime rentalDate = dateTimePickerRentalDate.Value;
            DateTime returnDate = dateTimePickerReturnDate.Value;
            decimal totalAmount = Convert.ToDecimal(textBox6.Text);


            string query = "INSERT INTO Rentals_a (RentalID, CustomerID, VehicleID, RentalDate, ReturnDate, TotalAmount) " +
                           "VALUES (@rentalID, @customerID, @vehicleID, @rentalDate, @returnDate, @totalAmount)";

            SqlCommand cmd = new SqlCommand(query, conn);


            cmd.Parameters.AddWithValue("@rentalID", rentalID);
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@rentalDate", rentalDate);
            cmd.Parameters.AddWithValue("@returnDate", returnDate);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);


            cmd.ExecuteNonQuery();


            MessageBox.Show("Rental inserted successfully");


            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConnection();


            int rentalID = Convert.ToInt32(textBox1.Text);
            int customerID = Convert.ToInt32(textBox2.Text);
            int vehicleID = Convert.ToInt32(textBox3.Text);
            DateTime rentalDate = dateTimePickerRentalDate.Value;
            DateTime returnDate = dateTimePickerReturnDate.Value;
            decimal totalAmount = Convert.ToDecimal(textBox6.Text);

            string query = "UPDATE Rentals_a SET CustomerID = @customerID, VehicleID = @vehicleID, RentalDate = @rentalDate, " +
                           "ReturnDate = @returnDate, TotalAmount = @totalAmount WHERE RentalID = @rentalID";

            SqlCommand cmd = new SqlCommand(query, conn);


            cmd.Parameters.AddWithValue("@rentalID", rentalID);
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@rentalDate", rentalDate);
            cmd.Parameters.AddWithValue("@returnDate", returnDate);
            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);


            cmd.ExecuteNonQuery();


            MessageBox.Show("Rental updated successfully");


            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            GetConnection();


            int rentalID = Convert.ToInt32(textBox1.Text);


            string query = "DELETE FROM Rentals_a WHERE RentalID = @rentalID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@rentalID", rentalID);


            cmd.ExecuteNonQuery();


            MessageBox.Show("Rental deleted successfully");


            conn.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from Rentals_a", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from Rentals_a", conn);

            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
            MessageBox.Show("Displaying your details");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetConnection();

           
            string searchKeyword = textBox4.Text.Trim();

           
            string query = "SELECT * FROM Rentals_a WHERE " +
                           "CONVERT(VARCHAR, RentalID) LIKE @search OR " +
                           "CONVERT(VARCHAR, CustomerID) LIKE @search OR " +
                           "CONVERT(VARCHAR, VehicleID) LIKE @search";

          
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

           
            SqlDataReader sdr = cmd.ExecuteReader();

          
            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;

           
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Search results displayed successfully!");
            }
            else
            {
                MessageBox.Show("No records found for the given search keyword.");
            }

            sdr.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); // Create an instance of Form2
            form5.Show();
        }
    }
}
