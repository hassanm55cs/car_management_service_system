using System;
using System.Collections.Generic;

namespace CSMS.DAL.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Facultly { get; set; } = null!;

    public int YearsOfExperince { get; set; }

    public DateOnly StartingWorkDate { get; set; }

    public decimal Salary { get; set; }

    public int BranchId { get; set; }

    public virtual ServiceBranch Branch { get; set; } = null!;

    public virtual ServiceBranch? ServiceBranch { get; set; }

    public virtual ICollection<Visit> Services { get; set; } = new List<Visit>();
}
