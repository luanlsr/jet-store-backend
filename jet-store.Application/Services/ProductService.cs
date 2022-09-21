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
        var products = await _repository.GetAllAsync();
        return ResultService.Ok<ICollection<ProductDto>>(_mapper.Map<ICollection<ProductDto>>(products));
    }

    public async Task<ResultService<ProductDto>> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null)
        {
            return ResultService.Fail<ProductDto>("Produto não encontrado.");
        }
        return ResultService.Ok<ProductDto>(_mapper.Map<ProductDto>(product));
    }

    public async Task<ResultService> UpdateAsync(ProductDto productDto)
    {
        if (productDto == null)
        {
            return ResultService.Fail("Objeto deve ser informado.");
        }

        var validation = new ProductDtoValidator().Validate(productDto);
        if (!validation.IsValid)
        {
            return ResultService.RequestError("Problema com a validação dos campos.", validation);
        }
        var product = await _repository.GetByIdAsync(productDto.Id);
        if (product == null)
        {
            return ResultService.Fail("Produto não encontrado.");
        }

        product = _mapper.Map<ProductDto, Product>(productDto, product);
        await _repository.UpdateAsync(product);
        return ResultService.Ok("Produto atualizado com sucesso.");
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null)
        {
            return ResultService.Fail("Produto não encontrado.");
        }

        await _repository.DeleteAsync(product);
        return ResultService.Ok("Produto deletado com sucesso.");
    }
}