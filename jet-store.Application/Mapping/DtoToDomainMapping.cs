using AutoMapper;
using jet_store.Application.DTOs;
using jet_store.Domain.Entities;
using jet_store.Application.DTOs;

namespace jet_store.Application.Mapping;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<ProductDto, Product>();
    }
}