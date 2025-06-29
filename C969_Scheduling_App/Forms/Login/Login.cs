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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            GetLocation();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string queryLogin = @"SELECT * FROM user WHERE userName = @userName AND password = @password";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(queryLogin, DBConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    bool loginSuccess = false;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            loginSuccess = true;

                            int userId = reader.GetInt32("userId");
                            AppSession.CurrentUserId = userId;
                            string retrievedUserName = reader.GetString("username");
                            AppSession.CurrentUserName = retrievedUserName;
                        }
                    }
                    // Logs will be saved to user's documents folder, C:\Users\<user>\Documents\C969_Scheduling_App\Logs
                    if (loginSuccess)
                    {
                        LoginLog(loginSuccess);
                        Forms.MainMenu mainMenu = new Forms.MainMenu();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        LoginLog(loginSuccess);
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
            }
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
        private void LoginLog(bool loginSuccess)
        {
            string userName = txtUserName.Text;
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"User: {userName} has logged in at {timeStamp}";
            string failedLogEntry = $"Failed Login Attempt with User: {userName} at {timeStamp}";

            string logFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "C969_Scheduling_App",
                "Logs",
                "Login_History.txt");

            Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));

            if (loginSuccess)
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(failedLogEntry);
                }
            }
        }
        public void GetLocation()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString("http://ip-api.com/json/");
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    dynamic result = serializer.Deserialize<object>(json);

                    string country = result["country"];
                    string city = result["city"];
                    string timezone = result["timezone"];

                    lblCurrentLocation.Text = $"City: {city}" + Environment.NewLine + $"Country: {country}" + Environment.NewLine + $"Timezone: {timezone}";
                }
            }
            catch (Exception ex)
            {
                lblCurrentLocation.Text = $"Location unavailabkle, ({ex.Message})";
            }
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
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

        private void TxtPassword_TextChanged(object sender, EventArgs e)
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

        private void BtnExit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
