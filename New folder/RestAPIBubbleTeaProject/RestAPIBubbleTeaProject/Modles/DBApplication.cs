using Npgsql;
using System.Data;
using System.Numerics;
using System.Xml.Linq;

namespace RestAPIBubbleTeaProject.Modles
{
    public class DBApplication
    {
        public Response GetAllEmployees(NpgsqlConnection con)
        {
            string Query = "Select * from employee";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();

            List<Employee> employees = new List<Employee>();

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();

                    employee.emp_lname = (string)dt.Rows[i]["Last_Name"];
                    employee.emp_fname = (string)dt.Rows[i]["First_Name"];
                    employee.emp_id = (string)dt.Rows[i]["Employee_ID"];
                    employee.emp_email = (string)dt.Rows[i]["Email"];
                    // employee.emp_phone = (BigInteger)dt.Rows[i]["Phone"];
                    if (dt.Rows[i]["Phone"] != DBNull.Value)
                    {
                        employee.emp_phone = dt.Rows[i].Field<long>("Phone");
                    }
                    employee.emp_dept = (string)dt.Rows[i]["Department"];
                    employee.emp_password = (string)dt.Rows[i]["Password"];

                    employees.Add(employee);
                }
            }

            if (employees.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data Retrieved Successfully";
                response.employee = null;
                response.employees = employees;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data failed to Retrieve or maybe table is empty";
                response.employee = null;
                response.employees = null;
            }
            return response;
        }

        public Response GetEmployeesbyId(NpgsqlConnection con, string id)
        {

            Response response = new Response();

            string Query = "Select * from employee where employee_id='" + id + "'";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Employee employee = new Employee();
                employee.emp_lname = (string)dt.Rows[0]["Last_Name"];
                employee.emp_fname = (string)dt.Rows[0]["First_Name"];
                employee.emp_id = (string)dt.Rows[0]["Employee_ID"];
                employee.emp_email = (string)dt.Rows[0]["Email"];
                if (dt.Rows[0]["Phone"] != DBNull.Value)
                {
                    employee.emp_phone = dt.Rows[0].Field<long>("Phone");
                }
                employee.emp_dept = (string)dt.Rows[0]["Department"];
                employee.emp_password = (string)dt.Rows[0]["Password"];


                response.statusCode = 200;
                response.messageCode = "Successfully Retrieved";
                response.employee = employee;
                response.employees = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data couldn't found ... check the id";
                response.employee = null;
                response.employee = null;
            }
            return response;
        }

        public Response AddEmployee(NpgsqlConnection con, Employee employee)
        {
            con.Open();
            Response response = new Response();
            string Query = "insert into employee values(@id,@lname,@fname, @email, @phone,@dept,@password)";
            
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@lname", employee.emp_lname);
            cmd.Parameters.AddWithValue("@fname", employee.emp_fname);
            cmd.Parameters.AddWithValue("@id", employee.emp_id);
            cmd.Parameters.AddWithValue("@email", employee.emp_email);
            cmd.Parameters.AddWithValue("@phone", employee.emp_phone);
            cmd.Parameters.AddWithValue("@dept", employee.emp_dept);
            cmd.Parameters.AddWithValue("@password", employee.emp_password );
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Successfully inserted";
                response.employee = employee;
                response.employees = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Insertion is not successfull";
                response.employee = null;
                response.employee = null;
            }
            con.Close();
            return response;
        }

        public Response UpdateEmployee(NpgsqlConnection con, Employee employee)
        {
            con.Open();
            Response response = new Response();
            string Query = "UPDATE employee SET last_name = @lname,first_name=@fname, phone = @phone, department = @dept,password= @password WHERE employee_id= @id";

           
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@lname", employee.emp_lname);
            cmd.Parameters.AddWithValue("@fname", employee.emp_fname);
            cmd.Parameters.AddWithValue("@id", employee.emp_id);
            cmd.Parameters.AddWithValue("@email", employee.emp_email);
            cmd.Parameters.AddWithValue("@phone", employee.emp_phone);
            cmd.Parameters.AddWithValue("@dept", employee.emp_dept);
            cmd.Parameters.AddWithValue("@password", employee.emp_password);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Updated Successfully";
                response.employee = employee;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Update failed or id wasn't in correct form";
            }
            con.Close();
            return response;
        }

        public Response DeleteEmployeebyId(NpgsqlConnection con, string id)
        {
            con.Open();
            Response response = new Response();
            string Query = "DELETE FROM employee WHERE Employee_ID ='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Product Delected Successfully";
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Product not found. Could not perform delete Ops";
            }
            con.Close();
            return response;
        }
    }
}
