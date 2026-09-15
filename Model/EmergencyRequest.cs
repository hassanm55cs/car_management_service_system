using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class EmergencyRequest
    {
        public int EmergencyRequestId { get; set; }
        public DateTime EmergenctTime{ get; set; }
        public string Car_LicencePlate{ get; set; }
        public Car CarRequest{ get; set; }
   
        public int DriverId{ get; set; }
        public Driver Driver{ get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
