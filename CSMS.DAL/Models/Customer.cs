using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<RentedCarCustomer> RentedCarCustomers { get; set; } = new List<RentedCarCustomer>();
}
