using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App.Database
{
    public static class DBConnection
    {
        public static MySqlConnection Conn { get; set; }
        public static void StartConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

                Conn = new MySqlConnection(connectionString);

                Conn.Open();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConneciton()
        {
            try
            {
                Conn?.Close();
                Conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
