using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_App.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }

        public User(int userID, string userName, string password, int active, DateTime createdDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            Active = active;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
        }

    }
}
