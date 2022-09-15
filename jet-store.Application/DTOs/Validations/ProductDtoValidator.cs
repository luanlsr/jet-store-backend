using FluentValidation;

namespace jet_store.Application.DTOs.Validations;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome deve ser informado");
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Descrição deve ser informado");
        RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("Preço deve ser informado");
        RuleFor(x => x.Stock)
            .NotEmpty()
            .NotNull()
            .WithMessage("Estoque deve ser informado");
    }
}