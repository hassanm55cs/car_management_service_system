using System.ComponentModel.DataAnnotations;

namespace CSMS.PLL.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "999999999999.99")]
    public decimal Price { get; set; }
}
