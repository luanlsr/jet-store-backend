using jet_store.Domain;
using jet_store.Domain.Contracts.Repositories;
using jet_store.Domain.Entities;
using jet_store.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace jet_store.Infra.Data.Repositories;

public class Repository : IRepository
{
    private readonly ProductDbContext _db;

    public Repository(ProductDbContext db)
    {
        _db = db;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _db.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }
    
    public async Task DeleteAsync(Product product)
    {
        _db.Remove(product);
        await _db.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Product product)
    {
        _db.Update(product);
        await _db.SaveChangesAsync();
    }
    
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Product>> GetAllAsync()
    {
        return await _db.Product.ToListAsync();
    }



}