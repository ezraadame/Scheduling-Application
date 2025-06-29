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

            ConfigureGrid(dgvNumberApptsTypeByMonth);
            dtpNumApptTypeByMonth.Format = DateTimePickerFormat.Custom;
            dtpNumApptTypeByMonth.CustomFormat = "MMMM yyyy";
            dtpNumApptTypeByMonth.ShowUpDown = true;
            LoadNumberOfTypesByMonth();
            dgvNumberApptsTypeByMonth.ClearSelection();

            ConfigureGrid(dgvSchedulePerUser);
            LoadUserChoices();
            dgvSchedulePerUser.ClearSelection();

            ConfigureGrid(dgvNumberApptLocationsByMonth);
            dtpNumberOfAppointmentLocationsByMonth.Format = DateTimePickerFormat.Custom;
            dtpNumberOfAppointmentLocationsByMonth.CustomFormat = "MMMM yyyy";
            dtpNumberOfAppointmentLocationsByMonth.ShowUpDown = true;
            LoadNumberOfApptLocationsByMonth();
            dgvNumberApptLocationsByMonth.ClearSelection();

            //Lambda Expression for my combobox regarding the report for the schedule of users.
            //This handles the dgv when the user selects a user from the combobox.
            cmbBoxUserChoice.SelectedIndexChanged += (s, args) =>
            {
                if (cmbBoxUserChoice.SelectedValue is int selectedUserId)
                {
                    LoadUserSchedule(selectedUserId);
                }
            };
            //

            //Lambda Expression for my report of number of appointment types by month.
            //This handles my DateTimePicker and loads the current month selected in the DTP using my LoadNumberOfTypesByMonth method. 
            dtpNumApptTypeByMonth.ValueChanged += (s, args) => LoadNumberOfTypesByMonth();
            //

            //Lambda Expression for my report of number of appointment locations by month.
            //This handles my DTP when the user selects their chosen month.
            //My method LoadNumberOfApptLocationsByMonth, will load the DGV.
            dtpNumberOfAppointmentLocationsByMonth.ValueChanged += (s, args) => LoadNumberOfApptLocationsByMonth();
            //
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }
        private void ConfigureGrid(DataGridView grid)
        {
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
        }
        private void LoadUserChoices()
        {
            try
            {
                string queryAllUsers = "SELECT userId, userName FROM user;";
                using (MySqlCommand cmd = new MySqlCommand(queryAllUsers, DBConnection.Conn))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    cmbBoxUserChoice.DisplayMember = "userName";
                    cmbBoxUserChoice.ValueMember = "userId";
                    cmbBoxUserChoice.DataSource = dt;

                    if (dt.Rows.Count > 0 && dt.Rows[0]["userId"] is int userId)
                    {
                        LoadUserSchedule(userId);
                    }
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
                    SELECT appointmentId, title AS 'Title', start AS 'Start Date/Time', end AS 'End Date/Time'
                    FROM appointment
                    WHERE userId = @userId
                    ORDER BY start;";

                using (MySqlCommand cmd = new MySqlCommand(queryUserSchedules, DBConnection.Conn))
                {
                    cmd.Parameters.AddWithValue("@userId", selectedUserId);

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
                string queryTypeAndCount = @"
                    SELECT type AS Type, COUNT(*) AS Count
                    FROM appointment
                    WHERE start BETWEEN @firstDayOfMonth AND @lastDayOfMonth
                    Group By type;
                    ";

                using (MySqlCommand cmd = new MySqlCommand(queryTypeAndCount, DBConnection.Conn))
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
        private void LoadNumberOfApptLocationsByMonth()
        {
            DateTime selectedMonth = dtpNumberOfAppointmentLocationsByMonth.Value;
            DateTime firstDayOfMonth = new DateTime(selectedMonth.Year, selectedMonth.Month, 1);
            DateTime firstDayOfNextMonth = firstDayOfMonth.AddMonths(1);
            DateTime lastDayOfMonth = firstDayOfNextMonth.AddTicks(-1);
            try
            {
                string queryTypeAndCount = @"
                    SELECT location AS Location, COUNT(*) AS Count
                    FROM appointment
                    WHERE start BETWEEN @firstDayOfMonth AND @lastDayOfMonth
                    Group By location;
                    ";

                using (MySqlCommand cmd = new MySqlCommand(queryTypeAndCount, DBConnection.Conn))
                {

                    cmd.Parameters.AddWithValue("@firstDayOfMonth", firstDayOfMonth.ToUniversalTime());
                    cmd.Parameters.AddWithValue("@lastDayOfMonth", lastDayOfMonth.ToUniversalTime());

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNumberApptLocationsByMonth.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
