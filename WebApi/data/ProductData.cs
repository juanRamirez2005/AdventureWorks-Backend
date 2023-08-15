using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using WebApi.data;
using WebApi.models;

namespace WebApi.data

{
    public class ProductData
    {
        public static List<ProductCategory> ListProducts()
        {
            List<ProductCategory> oProductList = new List<ProductCategory>();
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM SalesLT.ProductCategory", oConexion))
                {
                    try
                    {
                        oConexion.Open();
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProductList.Add(new ProductCategory()
                                {
                                    ProductCategoryID = Convert.ToInt32(dr["ProductCategoryID"]),
                                    ParentProductCategotyID = dr["ParentProductCategoryID"].ToString(),
                                    Name = dr["Name"].ToString()
                                });
                            }
                        }
                        return oProductList;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return oProductList;
                    }
                }
            }
        }

        public static List<ProductCategory> ProductCategoryID(string productID)
        {
            List<ProductCategory> oProductList = new List<ProductCategory>();
            using (SqlConnection oConexion = new SqlConnection(Connection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM SalesLT.ProductCategory WHERE ParentProductCategoryID = {productID}", oConexion))
                {
                    try
                    {
                        oConexion.Open();
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProductList.Add(new ProductCategory()
                                {
                                    ProductCategoryID = Convert.ToInt32(dr["ProductCategoryID"]),
                                    ParentProductCategotyID = dr["ParentProductCategoryID"].ToString(),
                                    Name = dr["Name"].ToString()
                                });
                            }
                        }
                        return oProductList;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return oProductList;
                    }
                }
            }
        }

        public static List<Product> ProductByID(int productID)
        {
            List<Product> oProductList = new List<Product>();
            using (SqlConnection oConnection = new SqlConnection(Connection.connectionString))
            {
                using(SqlCommand cmd = new SqlCommand($"SELECT * FROM SalesLT.Product WHERE ProductCategoryID = {productID}", oConnection))
                {
                    try 
                    {
                        oConnection.Open();
                        cmd.ExecuteNonQuery();
                        using(SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oProductList.Add(new Product()
                                {
                                    ProductID = Convert.ToInt32(dr["ProductID"]),
                                    ProductCategoryID = Convert.ToInt32(dr["ProductCategoryID"]),
                                    Name = dr["Name"].ToString(),
                                    ProductNumber = dr["ProductNumber"].ToString(),
                                    Color = dr["Color"].ToString(),
                                    ListPrice = Convert.ToDecimal(dr["ListPrice"]),
                                    Size = dr["Size"].ToString(),
                                });
                            }
                        }
                        return oProductList;
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        return oProductList;
                    }
                }
            }
        }
        public static User GetUser(string Name,string Email)
        {
            User oUser= new User();
            using (SqlConnection oConnection = new SqlConnection(Connection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM SalesLT.Customer WHERE FirstName = '{Name}' AND EmailAddress = '{Email}'", oConnection))
                {
                    try
                    {
                        oConnection.Open();
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                oUser = new User()
                                {   
                                    CustomerID = dr["CustomerID"].ToString(),
                                    FirstName = dr["FirstName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
                                    CompanyName = dr["CompanyName"].ToString(),
                                    Email = dr["EmailAddress"].ToString(),
                                    PhoneNumber = dr["Phone"].ToString(),
                                };
                            }
                        }
                        return oUser;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return oUser;
                    }
                }
            }
        }
        public static bool RegisterUser(User user)
        {
            using (SqlConnection oConnection = new SqlConnection(Connection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($@"
                     IF(SELECT EmailAddress FROM SalesLT.Customer WHERE EmailAddress = '{user.Email}') = '{user.Email}'
                        THROW 50000,'USER ALREADY EXIST',1
                     ELSE    
                        INSERT INTO SalesLT.Customer(FirstName,LastName,CompanyName,EmailAddress,Phone,PasswordHash,PasswordSalt) 
                        VALUES('{user.FirstName}','{user.LastName}','{user.CompanyName}','{user.Email}','{user.PhoneNumber}','{user.Password}','fefwefwe')", oConnection))
                {
                    try
                    {
                        oConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }
        
        public static bool RegisterPurchase(SalesOrderDetail salesOrder)
        {
            using (SqlConnection oConnection = new SqlConnection(Connection.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand($@" 
                        INSERT INTO SalesLT.SalesOrderDetail(SalesOrderID,ProductID, OrderQty,UnitPrice)
                        VALUES('9','{salesOrder.ProductID}','{salesOrder.OrderQty}','{salesOrder.UnitPrice}')", oConnection))
                {
                    try
                    {
                        oConnection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
