using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Car_services.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Full_name { get; set; }
 
        public String Address { get; set; }
        public List<Car> Cars { get; set; }

        public List<RentedCarCustomer> CarsCustomers{ get; set; }



    }
}
