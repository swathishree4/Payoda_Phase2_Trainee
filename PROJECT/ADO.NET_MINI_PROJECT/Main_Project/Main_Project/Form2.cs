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

    public partial class Form2 : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public Form2()
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
            int id = Convert.ToInt32(textBoxcust_id.Text);
            string name = textBoxcust_name.Text.ToString();

            string phno = textBox_phno.Text.ToString();
            string email = textBox_email.Text.ToString();

            SqlCommand cmd = new SqlCommand("insert into Customers_a values(@id,@name,@email,@phno)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phno", phno);
            cmd.Parameters.AddWithValue("@email", email);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBoxcust_id.Text);
            string name = textBoxcust_name.Text.ToString();

            string phno = textBox_phno.Text.ToString();
            string email = textBox_email.Text.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE Customers_a SET Name=@Name, Email=@Email, PhoneNumber=@PhoneNumber WHERE CustomerID=@CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PhoneNumber", phno);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //display
            GetConnection();
            cmd = new SqlCommand("select * from Customers_a", conn);

            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
            MessageBox.Show("Displaying your details");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            GetConnection();
            int id = Convert.ToInt32(textBoxcust_id.Text);
            string s = "delete  from Customers_a  where CustomerID=@id";
            cmd = new SqlCommand(s, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("One records deleted successfully");
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from Customers_a", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // Create an instance of Form2
            form3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetConnection();

           
            string searchKeyword = textBoxsearch.Text.Trim();

           
            string query = "SELECT * FROM Customers_a WHERE Name LIKE @search OR PhoneNumber LIKE @search OR Email LIKE @search";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

           
            SqlDataReader sdr = cmd.ExecuteReader();

           
            DataTable dt = new DataTable();
            dt.Load(sdr);

           
            dataGridView1.DataSource = dt;

           
            conn.Close();

          
            MessageBox.Show("Search completed!");
        }
    }
}
