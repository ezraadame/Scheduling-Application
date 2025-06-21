using C969_Scheduling_App.Database;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dgvCustomerMGMT.RowHeadersVisible = false;
            dgvCustomerMGMT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerMGMT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerMGMT.AllowUserToResizeRows = false;
            dgvCustomerMGMT.ReadOnly = true;
            dgvCustomerMGMT.MultiSelect = false;
            dgvCustomerMGMT.AllowUserToAddRows = false;
            LoadCustomerData();

            dgvAppointmentMGMT.RowHeadersVisible = false;
            dgvAppointmentMGMT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointmentMGMT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointmentMGMT.AllowUserToResizeRows = false;
            dgvAppointmentMGMT.ReadOnly = true;
            dgvAppointmentMGMT.MultiSelect = false;
            dgvAppointmentMGMT.AllowUserToAddRows = false;
            LoadAppointmentData();
        }

        private void LoadCustomerData()
        {
            try
            {
                string query = "SELECT * FROM customer";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBConnection.conn);

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
                string query = "SELECT * FROM appointment";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, DBConnection.conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAppointmentMGMT.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed " + ex.Message);
            }
        }





        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReportsMenu_Click(object sender, EventArgs e)
        {
            Reports report = new Reports();
            report.Show();
            this.Hide();
        }

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
            this.Hide();
        }

        private void btnAppointmentUpdate_Click(object sender, EventArgs e)
        {
            ModifyAppointment modifyAppointment = new ModifyAppointment();
            modifyAppointment.Show();
            this.Hide();
        }

        private void btnCustomerAdd_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            this.Hide();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            ModifyCustomer modifyCustomer = new ModifyCustomer();
            modifyCustomer.Show();
            this.Hide();
        }

        
    }
}
