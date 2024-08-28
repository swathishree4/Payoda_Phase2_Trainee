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
    public partial class Form3 : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public Form3()
        {
            InitializeComponent();
        }
        static void GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=VehicleRentalDB;integrated security=true;");
            conn.Open();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from Vehicles_a", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string make = textBox2.Text.ToString();

            string model = textBox3.Text.ToString();
            int year = Convert.ToInt32(textBox4.Text); ;
            decimal RatePerDay = Convert.ToDecimal(textBox5.Text);

            cmd = new SqlCommand("insert into Vehicles_a values(@id,@make,@model,@year,@rateperyear)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@rateperyear", RatePerDay);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string make = textBox2.Text.ToString();

            string model = textBox3.Text.ToString();
            int year = Convert.ToInt32(textBox4.Text); ;
            decimal RatePerDay = Convert.ToDecimal(textBox5.Text);
            SqlCommand cmd = new SqlCommand("UPDATE   Vehicles_a SET make=@make, model=@model,year=@year,RatePerDay=RatePerDay WHERE VehicleID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@make", make);
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@RatePerDay", RatePerDay);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string s = "delete  from  Vehicles_a where VehicleID=@id";
            cmd = new SqlCommand(s, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("One records deleted successfully");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from Vehicles_a", conn);

            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
            MessageBox.Show("Displaying your details");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(); // Create an instance of Form2
            form4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            GetConnection();

           
            //string searchKeyword = textBox6.Text.Trim();

           
            //string query = "SELECT * FROM Vehicles_a WHERE Make LIKE @search OR Model LIKE @search OR CAST(Year AS NVARCHAR) LIKE @search OR CAST(RatePerDay AS NVARCHAR) LIKE @search";


            //cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");


            //SqlDataReader sdr = cmd.ExecuteReader();


            //DataTable dt = new DataTable();
            //dt.Load(sdr);


            //dataGridView1.DataSource = dt;


            //conn.Close();


            //MessageBox.Show("Search completed!");


            

        }
    }
}
