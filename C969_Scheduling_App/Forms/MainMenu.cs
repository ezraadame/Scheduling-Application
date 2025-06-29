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
using static C969_Scheduling_App.Login;

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
            CheckUpcomingAppointments(AppSession.CurrentUserId);
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
        private void BtnCustomerAdd_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            this.Hide();
        }
        private void BtnCustomerUpdate_Click(object sender, EventArgs e) => LoadUpdateCustomerForm();
        private void BtnCustomerDelete_Click(object sender, EventArgs e) => DeleteCustomer();
        private void BtnAppointmentAdd_Click(object sender, EventArgs e) => LoadAddAppointmentForm();
        private void BtnAppointmentUpdate_Click(object sender, EventArgs e) => LoadAppointmentUpdateForm();
        private void BtnAppointmentDelete_Click(object sender, EventArgs e) => DeleteAppointment();
        private void RdbtnCurrentWeek_CheckedChanged(object sender, EventArgs e) => LoadCurrentWeek();
        private void RdbtnCurrentMonth_CheckedChanged(object sender, EventArgs e) => LoadCurrentMonth();
        private void RdbtnAllAppointments_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointmentData();
            dgvAppointmentMGMT.ClearSelection();
        }
        private void ChkbxSelectDay_CheckedChanged(object sender, EventArgs e)
        {
            mnthCalendarAppointments.Visible = chkbxSelectDay.Checked;

            if (chkbxSelectDay.Checked)
            {
                LoadAppointmentBySelectedDate();
            }
            else
            {
                LoadAppointmentData();
                dgvAppointmentMGMT.ClearSelection();
            }

        }
        private void MnthCalendarAppointments_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (chkbxSelectDay.Checked)
            {
                LoadAppointmentBySelectedDate();
            }
        }
        private void BtnReports_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.Show();
            this.Hide();
        }
        private void BtnExit_Click(object sender, EventArgs e) => Application.Exit();
        private void LoadCurrentMonth()
        {
            try
            {
                DateTime Today = DateTime.Today;
                DateTime firstDayOfMonth = new DateTime(Today.Year, Today.Month, 1);
                DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
                DateTime lastDayOfMonth = firstDayOfNextMonth.AddTicks(-1);
                string appointmentQuery = ""
                    + "SELECT \r\n"
                    + "a.appointmentId AS 'ID', \r\n"
                    + "a.customerId AS 'Customer ID', \r\n"
                    + "c.customerName AS 'Customer Name', \r\n"
                    + "a.userId AS 'User ID', \r\n"
                    + "a.title AS 'Title', \r\n"
                    + "a.description AS 'Description', \r\n"
                    + "a.location AS 'Location', \r\n"
                    + "a.contact AS 'Contact', \r\n"
                    + "a.type AS 'Type', \r\n"
                    + "a.start AS 'Start Date/Time', \r\n"
                    + "a.end AS 'End Date/Time' \r\n"
                    + "FROM appointment a\r\n"
                    + "INNER JOIN customer c ON a.customerId = c.customerId \r\n"
                    + "WHERE a.start BETWEEN @firstDayOfMonth AND @lastDayOfMonth;";

                using (MySqlCommand cmd = new MySqlCommand(appointmentQuery, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth);
                    cmd.Parameters.AddWithValue("@lastDayOfMonth", lastDayOfMonth);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (row["Start Date/Time"] is DateTime utcStart)
                            {
                                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            }

                            if (row["End Date/Time"] is DateTime utcEnd)
                            {
                                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);
                            }
                        }
                        dgvAppointmentMGMT.DataSource = table;
                        dgvAppointmentMGMT.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }
        private void LoadCurrentWeek()
        {
            try
            {
                DateTime Today = DateTime.Today;
                int daysToSubtract = (int)Today.DayOfWeek;
                DateTime Sunday = Today.AddDays(-daysToSubtract);
                DateTime Saturday = Sunday.AddDays(7).AddTicks(-1);
                string appointmentQuery = ""
                    + "SELECT \r\n"
                    + "a.appointmentId AS 'ID', \r\n"
                    + "a.customerId AS 'Customer ID', \r\n"
                    + "c.customerName AS 'Customer Name', \r\n"
                    + "a.userId AS 'User ID', \r\n"
                    + "a.title AS 'Title', \r\n"
                    + "a.description AS 'Description', \r\n"
                    + "a.location AS 'Location', \r\n"
                    + "a.contact AS 'Contact', \r\n"
                    + "a.type AS 'Type', \r\n"
                    + "a.start AS 'Start Date/Time', \r\n"
                    + "a.end AS 'End Date/Time' \r\n"
                    + "FROM appointment a\r\n"
                    + "INNER JOIN customer c ON a.customerId = c.customerId \r\n"
                    + "WHERE a.start BETWEEN @startOfWeek AND @endOfWeek;";

                using (MySqlCommand cmd = new MySqlCommand(appointmentQuery, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@startOfWeek", Sunday);
                    cmd.Parameters.AddWithValue("@endOfWeek", Saturday);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (row["Start Date/Time"] is DateTime utcStart)
                            {
                                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            }

                            if (row["End Date/Time"] is DateTime utcEnd)
                            {
                                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);
                            }
                        }
                        dgvAppointmentMGMT.DataSource = table;
                        dgvAppointmentMGMT.ClearSelection();
                        dgvAppointmentMGMT.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }
        private void DeleteAppointment()
        {
            int appointmentId = Convert.ToInt32(dgvAppointmentMGMT.CurrentRow.Cells["ID"].Value);
            if (dgvAppointmentMGMT.CurrentRow == null || !dgvAppointmentMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer forever?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string queryDeleteFromAppointment = "" +
                        "DELETE FROM appointment " +
                        "WHERE appointmentId = @appointmentId;";

                    using (MySqlCommand cmd = new MySqlCommand(queryDeleteFromAppointment, DBConnection.Conn))
                    {
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadCustomerData();
                    LoadAppointmentData();
                    dgvAppointmentMGMT.ClearSelection();
                    dgvCustomerMGMT.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void LoadAppointmentUpdateForm()
        {
            if (dgvAppointmentMGMT.CurrentRow == null || !dgvAppointmentMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }
            else
            {
                var selectedAppointment = new Appointment
                {
                    AppointmentId = Convert.ToInt32(dgvAppointmentMGMT.CurrentRow.Cells["ID"].Value),
                    CustomerId = Convert.ToInt32(dgvAppointmentMGMT.CurrentRow.Cells["Customer ID"].Value),
                    CustomerName = dgvAppointmentMGMT.CurrentRow.Cells["Customer Name"].Value.ToString(),
                    UserId = AppSession.CurrentUserId,
                    User = AppSession.CurrentUserName,
                    Title = dgvAppointmentMGMT.CurrentRow.Cells["Title"].Value.ToString(),
                    Description = dgvAppointmentMGMT.CurrentRow.Cells["Description"].Value.ToString(),
                    Location = dgvAppointmentMGMT.CurrentRow.Cells["Location"].Value.ToString(),
                    Contact = dgvAppointmentMGMT.CurrentRow.Cells["Contact"].Value.ToString(),
                    Type = dgvAppointmentMGMT.CurrentRow.Cells["Type"].Value.ToString(),
                    StartDateTime = (DateTime)dgvAppointmentMGMT.CurrentRow.Cells["Start Date/Time"].Value,
                    EndDateTime = (DateTime)dgvAppointmentMGMT.CurrentRow.Cells["End Date/Time"].Value

                };

                UpdateAppointment updateAppointment = new UpdateAppointment(selectedAppointment);
                updateAppointment.Show();
                this.Hide();
            }
        }
        private void LoadAddAppointmentForm()
        {
            if (dgvCustomerMGMT.CurrentRow == null || !dgvCustomerMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a customer to begin adding an appointment.");
                return;
            }
            else
            {
                var selectedCustomer = new Appointment
                {

                    CustomerId = Convert.ToInt32(dgvCustomerMGMT.CurrentRow.Cells["ID"].Value),
                    CustomerName = dgvCustomerMGMT.CurrentRow.Cells["Name"].Value.ToString(),
                    UserId = AppSession.CurrentUserId,
                    User = AppSession.CurrentUserName

                };

                AddAppointment addAppointment = new AddAppointment(selectedCustomer);
                addAppointment.Show();
                this.Hide();
            }
        }
        private void DeleteCustomer()
        {
            if (dgvCustomerMGMT.CurrentRow == null || !dgvCustomerMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer forever?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int dgvCustomerMGMTcustomerId = Convert.ToInt32(dgvCustomerMGMT.CurrentRow.Cells["ID"].Value);

                    int addressId = -1;
                    string queryDeleteAddressRow = "DELETE FROM address WHERE addressId = @addressId;";
                    string queryDeleteCustomerRow = "DELETE FROM customer WHERE customerId = @customerId;";
                    string queryGetAddressId = "SELECT addressId FROM customer WHERE customerId = @customerId;";

                    foreach (DataGridViewRow row in dgvAppointmentMGMT.Rows)
                    {
                        int dgvAppointmentMGMTcustomerId = Convert.ToInt32(row.Cells["Customer ID"].Value);
                        if (dgvCustomerMGMTcustomerId == dgvAppointmentMGMTcustomerId)
                        {
                            MessageBox.Show("You cannot delete this customer, as they are associated with an appointment!");
                            return;
                        }

                    }

                    using (MySqlCommand cmdGetAddressId = new MySqlCommand(queryGetAddressId, DBConnection.Conn))
                    {
                        cmdGetAddressId.Parameters.AddWithValue("@customerId", dgvCustomerMGMTcustomerId);
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
                        using (MySqlCommand cmdAddress = new MySqlCommand(queryDeleteCustomerRow, DBConnection.Conn))
                        {
                            cmdAddress.Parameters.AddWithValue("@customerId", dgvCustomerMGMTcustomerId);
                            cmdAddress.ExecuteNonQuery();
                        }
                        using (MySqlCommand cmdCustomer = new MySqlCommand(queryDeleteAddressRow, DBConnection.Conn))
                        {
                            cmdCustomer.Parameters.AddWithValue("@addressId", addressId);
                            cmdCustomer.ExecuteNonQuery();
                        }
                    }
                    LoadCustomerData();
                    LoadAppointmentData();
                    dgvCustomerMGMT.ClearSelection();
                    dgvAppointmentMGMT.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void LoadUpdateCustomerForm()
        {
            if (dgvCustomerMGMT.CurrentRow == null || !dgvCustomerMGMT.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a customer to update.");
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
                using (MySqlCommand cmdGetAddressId = new MySqlCommand(queryGetAddressId, DBConnection.Conn))
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

                MySqlDataAdapter adapter = new MySqlDataAdapter(customerQuery, DBConnection.Conn);

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
                string appointmentQuery = "" +
                    "SELECT \r\n" +
                    "a.appointmentId AS 'ID', \r\n" +
                    "a.customerId AS 'Customer ID', \r\n" +
                    "c.customerName AS 'Customer Name', \r\n" +
                    "a.userId AS 'User ID', \r\n" +
                    "a.title AS 'Title', \r\n" +
                    "a.description AS 'Description', \r\n" +
                    "a.location AS 'Location', \r\n" +
                    "a.contact AS 'Contact', \r\n" +
                    "a.type AS 'Type', \r\n" +
                    "a.start AS 'Start Date/Time', \r\n" +
                    "a.end AS 'End Date/Time' \r\n" +
                    "FROM appointment a\r\n" +
                    "INNER JOIN customer c ON a.customerId = c.customerId;";

                using (MySqlCommand cmd = new MySqlCommand(appointmentQuery, DBConnection.Conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (row["Start Date/Time"] is DateTime utcStart)
                            {
                                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            }

                            if (row["End Date/Time"] is DateTime utcEnd)
                            {
                                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);
                            }
                        }
                        dgvAppointmentMGMT.DataSource = table;
                        dgvAppointmentMGMT.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }
        private void CheckUpcomingAppointments(int userId)
        {
            try
            {
                DateTime nowUtc = DateTime.UtcNow;
                string queryCheckAppointments = @"
                        SELECT * FROM appointment
                        WHERE userId = @userId
                        AND TIMESTAMPDIFF(MINUTE, @now, start) BETWEEN 0 AND 15
                        ;";

                using (MySqlCommand cmd = new MySqlCommand(queryCheckAppointments, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@now", nowUtc);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int apptId = reader.GetInt32("appointmentId");
                            DateTime apptTimeUtc = reader.GetDateTime("start");
                            DateTime apptLocal = apptTimeUtc.ToLocalTime();
                            string apptTitle = reader.GetString("title");
                            int minutesUntil = (int)(apptTimeUtc - nowUtc).TotalMinutes;

                            MessageBox.Show(
                                            $"You have an upcoming appointment (ID: {apptId}, Title: {apptTitle}) starting at {apptLocal:t} — in {minutesUntil} minutes.",
                                            "Upcoming Appointment");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void LoadAppointmentBySelectedDate()
        {
            try
            {
                DateTime selectedDate = mnthCalendarAppointments.SelectionStart;
                DateTime startOfDay = selectedDate;
                DateTime endOfDay = selectedDate.AddDays(1).AddTicks(-1);

                string appointmentQuery = ""
                    + "SELECT \r\n"
                    + "a.appointmentId AS 'ID', \r\n"
                    + "a.customerId AS 'Customer ID', \r\n"
                    + "c.customerName AS 'Customer Name', \r\n"
                    + "a.userId AS 'User ID', \r\n"
                    + "a.title AS 'Title', \r\n"
                    + "a.description AS 'Description', \r\n"
                    + "a.location AS 'Location', \r\n"
                    + "a.contact AS 'Contact', \r\n"
                    + "a.type AS 'Type', \r\n"
                    + "a.start AS 'Start Date/Time', \r\n"
                    + "a.end AS 'End Date/Time' \r\n"
                    + "FROM appointment a\r\n"
                    + "INNER JOIN customer c ON a.customerId = c.customerId \r\n"
                    + "WHERE a.start BETWEEN @startOfDay AND @endOfDay;";

                using (MySqlCommand cmd = new MySqlCommand(appointmentQuery, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@startOfDay", startOfDay);
                    cmd.Parameters.AddWithValue("@endOfDay", endOfDay);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            if (row["Start Date/Time"] is DateTime utcStart)
                            {
                                row["Start Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            }

                            if (row["End Date/Time"] is DateTime utcEnd)
                            {
                                row["End Date/Time"] = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);
                            }
                        }
                        dgvAppointmentMGMT.DataSource = table;
                        dgvAppointmentMGMT.ClearSelection();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }
    }
}
