using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string  Full_name{ get; set; }
        public String Email { get; set; }
        public String Phone_number { get; set; }
        public string Facultly { get; set; }
        public int Years_of_experince  { get; set; }
        public DateOnly Starting_work_date { get; set; }
        public decimal salary { get; set; }
        public service_branches ? Manager_Branch { get; set; }
        public int BranchId { get; set; }
        public service_branches Branch { get; set; }
        public List<service> Services { get; set; }
    }
}
