using C969_Scheduling_App.Database;
using C969_Scheduling_App.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_App.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressID { get; set; }
        public string Address {  get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

        public Customer(int customerId, string customerName, int addressID, int active, DateTime createdDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressID = addressID;
            Active = active;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }

        public Customer()
        {
            
        }

    }
}
