using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class RentedCarCustomer
    {
        public int RentedCarCustomerId { get; set; }
        public double PriceForRent { get; set; }
        public int No_ofDays_ForRent{ get; set; }
        public DateOnly RentStartDate { get; set; }
        public DateOnly RentEndDate { get; set; }
        public int CustomerId { get; set; }
        public Customer CutomeRent { get; set; }
        public string LicencsePlateRented{ get; set; }
        public CarsForRent CarRented{ get; set; }
    }
}
