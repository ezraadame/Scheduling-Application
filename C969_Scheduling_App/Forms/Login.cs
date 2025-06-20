using C969_Scheduling_App.Database;
using C969_Scheduling_App.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            
            string query = @"SELECT * FROM user WHERE userName = @userName AND password = @password";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Scheduler scheduler = new Scheduler();
                            scheduler.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong credentials!");
                        }
                    }
                }


            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
            {
                txtUserName.BackColor = Color.White;
            }
            else
            {
                txtUserName.BackColor = Color.Yellow;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
            {
                txtPassword.BackColor = Color.White;
            }
            else
            {
                txtPassword.BackColor = Color.Yellow;
            }
        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            MySqlConnection c = DBConnection.conn;

            if (c.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection open!");
            }
        }
    }
}
