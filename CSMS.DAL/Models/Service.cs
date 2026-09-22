using System;
using System.Collections.Generic;
using System.Text;

namespace CSMS.DAL.Models
{
    public class Service
    {
        public int ServiceId{ get; set; }
        public DateTime ServiceDate{ get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VisitId{ get; set; }
        public Visit Visit{ get; set; }


    }
}
