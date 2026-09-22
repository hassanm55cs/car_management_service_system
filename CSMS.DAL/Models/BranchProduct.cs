using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSMS.DAL.Models
{
    public class BranchProduct
    {
 
        public int BranchId { get; set; }

       
        public ServiceBranch Branch { get; set; } = null!;


      
        public int ProductId { get; set; }

  
        public Product Product { get; set; } = null!;


      
        public int Quantity { get; set; }
    }
}
