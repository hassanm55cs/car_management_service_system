using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateOnly StartWorkDate{ get; set; }
        public double Salary{ get; set; }
        public bool IsAvailable { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int BranchId { get; set; }
        public service_branches WorkingBranch { get; set; }
        public List<EmergencyTruck> TrucksDriven { get; set; }
        public List<EmergencyRequest> EmergencyRequests { get; set; }



    }
}
