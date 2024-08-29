using MVCADO.Models;
using System.Data.SqlClient;

namespace MVCADO.Dataacess
{
    public class Productdataacess
    {
        static SqlConnection conn;
        static SqlCommand cmd;

                

        static void GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
            conn.Open();
        }
        //static void create()
        //{
        //    Console.WriteLine("Hello, World!");
        //    SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("create table ProductSam(ProId int primary key,ProName varchar(30))", conn);
        //    cmd.ExecuteNonQuery();
        //    Console.WriteLine("Table created successfully");
        //    conn.Close();
        //}
        public List<Product> Fetch()
        {
            List<Product> li = new List<Product>();
            GetConnection();
            cmd = new SqlCommand("select * from ProductSam", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                //Console.WriteLine($"{sdr[0]} {sdr[1]}");
               li.Add(new Product() { id = Convert.ToInt32(sdr[0].ToString()), name = sdr[1].ToString()});
            }

            conn.Close();
            return li;
        }
        public Product Search(int id)
        {
            //List<Product> li = new List<Product>(int? id);
            GetConnection();
            cmd = new SqlCommand("select * from ProductSam where ProId= @id", conn);
            
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            Product p =new Product();
            while (sdr.Read())
            {
                //Console.WriteLine($"{sdr[0]} {sdr[1]}");
                p.id = Convert.ToInt32(sdr[0].ToString());
                p.name = sdr[1].ToString() ;
            }

            conn.Close();
            return p;
        }

        public void Insert(Product p)
        {
            GetConnection();
            //Console.WriteLine("Enter the product id and product name:");
            //int id = Convert.ToInt32(Console.ReadLine());
            //string name = Console.ReadLine();
        
            cmd = new SqlCommand("insert into ProductSam values(@id, @name)", conn);
            cmd.Parameters.AddWithValue("@id",p.id);
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.ExecuteNonQuery();

            //Console.WriteLine("Record Inserted");
            conn.Close();
        }

        public void Update(Product p)
        {
            GetConnection();
            //Console.WriteLine("Enter the product name and id to be updated");

            //string name = Console.ReadLine();
            //int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("update ProductSam set ProName=@name where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", p.id);
            cmd.Parameters.AddWithValue("@name",p. name);
            cmd.ExecuteNonQuery();

            //Console.WriteLine("Record Updated");
            conn.Close();
        }

                public void Delete(int id,Product p)
        {
            GetConnection();
            //Console.WriteLine("Enter the product id to be deleted");


            //int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from ProductSam where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Console.WriteLine("Record Deleted");
            conn.Close();
        }

    }
}
