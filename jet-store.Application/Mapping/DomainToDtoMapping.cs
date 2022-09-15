using AutoMapper;
using jet_store.Application.DTOs;
using jet_store.Domain.Entities;

namespace jet_store.Application.Mapping;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Product, ProductDto>();
    }
}