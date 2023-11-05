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

using static BubbleTea.EmployeeLogin;

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
        List<string> employeeInfo = EmployeeLogin.EmployeeClass;
        public void AddValues()
        {

            id.Text = employeeInfo[0];
            lname.Text = employeeInfo[1];
            fname.Text = employeeInfo[2];
            email.Text = employeeInfo[3];
            phone.Text = employeeInfo[4];
            dept.Text = employeeInfo[5];
        }






    }

}
