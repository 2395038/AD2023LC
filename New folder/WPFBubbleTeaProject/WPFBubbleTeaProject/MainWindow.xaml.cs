using Npgsql;
using System;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using WPFBubbleTeaProject.Moddle;
using System.Numerics;

namespace WPFBubbleTeaProject
{
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();


        public MainWindow()
        {
            client.BaseAddress = new Uri("https://localhost:7254/EmployeeManagementControler/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private async void show_Click(object sender, RoutedEventArgs e)
        {
            // step 1 : create/call the method to get all the employee
            var server_response = await client.GetStringAsync("GetAllEmployees");

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            dataGrid.ItemsSource = response_JSON.employees;

            DataContext = this;
        }

        private async void Select_Click(object sender, RoutedEventArgs e)
        {
            // step 1 : create/call the method to get one product
            var server_response =
                await client.GetStringAsync("GetEmployeesbyId/" + search.Text);

            //step 2 : Decryt/extract the server_response
            // import Json libary : using Newtonsoft.Json;
            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            fname.Text = response_JSON.employee.emp_fname.ToString();
            lname.Text = response_JSON.employee.emp_lname.ToString();
            id.Text = response_JSON.employee.emp_id.ToString();
            email.Text = response_JSON.employee.emp_email.ToString();
            phone.Text = response_JSON.employee.emp_phone.ToString();
            dept.Text= response_JSON.employee.emp_dept.ToString();
            password.Text = response_JSON.employee.emp_password.ToString();
        }

        private async void insert_Click(object sender, RoutedEventArgs e)
        {
            // stpe 1 : create an instance of the product
            Employee employee = new Employee();

            employee.emp_fname = fname.Text;
            employee.emp_lname = lname.Text;
            MessageBox.Show(employee.emp_fname);
            //Product_ID is not default in database
            employee.emp_id = id.Text;
            employee.emp_email = email.Text;
            if (long.TryParse(phone.Text, out long phoneValue))
            {
                // Successfully converted to long, now you can assign it to emp_phone
                employee.emp_phone = phoneValue;
            }
            employee.emp_dept = dept.Text;
            employee.emp_password = password.Text;
           
     

            //nuGet Package : webAPI
            var server_response =
                await client.PostAsJsonAsync("AddEmployee", employee);

            MessageBox.Show(server_response.ToString());

            employee.emp_fname = null;
            employee.emp_lname = null;
            employee.emp_id = null;
            employee.emp_email = null;
            employee.emp_phone = 0;
            employee.emp_dept = null;
            employee.emp_password = null;
        }

        private async void update_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();

            employee.emp_fname = fname.Text;
            employee.emp_lname = lname.Text;
            employee.emp_id = id.Text;
            employee.emp_email = email.Text;
            if (long.TryParse(phone.Text, out long phoneValue))
            {
                // Successfully converted to long, now you can assign it to emp_phone
                employee.emp_phone = phoneValue;
            }
            employee.emp_dept = dept.Text;
            employee.emp_password = password.Text;


            var server_response =
                await client.PutAsJsonAsync("UpdateEmployee", employee);
            MessageBox.Show(server_response.ToString());

            employee.emp_fname = null;
            employee.emp_lname = null;
            employee.emp_id = null;
            employee.emp_email = null;
            employee.emp_phone = 0;
            employee.emp_dept = null;
            employee.emp_password = null;
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            var response_JSON =
                await client.DeleteAsync("DeleteEmployeebyId/"
                + search.Text);

            MessageBox.Show(response_JSON.StatusCode.ToString());
            MessageBox.Show(response_JSON.RequestMessage.ToString());

        }


    }
}