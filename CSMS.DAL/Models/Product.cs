namespace CSMS.DAL.Models;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int WarrantyMonths { get; set; }

    public string? Description { get; set; }

    public List<BranchProduct> branchProducts { get; set; }
    public List<Service> services{ get; set; }
    public List<ServiceByKmProduct> serviceByKmProducts { get; set; }

}
