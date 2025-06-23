using C969_Scheduling_App.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App.Forms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void txtAddCustomerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        

        //private void btnAddCustomerSave_Click(object sender, EventArgs e)
        //{
        //    string name = txtAddCustomerName.Text.Trim();
        //    string address = txtAddCustomerAddress.Text.Trim();
        //    string number = txtAddCustomerNumber.Text.Trim();
        //    string city = txtAddCustomerCity.Text.Trim();
        //    string country = txtAddCustomerCountry.Text.Trim();

        //    try
        //    {
        //        if (
        //            string.IsNullOrEmpty(name) ||
        //            string.IsNullOrEmpty(address) ||
        //            string.IsNullOrEmpty(number) ||
        //            string.IsNullOrEmpty(city) ||
        //            string.IsNullOrEmpty(country)
        //            )
        //        {
        //            MessageBox.Show("Please fill in all required fields.",
        //                "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        else
        //        {
        //            string queryAddCustomerName =
        //                "INSERT INTO customer (customerName) VALUES (@name)";

        //            string queryAddCustomerAddress =
        //                "INSERT INTO address (address) VALUES (@address)";

        //            string queryAddCustomerNumber =
        //                "INSERT INTO address (phone) VALUES (@number)";

        //            string queryAddCustomerCity =
        //                "INSERT INTO city (city) VALUES (@city)";

        //            string queryAddCustomerCountry =
        //                "INSERT INTO country (country) VALUES (@country)";


        //            using (MySqlCommand cmdCustomer = new MySqlCommand(queryAddCustomerName, DBConnection.conn))
        //            {
        //                cmdCustomer.Parameters.AddWithValue("@name", name);
        //                cmdCustomer.ExecuteNonQuery();
        //            }

        //            using (MySqlCommand cmdAddress = new MySqlCommand(queryAddCustomerAddress, DBConnection.conn))
        //            {
        //                cmdAddress.Parameters.AddWithValue("@address", address);
        //                cmdAddress.ExecuteNonQuery();
        //            }

        //            using (MySqlCommand cmdNumber = new MySqlCommand(queryAddCustomerNumber, DBConnection.conn))
        //            {
        //                cmdNumber.Parameters.AddWithValue("@number", number);
        //                cmdNumber.ExecuteNonQuery();
        //            }

        //            using (MySqlCommand cmdCity = new MySqlCommand(queryAddCustomerCity, DBConnection.conn))
        //            {
        //                cmdCity.Parameters.AddWithValue("@city", city);
        //                cmdCity.ExecuteNonQuery();
        //            }

        //            using (MySqlCommand cmdCountry = new MySqlCommand(queryAddCustomerCountry, DBConnection.conn))
        //            {
        //                cmdCountry.Parameters.AddWithValue("@country", country);
        //                cmdCountry.ExecuteNonQuery();
        //            }

        //            MessageBox.Show("Customer added successfully!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred: {ex.Message}");
        //    }
        //}

    }
}
