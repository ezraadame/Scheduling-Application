using C969_Scheduling_App.Database;
using C969_Scheduling_App.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App.Forms
{

    public partial class UpdateAppointment : Form
    {
        private readonly Appointment _appointment;
        public UpdateAppointment(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
        }

        private void UpdateAppointment_Load(object sender, EventArgs e)
        {
            txtAppointmentId.Text = _appointment.AppointmentId.ToString();
            txtCustomerId.Text = _appointment.CustomerId.ToString();
            txtCustomerName.Text = _appointment.CustomerName.ToString();
            txtUserId.Text = _appointment.UserId.ToString();
            txtTitle.Text = _appointment.Title.ToString();
            txtDescription.Text = _appointment.Description.ToString();
            txtLocation.Text = _appointment.Location.ToString();
            txtContact.Text = _appointment.Contact.ToString();
            txtType.Text = _appointment.Type.ToString();
            dtpStartDateTime.Format = DateTimePickerFormat.Custom;
            dtpStartDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpStartDateTime.Value = _appointment.StartDateTime;
            dtpEndDateTime.Format = DateTimePickerFormat.Custom;
            dtpEndDateTime.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpEndDateTime.Value = _appointment.EndDateTime;
            DtpStartDateTime_ValueChanged(null, null);
            DtpEndDateTime_ValueChanged(null, null);
        }


        private void BtnUpdateCustomerSave_Click(object sender, EventArgs e)
        {
            
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternStartTime = TimeZoneInfo.ConvertTime(dtpStartDateTime.Value, TimeZoneInfo.Local, easternZone);
            DateTime easternEndTime = TimeZoneInfo.ConvertTime(dtpEndDateTime.Value, TimeZoneInfo.Local, easternZone);

            DateTime utcStartTime = TimeZoneInfo.ConvertTimeToUtc(easternStartTime, easternZone);
            DateTime utcEndTime = TimeZoneInfo.ConvertTimeToUtc(easternEndTime, easternZone);

            TimeSpan businessStart = TimeSpan.FromHours(9);
            TimeSpan businessEnd = TimeSpan.FromHours(17);

            string appointmentId = txtAppointmentId.Text.Trim();
            
            
            string title = txtTitle.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContact.Text.Trim();
            string type = txtType.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime now = DateTime.Now;
            string user = _appointment.User.ToString();

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
                    return;
                }
                else if (easternEndTime.TimeOfDay < businessStart || easternEndTime.TimeOfDay > businessEnd)
                {
                    MessageBox.Show("Please select a start time between 9 AM and 5 PM in Eastern Time");
                    return;
                }

                else if (easternStartTime.ToString("yyyy-MM-dd HH:mm") == easternEndTime.ToString("yyyy-MM-dd HH:mm") || easternStartTime > easternEndTime)
                {
                    MessageBox.Show("Start Date/Time cannot be greater than or equal too End Date/Time.");
                    return;
                }

                else
                {
                    bool overlaps = false;
                    string queryOverlapCheck = @"
                            SELECT * FROM appointment
                            WHERE @start < end AND @end > start;";

                    using (MySqlCommand cmd = new MySqlCommand(queryOverlapCheck, DBConnection.conn))
                    {
                        cmd.Parameters.AddWithValue("@start", utcStartTime);
                        cmd.Parameters.AddWithValue("@end", utcEndTime);

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

                    string queryUpdateAppointments = "" +
                        "UPDATE appointment " +
                        "SET title = @title, " +
                        "description = @description, " +
                        "location = @location, " +
                        "contact = @contact, " +
                        "type = @type, " +
                        "start = @start, " +
                        "end = @end, " +
                        "lastUpdate = @lastUpdate, " +
                        "lastUpdateBy = @lastUpdateBy " +
                        "WHERE appointmentId = @appointmentId;";

                    using (MySqlCommand cmd = new MySqlCommand(queryUpdateAppointments, DBConnection.conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@start", utcStartTime);
                        cmd.Parameters.AddWithValue("@end", utcEndTime);
                        cmd.Parameters.AddWithValue("@lastUpdate", now);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", user);
                        cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Appointment updated succesfully.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void BtnUpdateCustomerCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void DtpStartDateTime_ValueChanged(object sender, EventArgs e)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime localTime = dtpStartDateTime.Value;
            DateTime easternTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, easternZone);

            lblEasternStartTime.Text = $"EST: {easternTime:MM/dd/yyyy hh:mm tt}";
        }

        private void DtpEndDateTime_ValueChanged(object sender, EventArgs e)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime localTime = dtpEndDateTime.Value;
            DateTime easternTime = TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, easternZone);

            lblEasternEndTime.Text = $"EST: {easternTime:MM/dd/yyyy hh:mm tt}";
        }
    }
}
