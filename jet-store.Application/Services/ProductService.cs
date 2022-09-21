using AutoMapper;
using jet_store.Application.DTOs;
using jet_store.Application.DTOs.Validations;
using jet_store.Application.Services.Contracts;
using jet_store.Domain.Contracts.Repositories;
using jet_store.Domain.Entities;

namespace jet_store.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDto>> CreateAsync(ProductDto productDto)
    {
        if (productDto == null)
        {
            return ResultService.Fail<ProductDto>("Objeto deve ser informado");
        }
        
        var result = new ProductDtoValidator().Validate(productDto);
        if (!result.IsValid)
        {
            return ResultService.RequestError<ProductDto>("Problemas de validação", result);
        }

        var product = _mapper.Map<Product>(productDto);
        var data = await _repository.CreateAsync(product);
        return ResultService.Ok<ProductDto>(_mapper.Map<ProductDto>(data));

    }

    public async Task<ResultService<ICollection<ProductDto>>> GetAllAsync()
    {
        var products = await _repository.GetAllProductAsync();
        return ResultService.Ok<ICollection<ProductDto>>(_mapper.Map<ICollection<ProductDto>>(products));
    }

    public async Task<ResultService<ProductDto>> GetByIdAsync(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        return ResultService.Ok<ProductDto>(_mapper.Map<ProductDto>(product));
    }
}