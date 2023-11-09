using Npgsql;
using System;
using System.Buffers.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.Numerics;
using BubbleTea.Modles;



namespace BubbleTea
{
    /// <summary>
    /// Interaction logic for EmployeeInfo.xaml
    /// </summary>
    public partial class EmployeeInfo : Window
    {
        public EmployeeInfo()
        {
            InitializeComponent();
            AddValues();




        }

        public void AddValues()
        {
            MessageBox.Show(Employee.emp_lname);
            id.Text = "1001";
            lname.Text = Employee.emp_lname;
            fname.Text = Employee.emp_fname;
            email.Text = Employee.emp_email;
            phone.Text =Employee.emp_phone.ToString();
            dept.Text = Employee.emp_dept;
        }






    }

}
