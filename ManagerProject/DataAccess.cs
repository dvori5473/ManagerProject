using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerProject
{
    internal class DataAccess
    {
       
        public int InserProduct(string connectionString)
        {
            string product_name;
            int price;
            int category_id ;
            string description;

            Console.WriteLine("enter name of product");
            product_name = Console.ReadLine();
            
            Console.WriteLine("enter price of product");
            price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter category_id of product");
            category_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter description of product");
            description = Console.ReadLine();

            string query = "INSERT INTO PRODUCTS( PRODUCT_NAME,PRICE,CATEGORY_ID,DESCRIPTION)" + "VALUES(@product_name,@price,@category_id,@description)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using(SqlCommand cmd=new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@product_name", SqlDbType.NChar, 50).Value = product_name;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = category_id;
                cmd.Parameters.Add("@description", SqlDbType.NChar, 50).Value = description;


                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowAffected;
            }
         }
        public int InserCategory(string connectionString)
        {   
 
            string category_name;

            Console.WriteLine("enter name of category");
            category_name = Console.ReadLine();

            string query = "INSERT INTO CATEGORIES(CATEGORY_NAME)" + "VALUES(@category_name)";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
               
                cmd.Parameters.Add("@category_name", SqlDbType.NChar, 50).Value = category_name;

                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowAffected;
            }
        }
        public void ReadProduct(string connectionString)
        {

            string query = "select * from PRODUCTS";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = comd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                       
                    } 
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void ReadCategory(string connectionString)
        {

            string query = "select * from CATEGORIES";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand comd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = comd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void InserItem(string connectionString)
        {
            string letter;
            string toContinue = "y";
            while (toContinue == "y") 
            {

                Console.WriteLine("enter c to insert category or enter p to insert product");
                letter = Console.ReadLine();
                if (letter == "p")
                    InserProduct(connectionString);
                else
                {
                    if (letter == "c")
                        InserCategory(connectionString);
                }

                Console.WriteLine("if you want to continue pres (y/n)");
                toContinue = Console.ReadLine();
            }
            Console.WriteLine("categories");
            ReadCategory(connectionString);
            Console.WriteLine("product");
            ReadProduct(connectionString);
            Console.ReadLine();
        }

    }
}
