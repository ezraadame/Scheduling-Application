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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dgvCustomerMGMT.RowHeadersVisible = false;
            dgvCustomerMGMT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerMGMT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerMGMT.AllowUserToResizeRows = false;
            dgvCustomerMGMT.ReadOnly = true;
            dgvCustomerMGMT.MultiSelect = false;
            dgvCustomerMGMT.AllowUserToAddRows = false;
            LoadCustomerData();
            dgvCustomerMGMT.ClearSelection();

            dgvAppointmentMGMT.RowHeadersVisible = false;
            dgvAppointmentMGMT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointmentMGMT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointmentMGMT.AllowUserToResizeRows = false;
            dgvAppointmentMGMT.ReadOnly = true;
            dgvAppointmentMGMT.MultiSelect = false;
            dgvAppointmentMGMT.AllowUserToAddRows = false;
            LoadAppointmentData();
            dgvAppointmentMGMT.ClearSelection();
        }

        private void LoadCustomerData()
        {
            try
            {
                string customerQuery = "" +
                    "SELECT \r\n    " +
                    "c.customerId AS 'ID', \r\n    " +
                    "c.customerName AS 'Name', \r\n    " +
                    "a.address AS 'Address',\r\n    " +
                    "a.phone AS 'Phone Number',\r\n    " +
                    "ci.city AS 'City',\r\n    " +
                    "co.country AS 'Country'\r\n" +
                    "FROM customer c\r\n" +
                    "JOIN address a ON c.addressId = a.addressId\r\n" +
                    "JOIN city ci ON a.cityId = ci.cityId\r\n" +
                    "JOIN country co ON ci.countryId = co.countryId;";

                MySqlDataAdapter adapter = new MySqlDataAdapter(customerQuery, DBConnection.conn);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCustomerMGMT.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }

        private void LoadAppointmentData()
        {
            try
            {
                string appointmentQuery = "SELECT * FROM appointment";
                MySqlDataAdapter adapter = new MySqlDataAdapter(appointmentQuery, DBConnection.conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAppointmentMGMT.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReportsMenu_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.Show();
            this.Hide();
        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
            this.Hide();
        }

        private void btnAppointmentUpdate_Click(object sender, EventArgs e)
        {
            ModifyAppointment modifyAppointment = new ModifyAppointment();
            modifyAppointment.Show();
            this.Hide();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            this.Hide();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomerMGMT.CurrentRow == null || !dgvCustomerMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected, please select an item.");
                return;
            }
            else
            {
                var selectedCustomer = new Customer
                {
                    CustomerId = Convert.ToInt32(dgvCustomerMGMT.CurrentRow.Cells["ID"].Value),
                    CustomerName = dgvCustomerMGMT.CurrentRow.Cells["Name"].Value.ToString(),
                    Address = dgvCustomerMGMT.CurrentRow.Cells["Address"].Value.ToString(),
                    Phone = dgvCustomerMGMT.CurrentRow.Cells["Phone Number"].Value.ToString(),
                    City = dgvCustomerMGMT.CurrentRow.Cells["City"].Value.ToString(),
                    Country = dgvCustomerMGMT.CurrentRow.Cells["Country"].Value.ToString()
                };

                int addressId = -1;
                string queryGetAddressId = "SELECT addressId FROM customer WHERE customerId = @customerId;";
                using (MySqlCommand cmdGetAddressId = new MySqlCommand(queryGetAddressId, DBConnection.conn))
                {
                    cmdGetAddressId.Parameters.AddWithValue("@customerId", selectedCustomer.CustomerId);
                    using (var reader = cmdGetAddressId.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            addressId = reader.GetInt32("addressId");
                        }
                    }
                }

                if (addressId != -1)
                {
                    UpdateCustomer updateCustomer = new UpdateCustomer(selectedCustomer, addressId);
                    updateCustomer.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to retrieve address ID for the selected customer.");
                }
            }
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomerMGMT.CurrentRow == null || !dgvCustomerMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing selected, please select an item.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this item forever?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int customerId = Convert.ToInt32(dgvCustomerMGMT.CurrentRow.Cells["ID"].Value);
                int addressId = -1;
                string queryDeleteAddressRow = "DELETE FROM address WHERE addressId = @addressId;";
                string queryDeleteCustomerRow = "DELETE FROM customer WHERE customerId = @customerId;";
                string queryGetAddressId = "SELECT addressId FROM customer WHERE customerId = @customerId;";
                
                using (MySqlCommand cmdGetAddressId = new MySqlCommand(queryGetAddressId, DBConnection.conn))
                {
                    cmdGetAddressId.Parameters.AddWithValue("@customerId", customerId);
                    using (var reader = cmdGetAddressId.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            addressId = reader.GetInt32("addressId");
                        }
                    }
                }

                if (addressId != -1)
                {
                    using (MySqlCommand cmdAddress = new MySqlCommand(queryDeleteCustomerRow, DBConnection.conn))
                    {
                        cmdAddress.Parameters.AddWithValue("@customerId", customerId);
                        cmdAddress.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmdCustomer = new MySqlCommand(queryDeleteAddressRow, DBConnection.conn))
                    {
                        cmdCustomer.Parameters.AddWithValue("@addressId", addressId);
                        cmdCustomer.ExecuteNonQuery();
                    }
                }
                LoadCustomerData();
                LoadAppointmentData();
            }
            else
            {
                MessageBox.Show("Unable to delete item.");
            }
            
        }
    }
}
