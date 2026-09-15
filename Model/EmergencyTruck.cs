using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class EmergencyTruck
    {

        public string Licence_Plate { get; set; }//primary key
        public string TruckCompany{ get; set; }

        public string TruckModel { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime StartDate { get; set; }
        public DateOnly Manufactuare_Date { get; set; }

        public int BranchId { get; set; }
        public service_branches Branch { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
     




    }
}
