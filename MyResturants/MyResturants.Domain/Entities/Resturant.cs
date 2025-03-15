namespace MyResturants.Domain.Entities;

public class Resturant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public bool HasDelivery { get; set; }

    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }

    public Address Address { get; set; } = new(); // Owned entity, no separate table
    public List<Dish> Dishes { get; set; } = new();

    //public User Owner { get; set; } = default!;
    //public string OwnerId { get; set; } = default!;
    //public string? LogoUrl { get; set; }
}