using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Car_services.Model
{
    public class service
    {
        public int serviceId { get; set; }
        public string CarId { get; set; }
        public Car LicensePlate {  get; set; }
        public int EmployeeId { get; set; }
        public Employee Employeoe { get; set; }
        public int BranchId { get; set; }
        public service_branches Branch_of_service{ get; set; }
        public DateOnly Service_Date { get; set; }
    }
}
