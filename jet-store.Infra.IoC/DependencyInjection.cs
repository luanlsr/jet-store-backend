using jet_store.Application.Mapping;
using jet_store.Application.Services;
using jet_store.Application.Services.Contracts;
using jet_store.Domain.Contracts.Repositories;
using jet_store.Infra.Data.Context;
using jet_store.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jet_store.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IRepository, Repository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
