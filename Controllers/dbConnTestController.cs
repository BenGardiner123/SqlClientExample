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

            string queryString = "DELETE FROM Customers WHERE Id = @ID";

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

        [HttpDelete("Delete/{id}")]
        public string DeleteYoSelf(string Id){

            var connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;Initial Catalog=SampleDB;User ID=admin;Password=abcd1234";
            SqlConnection conn = new SqlConnection(connectionString);

            string thisIsMuhQuery = "Delete from Customer where Id = @ID";
            SqlCommand command = new SqlCommand(thisIsMuhQuery, conn);

            command.Parameters.AddWithValue("@ID", int.Parse(Id));

            conn.Open();
            try
            {
                var result = command.;
                return result.ToString();
            }
            catch (SqlException sqlex)
            {
                return "Some kind of issue was located in an area nearby - unable to do that" + sqlex;
            }
        }

        [HttpGet("Customers/{country}")]
        public string GroupCustomers(string country){

            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;Initial Catalog=SampleDB;User ID=admin;Password=abcd1234";
            SqlConnection conn = new SqlConnection(connectionString);

            string thisIsMuhQuery = "Delete form Customer where ID = @ID";
            SqlCommand command = new SqlCommand(thisIsMuhQuery, conn);

            command.Parameters.AddWithValue("@ID", int.Parse(country));

            conn.Open();
            try
            {
                var result = command.BeginExecuteNonQuery();
                return result.ToString();
            }
            catch (SqlException sqlex)
            {
                return "Some kind of issue was located in an area nearby - unable to do that" + sqlex;
            }
        }


    }
}
