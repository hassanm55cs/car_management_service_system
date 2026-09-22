using System;
using System.Collections.Generic;
using System.Text;

namespace CSMS.DAL.Models
{
    public class ServiceByKmProduct
    {
        public int serviceByKmId { get; set; }
        public ServiceByKm serviceByKm { get; set; }
        public int productId{ get; set; }
        public Product product{ get; set; }

    }
}
