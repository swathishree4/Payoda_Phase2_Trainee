// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Data.SqlTypes;
Fetch();
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
static void Fetch()
{
    SqlConnection conn = new SqlConnection("data source=PTSQLTESTDB01;database=SAMPLE;integrated security=true;");
    conn.Open();
    SqlCommand cmd = new SqlCommand("select * from ProductSam", conn);
    SqlDataReader sdr = cmd.ExecuteReader();
    while(sdr.Read())
    {
        Console.WriteLine(sdr[0].ToString() + sdr[1].ToString());

    }
    
    Console.WriteLine("Table created successfully");
    conn.Close();
}