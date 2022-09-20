using FluentValidation;

namespace jet_store.Application.DTOs.Validations;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithName("Nome")
            .WithMessage("deve ser informado");
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithName("Descrição")
            .WithMessage("deve ser informado");
        RuleFor(x => x.Price)
            .NotEmpty()
            .NotNull()
            .WithName("Preço")
            .WithMessage("deve ser informado");
        RuleFor(x => x.Stock)
            .NotEmpty()
            .NotNull()
            .WithName("Estoque")
            .WithMessage("deve ser informado");
    }
}