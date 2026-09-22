using CSMS.DAL.Models;

namespace CSMS.BLL.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product product);
}
