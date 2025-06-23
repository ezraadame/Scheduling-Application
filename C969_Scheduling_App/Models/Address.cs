using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Scheduling_App.Models
{
    public class Address
    {
        public int AddressID {  get; set; }
        public string AddressLine {  get; set; }
        public string AddressLine2 { get; set; }
        public int CityID { get; set; }
        public string PostalCode { get; set; }
        public string Phone {  get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate {  get; set; }
        public string LastUpdatedBy { get; set; }

        public Address(int addressID, string addressLine, string addressLine2, int cityID, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
        {
            AddressID = addressID;
            AddressLine = addressLine;
            AddressLine2 = addressLine2;
            CityID = cityID;
            PostalCode = postalCode;
            Phone = phone;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}
