using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using WebApi.data;
using WebApi.models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdventureWorksController : ControllerBase
    {

        [HttpGet]
        [Route("GetProductCategory")]
        public List<ProductCategory> Get()
        {
            return ProductData.ListProducts();
        }

        [HttpGet]
        [Route("GetParentID/{id}")]
        public List<ProductCategory> Get(string id)
        {
            return ProductData.ProductCategoryID(id);
        }
        [HttpGet]
        [Route("GetProductID/{id}")]
        public List<Product> Get(int id)
        {
            return ProductData.ProductByID(id);
        }

        [HttpGet]
        [Route("GetUser/{Name}/{Email}")]

        public User Get(string Name, string Email)
        {
            return ProductData.GetUser(Name,Email);
        }

        [HttpPost]
        [Route("PostUser")]
        public bool Post([FromBody]User user)
        {
            return ProductData.RegisterUser(user);
        }
        [HttpPost]
        [Route("PostProduct")]
        public bool Post([FromBody] SalesOrderDetail salesOrder)
        {
            return ProductData.RegisterPurchase(salesOrder);
        }
    }
}
        
        //public bool Registrar(HumanResources oHumanResources)
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AdventureWorksConnection").ToString());
        //    using (SqlConnection oConexion = new SqlConnection(_configuration.GetConnectionString("AdventureWorksConnection").ToString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
        //        cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
        //        cmd.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
        //        cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);
        //        cmd.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

        //        try
        //        {
        //            oConexion.Open();
        //            cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }
        //}

        //public static bool Modificar(Usuario oUsuario)
        //{
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idusuario", oUsuario.IdUsuario);
        //        cmd.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
        //        cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
        //        cmd.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
        //        cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);
        //        cmd.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

        //        try
        //        {
        //            oConexion.Open();
        //            cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }
        //}



        //public static Usuario Obtener(int idusuario)
        //{
        //    Usuario oUsuario = new Usuario();
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idusuario", idusuario);

        //        try
        //        {
        //            oConexion.Open();
        //            cmd.ExecuteNonQuery();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {

        //                while (dr.Read())
        //                {
        //                    oUsuario = new Usuario()
        //                    {
        //                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
        //                        DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
        //                        Nombres = dr["Nombres"].ToString(),
        //                        Telefono = dr["Telefono"].ToString(),
        //                        Correo = dr["Correo"].ToString(),
        //                        Ciudad = dr["Ciudad"].ToString(),
        //                        FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
        //                    };
        //                }

        //            }



        //            return oUsuario;
        //        }
        //        catch (Exception ex)
        //        {
        //            return oUsuario;
        //        }
        //    }
        //}

        //public static bool Eliminar(int id)
        //{
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idusuario", id);

        //        try
        //        {
        //            oConexion.Open();
        //            cmd.ExecuteNonQuery();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return false;
        //        }
        //    }


   