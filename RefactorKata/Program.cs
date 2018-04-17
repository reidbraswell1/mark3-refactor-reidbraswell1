using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SqlCommandText = "select * from Products";
            const string ConnectionString = "Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;";

            List<Product> products = new List<Product>();

            using (var conn = new SqlConnection(ConnectionString))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = SqlCommandText;   
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
