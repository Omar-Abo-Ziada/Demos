namespace MyResturants.Domain.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }

    public int? KiloCalories { get; set; }

    public Resturant Resturant { get; set; } = null!;  //Very Important Note = new(); => this caused me many problem in mapping because it always init with new obj and the nav prop has priority on FK so it reslut creating new resturtant and attach the created dish into it instead of linking it with the resturant FK
    public int ResturantId { get; set; }
}