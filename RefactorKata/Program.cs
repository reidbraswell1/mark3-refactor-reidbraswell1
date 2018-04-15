using System;
using System.Collections.Generic;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SQL_COMMAND_TEXT = "select * from Products";
            const string SERVER_INFO = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;";

            List<Product> products = new List<Product>();

            using (var conn = new System.Data.SqlClient.SqlConnection(SERVER_INFO))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = SQL_COMMAND_TEXT;   
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var prod = new Product();
                    prod.Name = reader["Name"].ToString();
                    products.Add(prod);
                }//while//
            }//using//
            Console.WriteLine("Products Loaded!");
            for (int i =0; i< products.Count; i++)
            {
                Console.WriteLine(products[i].Name);
            }//for//
        }//Main//
    }//Program//
    public class Product
    {
        public string Name { get;   set; } 
    }//Product//
}//RefactorKata//
