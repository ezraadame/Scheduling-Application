using C969_Scheduling_App.Database;
using C969_Scheduling_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App.Forms
{
    public partial class UpdateCustomer : Form
    {
        private readonly Customer _customer;
        private readonly int _addressId;
        public UpdateCustomer(Customer customer, int addressId)
        {
            InitializeComponent();
            _customer = customer;
            _addressId = addressId;
            LoadCities();
            LoadCountries();
        }

        private void txtUpdateCustomerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            txtUpdateCustomerID.Text = _customer.CustomerId.ToString();
            txtUpdateCustomerName.Text = _customer.CustomerName.ToString();
            txtUpdateCustomerAddress.Text = _customer.Address.ToString();
            txtUpdateCustomerNumber.Text = _customer.Phone.ToString();
            cmbUpdateCustomerCity.Text = _customer.City.ToString();
            cmbUpdateCustomerCountry.Text = _customer.Country.ToString();
        }
        private void BtnUpdateCustomerSave_Click(object sender, EventArgs e) => UpdateCustomerToDB();

        private void BtnUpdateCustomerCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }
        private void LoadCities()
        {
            string cityQuery = "SELECT DISTINCT cityId, city FROM city ORDER BY city;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cityQuery, DBConnection.Conn);
            DataTable cityTable = new DataTable();
            adapter.Fill(cityTable);

            cmbUpdateCustomerCity.DataSource = cityTable;
            cmbUpdateCustomerCity.DisplayMember = "city";
            cmbUpdateCustomerCity.ValueMember = "cityId";
            cmbUpdateCustomerCity.SelectedIndex = -1;
        }

        private void LoadCountries()
        {
            string countryQuery = "SELECT DISTINCT countryId, country FROM country ORDER BY country;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(countryQuery, DBConnection.Conn);
            DataTable countryTable = new DataTable();
            adapter.Fill(countryTable);

            cmbUpdateCustomerCountry.DataSource = countryTable;
            cmbUpdateCustomerCountry.DisplayMember = "country";
            cmbUpdateCustomerCountry.ValueMember = "countryId";
            cmbUpdateCustomerCountry.SelectedIndex = -1;
        }

        private void UpdateCustomerToDB()
        {
            DateTime date = DateTime.Now;
            try
            {
                if (
                    string.IsNullOrEmpty(txtUpdateCustomerName.Text.Trim()) ||
                    string.IsNullOrEmpty(txtUpdateCustomerAddress.Text.Trim()) ||
                    string.IsNullOrEmpty(txtUpdateCustomerNumber.Text.Trim()) ||
                    string.IsNullOrEmpty(cmbUpdateCustomerCity.Text.Trim()) ||
                    string.IsNullOrEmpty(cmbUpdateCustomerCountry.Text.Trim())
                   )
                {
                    MessageBox.Show("Please fill in all required fields.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int selectedCityId = Convert.ToInt32(cmbUpdateCustomerCity.SelectedValue);
                    int selectedCountryId = Convert.ToInt32(cmbUpdateCustomerCountry.SelectedValue);
                    string queryIsCityInCountry = "SELECT countryId FROM city WHERE cityId = @cityId;";
                    int actualCountryId = -1;

                    using (MySqlCommand cmd = new MySqlCommand(queryIsCityInCountry, DBConnection.Conn))
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
                        string queryUpdateAddress = @"
                                                    UPDATE address
                                                    SET address = @address, cityId = @cityId, phone = @phone, lastUpdate = @lastUpdate
                                                    WHERE addressId = @addressId;";

                        using (MySqlCommand cmd = new MySqlCommand(queryUpdateAddress, DBConnection.Conn))
                        {
                            cmd.Parameters.AddWithValue("@address", txtUpdateCustomerAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@phone", txtUpdateCustomerNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@cityId", selectedCityId);
                            cmd.Parameters.AddWithValue("@lastUpdate", date);
                            cmd.Parameters.AddWithValue("@addressId", _addressId);

                            cmd.ExecuteNonQuery();

                        }

                        string queryUpdateCustomer = @"
                                                     UPDATE customer
                                                     SET customerName = @customerName, lastUpdate = @lastUpdate
                                                     WHERE customerId = @customerId;";

                        using (MySqlCommand cmd = new MySqlCommand(queryUpdateCustomer, DBConnection.Conn))
                        {
                            cmd.Parameters.AddWithValue("@customerName", txtUpdateCustomerName.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastUpdate", date);
                            cmd.Parameters.AddWithValue("@customerId", Convert.ToInt32(txtUpdateCustomerID.Text));

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Customer updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        } 
    }
}
