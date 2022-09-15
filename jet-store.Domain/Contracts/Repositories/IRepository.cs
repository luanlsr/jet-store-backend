using jet_store.Domain.Entities;

namespace jet_store.Domain.Contracts.Repositories;

public interface IRepository
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<ICollection<Product>> GetAllProductAsync();
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}