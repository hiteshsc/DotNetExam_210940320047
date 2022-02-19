using _210940320047.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _210940320047.Dao
{
    public class ProductsDao
    {
        SqlConnection cn;
        
        private SqlCommand generateCommand(String procedureName)
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            cn.Open();
            return new SqlCommand {
                Connection = cn,
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = procedureName
            };
        }

        public List<Product> FetchAll()
        {
            List<Product> list = new List<Product>();
            try
            {
                SqlDataReader dr = generateCommand("SelectProducts").ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)dr["ProductId"],
                        ProductName = (string)dr["ProductName"],
                        Description = (string)dr["Description"],
                        CategoryName = (string)dr["CategoryName"],
                        Rate = (decimal)dr["Rate"]
                    });
                }
                dr.Close();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        internal void Update(Product p)
        {
            SqlCommand cmd = generateCommand("UpdateProduct");
            cmd.Parameters.AddWithValue("@ProductId", p.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
            cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);
            cmd.Parameters.AddWithValue("@Rate", p.Rate);
            cmd.Parameters.AddWithValue("@Description", p.Description);

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        internal Product getProductById(int id)
        {
            SqlCommand cmd = generateCommand("SelectSingalProduct");
            cmd.Parameters.AddWithValue("@ProductId", id);
            Product p = null; 

            try
            {
               
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    p = new Product
                        {
                            ProductId = (int)dr["ProductId"],
                            ProductName = (string)dr["ProductName"],
                            Description = (string)dr["Description"],
                            CategoryName = (string)dr["CategoryName"],
                            Rate = (decimal)dr["Rate"]
                        };
                }
                dr.Close();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    
    }
}