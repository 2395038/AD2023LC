using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestAPIBubbleTeaProject.Modles;
using System.Security.Cryptography;

namespace RestAPIBubbleTeaProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeManagementControler : ControllerBase
    {
       
       
            private readonly IConfiguration _configuration;

            public EmployeeManagementControler(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            [Route("GetAllEmployees")]

            public Response GetAllProduct()
            {

                Response response = new Response();

                NpgsqlConnection con =
                    new NpgsqlConnection(_configuration.GetConnectionString("employeeConnection"));

                DBApplication dbA = new DBApplication();

                response = dbA.GetAllEmployees(con);

                return response;
            }


            [HttpGet]
            [Route("GetEmployeesbyId/{id}")]
            public Response GetEmployeesbyId(string id)
            {
                Response response = new Response();

                NpgsqlConnection con =
                    new NpgsqlConnection(_configuration.GetConnectionString("employeeConnection"));

                DBApplication dbA = new DBApplication();

                response = dbA.GetEmployeesbyId(con, id);

                return response;
            }


            [HttpPost]
            [Route("AddEmployee")]
            public Response AddEmployee(Employee employee)
            {
                Response response = new Response();

                NpgsqlConnection con =
                    new NpgsqlConnection(_configuration.GetConnectionString("employeeConnection"));

                DBApplication dbA = new DBApplication();

                response = dbA.AddEmployee(con, employee);
                return response;
            }


            [HttpPut]
            [Route("UpdateEmployee")]
            public Response UpdateProduct(Employee employee)
            {
                Response response = new Response();
                NpgsqlConnection con =
                    new NpgsqlConnection(_configuration.GetConnectionString("employeeConnection"));
                DBApplication dbA = new DBApplication();
                response = dbA.UpdateEmployee(con, employee);
                return response;
            }

            [HttpDelete]
            [Route("DeleteEmployeebyId/{id}")]
            public Response DeleteProductbyId(string id)
            {
                Response response = new Response();
                NpgsqlConnection con =
                    new NpgsqlConnection(_configuration.GetConnectionString("employeeConnection"));
                DBApplication dbA = new DBApplication();
                response = dbA.DeleteEmployeebyId(con, id);
                return response;
            }
        }
    }

