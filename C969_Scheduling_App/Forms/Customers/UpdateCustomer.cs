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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            //txtUpdateCustomerID =
            //txtUpdateCustomerName =
            //txtUpdateCustomerAddress =
            //txtUpdateCustomerNumber =
            //cmbUpdateCustomerCity =
            //cmbUpdateCustomerCountry =
        }

        private void btnUpdateCustomerCancel_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Hide();
        }

        private void btnUpdateCustomerSave_Click(object sender, EventArgs e)
        {

        }

        
    }
}
