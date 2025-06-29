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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            

            dgvNumberApptsTypeByMonth.RowHeadersVisible = false;
            dgvNumberApptsTypeByMonth.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNumberApptsTypeByMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNumberApptsTypeByMonth.AllowUserToResizeRows = false;
            dgvNumberApptsTypeByMonth.ReadOnly = true;
            dgvNumberApptsTypeByMonth.MultiSelect = false;
            dgvNumberApptsTypeByMonth.AllowUserToAddRows = false;
            dtpNumApptTypeByMonth.Format = DateTimePickerFormat.Custom;
            dtpNumApptTypeByMonth.CustomFormat = "MMMM yyyy";
            dtpNumApptTypeByMonth.ShowUpDown = true;

            LoadNumberOfTypesByMonth();
            dgvNumberApptsTypeByMonth.ClearSelection();

            dgvSchedulePerUser.RowHeadersVisible = false;
            dgvSchedulePerUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedulePerUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedulePerUser.AllowUserToResizeRows = false;
            dgvSchedulePerUser.ReadOnly = true;
            dgvSchedulePerUser.MultiSelect = false;
            dgvSchedulePerUser.AllowUserToAddRows = false;
            LoadUserChoices();
            dgvSchedulePerUser.ClearSelection();

            dgvNumberApptByLocation.RowHeadersVisible = false;
            dgvNumberApptByLocation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNumberApptByLocation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNumberApptByLocation.AllowUserToResizeRows = false;
            dgvNumberApptByLocation.ReadOnly = true;
            dgvNumberApptByLocation.MultiSelect = false;
            dgvNumberApptByLocation.AllowUserToAddRows = false;
            LoadNumberOfApptByLocation();
            dgvNumberApptByLocation.ClearSelection();

        }
        private void dtpNumApptTypeByMonth_ValueChanged(object sender, EventArgs e)
        {
            
            LoadNumberOfTypesByMonth();
            
        }


        private void cmbBoxUserChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxUserChoice.SelectedValue is int selectedUserId)
            {
                LoadUserSchedule(selectedUserId);
            }
        }

        private void LoadUserChoices()
        {
            try
            {
                string queryAllUsers = "SELECT userId, userName FROM user;";
                using (MySqlCommand cmd = new MySqlCommand(queryAllUsers, DBConnection.conn))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cmbBoxUserChoice.DisplayMember = "userName";
                    cmbBoxUserChoice.ValueMember = "userId";
                    cmbBoxUserChoice.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadUserSchedule(int selectedUserId)
        {
            try
            {
                string queryUserSchedules = @"
                    SELECT appointmentId, title, start, end
                    FROM appointment
                    WHERE userId = @userId
                    ORDER BY start;";

                using (MySqlCommand cmd = new MySqlCommand(queryUserSchedules, DBConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@userId", selectedUserId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {

                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dgvSchedulePerUser.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message);
            }
        }

        private void LoadNumberOfTypesByMonth()
        {

            DateTime selectedMonth = dtpNumApptTypeByMonth.Value;
            DateTime firstDayOfMonth = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
            DateTime lastDayOfMonth = firstDayOfNextMonth.AddTicks(-1);


            try
            {
                string queryTypeAndCount= @"
                    SELECT type AS Type, COUNT(*) AS Count
                    FROM appointment
                    WHERE start BETWEEN @firstDayOfMonth AND @lastDayOfMonth
                    Group By type;
                    ";

                using (MySqlCommand cmd = new MySqlCommand(queryTypeAndCount, DBConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth.ToUniversalTime());
                    cmd.Parameters.AddWithValue("@lastDayOfMonth", lastDayOfMonth.ToUniversalTime());

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNumberApptsTypeByMonth.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void LoadNumberOfApptByLocation()
        {

            try
            {
                string queryTypeAndCount = @"
                    SELECT location AS Location, COUNT(*) AS Count
                    FROM appointment
                    Group By location;
                    ";

                using (MySqlCommand cmd = new MySqlCommand(queryTypeAndCount, DBConnection.conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNumberApptByLocation.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

    }
}
