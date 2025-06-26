using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_App.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string CustomerName { get; set; }
        public string User { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public Appointment(
                int appointmentId, int customerId, int userId, string title, string description, string location, string contact, string type, string uRL,
                DateTime start, DateTime end, DateTime createdDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            UserId = userId;
            Title = title;
            Description = description;
            Location = location;
            Contact = contact;
            Type = type;
            URL = uRL;
            Start = start;
            End = end;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }

        public Appointment()
        {

        }

    }
}
