using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlClientExample.Models;

namespace SqlClientExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class dbConnTestController: ControllerBase
    {
      
        [HttpGet]
        
        public List<Customer> TestConnection(){

            List<Customer> customers = new List<Customer>();

            // Connect to an SQL Server Database
            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;Initial Catalog=SampleDB;User ID=admin;Password=abcd1234";
            SqlConnection conn = new SqlConnection(connectionString);

            string queryString = "Select * From Customer";

            SqlCommand command = new SqlCommand( queryString, conn);
            conn.Open();
        
            string result = "";
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + "\n";
                    
                    // ORM - Object Relation Mapping
                    customers.Add(
                        new Customer() { Id = (int)reader[0], Firstname = reader[1].ToString(), Surname = reader[2].ToString()});                
                }
            }

            return customers;
            
        }

     /*    [Route ("SupplierList")]
        [HttpGet]
        public string TestConnection(){

            List <Customer> customers = new List<Customer>();

            // Connect to an SQL Server Database
            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;Initial Catalog=SampleDB;User ID=admin;Password=abcd1234";
            SqlConnection conn = new SqlConnection(connectionString);

            string queryString = "Select companyname from company, join Product.UnitPrice where product.id = Supplier.ID ";

            SqlCommand command = new SqlCommand( queryString, conn);
            conn.Open();
        
            string result = "";
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result += reader[0] + " | " + reader[1] + reader[2] + "\n";
                    
                    // ORM - Object Relation Mapping
                    customers.Add(
                        new Customer() { Name = (int)reader[0], Price = reader[1].ToString(),  = reader[2].ToString()});                
                }
            }

            return customers;
            
        } */

       
    }
}
