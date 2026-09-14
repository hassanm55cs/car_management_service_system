using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Car_services.Model
{
    public class service_branches
    {
        public int BranchId { get; set; }
        public string Branch_name { get; set; }
        public string Branch_location { get; set; }
        
        public TimeOnly Open_time { get; set; }
        public TimeOnly Close_time { get; set; }
        public DateOnly Opening_date { get; set; }

        public int ? ManagerId { get; set; }
        public Employee Manager{ get; set; }
        public List<Employee> Employees { get; set; }
        public List<service> Services { get; set; }
        public List<EmergencyTruck> Trucks{ get; set; }
        public List<Driver> Drivers { get; set; }
    }

}
