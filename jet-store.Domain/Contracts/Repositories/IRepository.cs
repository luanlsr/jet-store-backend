using jet_store.Domain.Entities;

namespace jet_store.Domain.Contracts.Repositories;

public interface IRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<ICollection<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}