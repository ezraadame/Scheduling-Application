using C969_Scheduling_App.Database;
using C969_Scheduling_App.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace C969_Scheduling_App.Forms
{
    public partial class AddAppointment : Form
    {
        private Appointment _appointment;
        public AddAppointment(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

            txtCustomerId.Text = _appointment.CustomerId.ToString();
            txtCustomerName.Text = _appointment.CustomerName.ToString();
            txtUserId.Text = _appointment.UserId.ToString();
            dtpStartDateTime.Format = DateTimePickerFormat.Custom;
            dtpStartDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpEndDateTime.Format = DateTimePickerFormat.Custom;
            dtpEndDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpStartDateTime_ValueChanged(null, null);
            dtpEndDateTime_ValueChanged(null, null);

        }


        private void btnAddCustomerSave_Click(object sender, EventArgs e)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternStartTime = TimeZoneInfo.ConvertTime(dtpStartDateTime.Value, TimeZoneInfo.Local, easternZone);
            DateTime easternEndTime = TimeZoneInfo.ConvertTime(dtpEndDateTime.Value, TimeZoneInfo.Local, easternZone);

            DateTime selectedStartTime = dtpStartDateTime.Value;
            DateTime selectedEndTime = dtpEndDateTime.Value;

            TimeSpan businessStart = TimeSpan.FromHours(9);
            TimeSpan businessEnd = TimeSpan.FromHours(17);

            string customerId = txtCustomerId.Text.Trim();
            string userId = txtUserId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContact.Text.Trim();
            string type = txtType.Text.Trim();
            string url = "";
            string description = txtDescription.Text.Trim();
            DateTime now = DateTime.Now;
            string user = _appointment.User.ToString();
            string userLastUpdated = _appointment.User.ToString();

            try
            {
                if (
                    string.IsNullOrEmpty(title) ||
                    string.IsNullOrEmpty(location) ||
                    string.IsNullOrEmpty(contact) ||
                    string.IsNullOrEmpty(type) ||
                    string.IsNullOrEmpty(description) ||
                    dtpStartDateTime.Checked == false ||
                    dtpEndDateTime.Checked == false
                    )
                {
                    MessageBox.Show("Please fill in all required fields.",
                        "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (easternStartTime.DayOfWeek == DayOfWeek.Saturday || easternStartTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Please select a start time on a weekday (Monday-Friday) in Eastern Time.");
                    return;
                }
                else if (easternEndTime.DayOfWeek == DayOfWeek.Saturday || easternEndTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Please select a end time on a weekday (Monday-Friday) in Eastern Time.");
                    return;
                }

                else if (easternStartTime.TimeOfDay < businessStart || easternStartTime.TimeOfDay > businessEnd)
                {
                    MessageBox.Show("Please select a start time between 9 AM and 5 PM in Eastern Time");
                }
                else if (easternEndTime.TimeOfDay < businessStart || easternEndTime.TimeOfDay > businessEnd)
                {
                    MessageBox.Show("Please select a start time between 9 AM and 5 PM in Eastern Time");
                }

                else if (easternStartTime.ToString("yyyy-MM-dd HH:mm") == easternEndTime.ToString("yyyy-MM-dd HH:mm") || easternStartTime > easternEndTime)
                {
                    MessageBox.Show("Start Date/Time cannot be greater than or equal too End Date/Time.");
                }

                else
                {
                    bool overlaps = false;
                    string queryOverlapCheck = @"
                            SELECT * FROM appointment
                            WHERE @start < end AND @end > start;";

                    using (MySqlCommand cmd = new MySqlCommand(queryOverlapCheck, DBConnection.conn))
                    {
                        cmd.Parameters.AddWithValue("@start", easternStartTime);
                        cmd.Parameters.AddWithValue("@end", easternEndTime);

                        using (var reader = cmd.ExecuteReader())
                        {
                            overlaps = reader.HasRows;
                        }
                    }
                    if (overlaps)
                    {
                        MessageBox.Show("This appointment overlaps with an existing appointment. Select a different time frame!");
                        return;
                    }
                }


                string queryInsertIntoAppointment = @"
                        INSERT INTO appointment 
                        (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                        VALUES 
                        (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

                using (MySqlCommand cmdInsertIntoAppointment = new MySqlCommand(queryInsertIntoAppointment, DBConnection.conn))
                {
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@customerId", customerId);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@userId", userId);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@title", title);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@description", description);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@location", location);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@contact", contact);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@type", type);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@url", url);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@start", easternStartTime);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@end", easternEndTime);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@createDate", now);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@createdBy", user);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@lastUpdate", now);
                    cmdInsertIntoAppointment.Parameters.AddWithValue("@lastUpdateBy", userLastUpdated);

                    cmdInsertIntoAppointment.ExecuteNonQuery();

                    MessageBox.Show("Appointment added successfully!");
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

        private void dtpStartDateTime_ValueChanged(object sender, EventArgs e)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime localTime = dtpStartDateTime.Value;
            DateTime easternTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, easternZone);

            lblEasternStartTime.Text = $"EST: {easternTime:MM/dd/yyyy hh:mm tt}";
        }

        private void dtpEndDateTime_ValueChanged(object sender, EventArgs e)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime localTime = dtpEndDateTime.Value;
            DateTime easternTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, easternZone);

            lblEasternEndTime.Text = $"EST: {easternTime:MM/dd/yyyy hh:mm tt}";
        }
    }
}
