using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestAPIAssignment2.Modles;
using RestAPIAssignment2.Modles;
using System.Security.Cryptography;

namespace RestAPIAssignment2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductManagement : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductManagement(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet] 
        [Route("GetAllProducts")] 

        public Response GetAllProduct()
        {

            Response response = new Response(); 

            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("productConnection"));

            DBApplication dbA = new DBApplication(); 

            response = dbA.GetAllProducts(con);

            return response;
        }


        [HttpGet]
        [Route("GetProductbyId/{id}")]
        public Response GetProductbyId(int id)
        {
            Response response = new Response();
            
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("productConnection"));
           
            DBApplication dbA = new DBApplication();
           
            response = dbA.GetProductbyId(con, id);
            
            return response;
        }


        [HttpPost] 
        [Route("AddProduct")]
        public Response AddProduct(Product product) 
        {
            Response response = new Response();
            
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("productConnection"));
            
            DBApplication dbA = new DBApplication();
            
            response = dbA.AddProduct(con, product);
            return response;
        }

        
        [HttpPut] 
        [Route("UpdateProduct")]
        public Response UpdateProduct(Product product) 
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("productConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.UpdateProduct(con, product);
            return response;
        }

        [HttpDelete]
        [Route("DeleteProductbyId/{id}")]
        public Response DeleteProductbyId(int id)
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("productConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.DeleteProductbyId(con, id);
            return response;
        }
    }
}
