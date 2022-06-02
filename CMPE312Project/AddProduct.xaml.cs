using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CMPE312Project
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {

        
        public AddProduct()
        {
            InitializeComponent();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void onlynumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void addcustomer_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(pNumber.Text))
            {
                string message = "PNumber can not be empty";
                MessageBox.Show(message);
            }


            else if (string.IsNullOrEmpty(name.Text))
            {
                string message = "Name Surname can not be empty";
                MessageBox.Show(message);
            }

            else if (string.IsNullOrEmpty(address.Text))
            {
                string message = "Address can not be empty";
                MessageBox.Show(message);
            }

            else if (string.IsNullOrEmpty(gender.Text))
            {
                string message = "Gender can not be empty";
                MessageBox.Show(message);
            }

            else if (string.IsNullOrEmpty(date.Text))
            {
                string message = "Date of birth can not be empty";
                MessageBox.Show(message);
            }

            else
            {
            string sql = "insert into customerInfos values ("+pNumber.Text+","+"'"+name.Text+"'"+","+"'"+address.Text+"'"+","+"'"+gender.Text+"'"+","+"'"+date.Text+"'"+")";
            Console.WriteLine(sql);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CMPE312Project.Properties.Settings.customerInfoConnectionString"].ConnectionString;
            SqlConnection con;
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            int a = cmd.ExecuteNonQuery();
            MessageBoxResult result = MessageBox.Show("Successfully added!");
            con.Close();
            Close();
            }
        }

    }
}
