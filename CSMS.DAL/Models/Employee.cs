using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class Employee
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Facultly { get; set; } = null!;

    public int YearsOfExperince { get; set; }

    public DateOnly StartingWorkDate { get; set; }

    public decimal Salary { get; set; }

    public int BranchId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ServiceBranch Branch { get; set; } = null!;

    public virtual ServiceBranch? ServiceBranch { get; set; }

    public virtual ICollection<Visit> Services { get; set; } = new List<Visit>();
}
