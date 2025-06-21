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
using System.Globalization;
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

        private void Login_Load(object sender, EventArgs e)
        {
            LocalizeForm();
        }

        private void LocalizeForm()
        {
            string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (language == "es")
            {
                lblUsername.Text = "Nombre de usuario";
                lblPassword.Text = "Contrasena";
                btnSignIn.Text = "Iniciar sesion";
                lblSignIn.Text = "Iniciar sesion";
                titleSchedulingApp.Text = "Solicitud De Programacion";
            }
            else
            {
                lblUsername.Text = "Username";
                lblPassword.Text = "Password";
                btnSignIn.Text = "Sign in";
                lblSignIn.Text = "Sign in";
                titleSchedulingApp.Text = "Scheduling Application";
            }
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
                    bool loginSuccess = false;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loginSuccess = true;
                        }
                        
                    }
                    if (loginSuccess)
                    {
                        Forms.MainMenu mainMenu = new Forms.MainMenu();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                        MessageBox.Show(language == "es" ? "¡Credenciales incorrectas!" : "Wrong credentials!");
                    }
                }
            }
            catch (MySqlException)
            {
                string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                if (language == "es")
                {
                    MessageBox.Show("Error de iniciio de sesion");
                }
                else
                {
                    MessageBox.Show("Login failed");
                }
                    
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
