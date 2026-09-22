using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class ServiceByKm
{
    public int ServiceByKmId { get; set; }

    public int KilometerInterval { get; set; }

    public string Description { get; set; } = null!;

    public double Price { get; set; }
    public List<ServiceByKmProduct> serviceByKmProducts { get; set; }
}
