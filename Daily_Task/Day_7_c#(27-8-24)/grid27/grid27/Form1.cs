using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace grid27
{
    public partial class Form1 : Form
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }
        static void GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
            conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
            conn.Open();
            cmd = new SqlCommand("select * from ProductSam", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            GetConnection();
            cmd = new SqlCommand("select * from ProductSam", conn);

            cmd.ExecuteNonQuery();

            SqlDataReader sdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            dataGridView1.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text.ToString();
         
            SqlCommand cmd = new SqlCommand("insert into ProductSam values(@id,@name)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Insert Successfully");
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text.ToString();
            string s1 = "update ProductSam set ProName=@name where ProId=@id";
            SqlCommand cmd = new SqlCommand(s1, conn);
            cmd.Parameters.AddWithValue("@name", name);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Price Updated successfully");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetConnection();
            int id = Convert.ToInt32(textBox1.Text);
            string s = "delete from ProductSam where ProId=@id";
            cmd = new SqlCommand(s, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("One records deleted successfully");
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetConnection();
            string s1 = "select count(*) from ProductSam";
            SqlCommand cmd = new SqlCommand(s1, conn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show( "Total Product:"+result.ToString());
        }
    }
}
