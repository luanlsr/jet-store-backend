using jet_store.Application.DTOs;

namespace jet_store.Application.Services.Contracts;

public interface IProductService
{
    Task<ResultService<ProductDto>> CreateAsync(ProductDto productDto);
}