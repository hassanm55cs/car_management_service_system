using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class EmergencyRequest
{
    public int EmergencyRequestId { get; set; }

    public DateTime EmergenctTime { get; set; }

    public string CarLicencePlate { get; set; } = null!;

    public int DriverId { get; set; }

    public string Latitude { get; set; } = null!;

    public string Longitude { get; set; } = null!;

    public virtual Car CarLicencePlateNavigation { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;
}
