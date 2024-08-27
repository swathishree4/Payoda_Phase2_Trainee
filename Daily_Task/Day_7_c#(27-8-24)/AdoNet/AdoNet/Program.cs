//// See https://aka.ms/new-console-template for more information
//
//
//
////static void create()
////{
////    Console.WriteLine("Hello, World!");
////    SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
////    conn.Open();
////    SqlCommand cmd = new SqlCommand("create table ProductSam(ProId int primary key,ProName varchar(30))", conn);
////    cmd.ExecuteNonQuery();
////    Console.WriteLine("Table created successfully");
////    conn.Close();
////}
//



using System;
using System.Data.SqlClient;

namespace MyApp
{
    internal class Program
    {
        static SqlConnection conn;
        static SqlCommand cmd;

        static void Main(string[] args)
        {
            
            bool res = true;

            while (res)
            {
                Console.WriteLine("Enter the process to be executed:\n1. FETCH\n2. INSERT\n3. UPDATE\n4. DELETE");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt == 1)
                {
                    Fetch();
                }
                else if (opt == 2)
                {
                    Console.WriteLine("How many products do you want to insert?");
                    int numberOfProducts = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < numberOfProducts; i++)
                    {
                        Insert();
                    }
                }
                else if (opt == 3)
                {
                    Console.WriteLine("How many products need to be updated?");
                    int update_product = Convert.ToInt32(Console.ReadLine());
                    for (int j = 0; j < update_product; j++)
                    {
                        Update();
                    }
                }
                else if (opt == 4)
                {
                    Console.WriteLine("Enter the how many records to be deleted:");
                    int del_id=Convert.ToInt32(Console.ReadLine());
                    for(int k = 0; k < del_id; k++)
                    {
                        Delete();
                    }
                    
                }
                Console.WriteLine("Do you want to continue (true or false)?");
                res = Convert.ToBoolean(Console.ReadLine());
                
            }
        }

        static void GetConnection()
        {
            conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
            conn.Open();
        }

        static void Fetch()
        {
            GetConnection();
            cmd = new SqlCommand("select * from ProductSam", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine($"{sdr[0]} {sdr[1]}");
            }

            conn.Close();
        }

        static void Insert()
        {
            GetConnection();
            Console.WriteLine("Enter the product id and product name:");
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();

            cmd = new SqlCommand("insert into ProductSam values(@id, @name)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Record Inserted");
            conn.Close();
        }

        static void Update()
        {
            GetConnection();
            Console.WriteLine("Enter the product name and id to be updated");
            
            string name = Console.ReadLine();
            int id= Convert.ToInt32(Console.ReadLine());    
            cmd = new SqlCommand("update ProductSam set ProName=@name where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Record Updated");
            conn.Close();
        }

        static void Delete()
        {
            GetConnection();
            Console.WriteLine("Enter the product id to be deleted");

         
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from ProductSam where ProId=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
         
            cmd.ExecuteNonQuery();

            Console.WriteLine("Record Deleted");
            conn.Close();
        }

    }
}
