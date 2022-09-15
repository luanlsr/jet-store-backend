namespace jet_store.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public bool Status { get; set; }
    public decimal Price { get; set; }
    public ImageDto Image { get; set; }
}