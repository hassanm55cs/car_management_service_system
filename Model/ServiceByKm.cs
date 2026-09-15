using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class ServiceByKm
    {
        public int ServiceByKmId { get; set; }

        public int KilometerInterval { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
