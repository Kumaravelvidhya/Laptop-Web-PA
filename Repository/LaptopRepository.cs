using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace MVC.Repository
{
    public class LaptopRepository
    {
        public readonly string connectionString;
        public LaptopRepository()
        {
            connectionString = @"Data source=ANIYAAN-1006;Initial catalog=Laptop;User Id=Anaiyaan; Password=Anaiyaan@123";
        }
        public void Insert(LaptopModels data)
        {
            try
            {
                SqlConnection objlap = new SqlConnection(connectionString);
                objlap.Open();
                objlap.Execute($"exec insertlaptop'{data.Name}','{data.Email}','{data.Message}'");
                objlap.Close();
            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<LaptopModels> Select()

        {
            try
            {
                List<LaptopModels> LaptopModelsa = new List<LaptopModels>();

                var connection = new SqlConnection(connectionString);
                connection.Open();
                LaptopModelsa = connection.Query<LaptopModels>("exec selectlaptop", connectionString).ToList();
                connection.Close();



                return LaptopModelsa;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
