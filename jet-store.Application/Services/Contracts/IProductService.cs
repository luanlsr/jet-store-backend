using jet_store.Application.DTOs;

namespace jet_store.Application.Services.Contracts;

public interface IProductService
{
    Task<ResultService<ProductDto>> CreateAsync(ProductDto productDto);
    Task<ResultService<ICollection<ProductDto>>> GetAllAsync();
    Task<ResultService<ProductDto>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(ProductDto productDto);
    Task<ResultService> DeleteAsync(int id);
}