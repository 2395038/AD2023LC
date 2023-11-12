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
        Employee emp { get; set; }
        private EmployeeInfo()
        {
            InitializeComponent();
            
        }
        public EmployeeInfo(Employee e) :this()
        {
            emp = e;
            AddValues();
        }

        public void AddValues()
        {
            MessageBox.Show(emp.emp_lname);
            id.Text = emp.emp_id;
            lname.Text = emp.emp_lname;
            fname.Text = emp.emp_fname;
            email.Text = emp.emp_email;
            phone.Text = emp.emp_phone.ToString();
            dept.Text = emp.emp_dept;
        }






    }

}
