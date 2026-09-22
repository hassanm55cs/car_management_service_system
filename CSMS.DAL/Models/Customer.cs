using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<RentedCarCustomer> RentedCarCustomers { get; set; } = new List<RentedCarCustomer>();
}
