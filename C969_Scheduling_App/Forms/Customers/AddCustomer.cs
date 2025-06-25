using C969_Scheduling_App.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
            LoadCities();
            LoadCountries();
        }

        private void txtAddCustomerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LoadCities()
        {

            string cityQuery = "SELECT DISTINCT cityId, city FROM city ORDER BY city;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cityQuery, DBConnection.conn);
            DataTable cityTable = new DataTable();
            adapter.Fill(cityTable);

            cmbAddCustomerCity.DataSource = cityTable;
            cmbAddCustomerCity.DisplayMember = "city";
            cmbAddCustomerCity.ValueMember = "cityId";
            cmbAddCustomerCity.SelectedIndex = -1;
            
        }

        private void LoadCountries()
        {
            string countryQuery = "SELECT DISTINCT countryId, country FROM country ORDER BY country;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(countryQuery, DBConnection.conn);
            DataTable countryTable = new DataTable();
            adapter.Fill(countryTable);

            cmbAddCustomerCountry.DataSource = countryTable;
            cmbAddCustomerCountry.DisplayMember = "country";
            cmbAddCustomerCountry.ValueMember = "countryId";
            cmbAddCustomerCountry.SelectedIndex = -1;
            
        }

        private void btnAddCustomerSave_Click(object sender, EventArgs e)
        {
            string name = txtAddCustomerName.Text.Trim();
            string address = txtAddCustomerAddress.Text.Trim();
            string number = txtAddCustomerNumber.Text.Trim();
            string city = cmbAddCustomerCity.Text.Trim();
            string country = cmbAddCustomerCountry.Text.Trim();
            DateTime date = DateTime.Now;

            try
            {
                if (
                    string.IsNullOrEmpty(name) ||
                    string.IsNullOrEmpty(address) ||
                    string.IsNullOrEmpty(number) ||
                    string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(country)
                    )
                {
                    MessageBox.Show("Please fill in all required fields.",
                        "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int selectedCityId = Convert.ToInt32(cmbAddCustomerCity.SelectedValue);
                    int selectedCountryId = Convert.ToInt32(cmbAddCustomerCountry.SelectedValue);
                    string queryIsCityInCountry = "SELECT countryId FROM city WHERE cityId = @cityId;";
                    int actualCountryId = -1;

                    using (MySqlCommand cmd = new MySqlCommand(queryIsCityInCountry, DBConnection.conn))
                    {
                        cmd.Parameters.AddWithValue("@cityId", selectedCityId);
                        object result = cmd.ExecuteScalar();
                        
                        if (result != null)
                        {
                            actualCountryId = Convert.ToInt32(result);
                        }
                    }

                    if (actualCountryId != selectedCountryId)
                    {
                        MessageBox.Show("The selected city does not belong to the selected country.");
                        return;
                    }
                    else
                    {
                        int newAddressID = 0;
                        string queryInsertIntoAddress =
                            @"INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy)
                              VALUES (@address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

                        using (MySqlCommand cmd = new MySqlCommand(queryInsertIntoAddress, DBConnection.conn))
                        {
                            cmd.Parameters.AddWithValue("@address", address);
                            cmd.Parameters.AddWithValue("@address2", "");
                            cmd.Parameters.AddWithValue("@cityId", cmbAddCustomerCity.SelectedValue);
                            cmd.Parameters.AddWithValue("@postalCode", "");
                            cmd.Parameters.AddWithValue("@phone", number);
                            cmd.Parameters.AddWithValue("@createDate", date);
                            cmd.Parameters.AddWithValue("@createdBy", "user");
                            cmd.Parameters.AddWithValue("@lastUpdate", date);
                            cmd.Parameters.AddWithValue("@lastUpdateBy", "user");

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT LAST_INSERT_ID();";
                            cmd.Parameters.Clear();
                            object result = cmd.ExecuteScalar();
                            newAddressID = Convert.ToInt32(result);
                        }

                        string queryInsertIntoCustomer =
                            @"INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                              VALUES (@customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

                        using (MySqlCommand cmd = new MySqlCommand(queryInsertIntoCustomer, DBConnection.conn))
                        {
                            cmd.Parameters.AddWithValue("@customerName", name);
                            cmd.Parameters.AddWithValue("@addressId", newAddressID);
                            cmd.Parameters.AddWithValue("@active", 1);
                            cmd.Parameters.AddWithValue("@createDate", date);
                            cmd.Parameters.AddWithValue("@createdBy", "user");
                            cmd.Parameters.AddWithValue("@lastUpdate", date);
                            cmd.Parameters.AddWithValue("@lastUpdateBy", "user");

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Customer added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }
    }
}
