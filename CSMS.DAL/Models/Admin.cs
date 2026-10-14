using System;

namespace CSMS.DAL.Models;

public partial class Admin
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ApplicationUser User { get; set; } = null!;
}
