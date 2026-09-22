using CSMS.BLL.Interfaces;
using CSMS.DAL.Models;
using CSMS.DAL.Repositories;

namespace CSMS.BLL.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product;
    }

    public Task AddAsync(Product product)
    {
        return _productRepository.AddAsync(product);
    }
}
