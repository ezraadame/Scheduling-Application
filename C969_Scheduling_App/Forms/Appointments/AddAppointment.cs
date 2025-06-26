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
            txtCustomerName.Text= _appointment.CustomerName.ToString();
            txtUserId.Text = _appointment.UserId.ToString();
            dtpStartDateTime.Format = DateTimePickerFormat.Custom;
            dtpStartDateTime.CustomFormat = "MM/dd/yyyy hh:mm";
            dtpEndDateTime.Format = DateTimePickerFormat.Custom;
            dtpEndDateTime.CustomFormat = "MM/dd/yyyy hh:mm";
            //dtpStartDateTime.ShowUpDown = true;
        }


        private void btnAddCustomerSave_Click(object sender, EventArgs e)
        {
            
            string customerId = txtCustomerId.Text.Trim();
            //string customerName = txtCustomerName.Text.Trim();
            string userId = txtUserId.Text.Trim();
            string title = txtTitle.Text.Trim();
            string location = txtLocation.Text.Trim();
            string contact = txtContact.Text.Trim();
            string type = txtType.Text.Trim();
            string description = txtDescription.Text.Trim();
            DateTime StartTime = dtpStartDateTime.Value;
            DateTime EndTime = dtpEndDateTime.Value;
            DateTime now = DateTime.Now;

            string user = _appointment.User.ToString();

            try
            {
                if (
                    string.IsNullOrEmpty(txtTitle.Text.Trim()) ||
                    string.IsNullOrEmpty(txtLocation.Text.Trim()) ||
                    string.IsNullOrEmpty(txtContact.Text.Trim()) ||
                    string.IsNullOrEmpty(txtType.Text.Trim()) ||
                    string.IsNullOrEmpty(txtDescription.Text.Trim()) ||
                    dtpStartDateTime.Checked == false ||
                    dtpEndDateTime.Checked == false
                    )
                {
                    MessageBox.Show("Please fill in all required fields.",
                        "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string queryInsertIntoAppointment = @"
                            INSERT INTO appointment 
                            (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)
                            VALUES 
                            (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

                    using (MySqlCommand cmd = new MySqlCommand(queryInsertIntoAppointment, DBConnection.conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@url", "not needed");
                        cmd.Parameters.AddWithValue("@start", StartTime);
                        cmd.Parameters.AddWithValue("@end", EndTime);
                        cmd.Parameters.AddWithValue("@createDate", now);
                        cmd.Parameters.AddWithValue("@createdBy", user);
                        cmd.Parameters.AddWithValue("@lastUpdate", now);
                        cmd.Parameters.AddWithValue("@lastUpdateBy", user);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Appointment added successfully!");
                    }
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
