using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CMPE312Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    public partial class MainWindow : Window
    {
        SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["CMPE312Project.Properties.Settings.customerInfoConnectionString"].ConnectionString;
            con = new SqlConnection(connectionString);
            
        }

        private void onlynumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProduct win2 = new AddProduct();
            win2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DarkMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CustomerInfo = "Dark";
            Properties.Settings.Default.Save();
        }

        private void LightMode_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CustomerInfo = "Light";
            Properties.Settings.Default.Save();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateProduct win3 = new UpdateProduct();
            win3.Show();
        }

        private void findbutton_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(pNumber.Text))
            {
                string message = "PNumber can not be empty";
                MessageBox.Show(message);
            }
            else
            {
                string sql = "select * from customerInfos where pNumber = " + pNumber.Text + "";
                Console.WriteLine(sql);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string output = "|Phone Number: " + rdr.GetValue(0) + " |Name & Surname: " + rdr.GetValue(1) + " |Address: " + rdr.GetValue(2) + " |Gender: " + rdr.GetValue(3) + " |Date of Birth: " + rdr.GetValue(4);
                    listbox.Items.Add(output);

                    name.Text = (string)rdr.GetValue(1);
                    address.Text = (string)rdr.GetValue(2);
                    gender.Text = (string)rdr.GetValue(3);
                    date.Text = Convert.ToString(rdr.GetValue(4));


                }
                con.Close();
            }

   
        }

        private void deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            string sql = "delete from customerInfos where pNumber = " + pNumber.Text + "";
            Console.WriteLine(sql);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int a = cmd.ExecuteNonQuery();
            MessageBoxResult result = MessageBox.Show("Successfully deleted!");
            pNumber.Clear();
            name.Clear();
            address.Clear();
            gender.Clear();
            date.Clear();
            con.Close();

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            pNumber.Clear();
            name.Clear();
            address.Clear();
            gender.Clear();
            date.Clear();
        }
    }
}
