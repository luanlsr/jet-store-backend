using jet_store.Domain.Validations;

namespace jet_store.Domain.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
    public decimal Price { get; set; }
    public Image Image { get; set; }

    public Product(int id, string name, string description, int stock, decimal price, Image image)
    {
        Id = id;
        Name = name;
        Description = description;
        Image = image;
        Validation(name, description, stock, price);
    }

    private void Validation(string name, string description, int stock, decimal price)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(description), "Descrição deve ser informada");
        DomainValidationException.When(stock < 0, "Estoque deve ser informado");
        DomainValidationException.When(price < 0, "Preço deve ser informado");
        
        Name = name;
        Description = description;
        Stock = stock;
        Price = price;
    }
}
