namespace FreshVegCart.Api.Data.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string ImageUrl { get; set; } = string.Empty;

    [Column(TypeName = DatabaseConstants.DecimalType)]
    public decimal Price { get; set; }

    [Required, StringLength(10)]
    public string Unit { get; set; } = string.Empty;

    public static Product[] GetSeedData()
    {
        const string ImageUrlPrefix = "https://raw.githubusercontent.com/Abhayprince/Images-Icons/refs/heads/main/Vegetables/";

        Product[] products =
        [
            new()
            {
                Name = "Avocado",
                ImageUrl = $"{ImageUrlPrefix}avocado.png",
                Unit = "each",
                Price = 1.99m
            },
            new()
            {
                Name = "Beet",
                ImageUrl = $"{ImageUrlPrefix}beet.png",
                Unit = "each",
                Price = 0.99m
            },
            new()
            {
                Name = "Bell Pepper",
                ImageUrl = $"{ImageUrlPrefix}bell_pepper.png",
                Unit = "each",
                Price = 1.50m
            },
            new()
            {
                Name = "Broccoli",
                ImageUrl = $"{ImageUrlPrefix}broccoli.png",
                Unit = "each",
                Price = 2.00m
            },
            new()
            {
                Name = "Cabbage",
                ImageUrl = $"{ImageUrlPrefix}cabbage.png",
                Unit = "each",
                Price = 1.20m
            },
            new()
            {
                Name = "Capsicum",
                ImageUrl = $"{ImageUrlPrefix}capsicum.png",
                Unit = "each",
                Price = 1.80m
            },
            new()
            {
                Name = "Carrot",
                ImageUrl = $"{ImageUrlPrefix}carrot.png",
                Unit = "kg",
                Price = 0.80m
            },
            new()
            {
                Name = "Cauliflower",
                ImageUrl = $"{ImageUrlPrefix}cauliflower.png",
                Unit = "each",
                Price = 2.50m
            },
            new()
            {
                Name = "Coriander",
                ImageUrl = $"{ImageUrlPrefix}coriander.png",
                Unit = "bunch",
                Price = 0.70m
            },
            new()
            {
                Name = "Corn",
                ImageUrl = $"{ImageUrlPrefix}corn.png",
                Unit = "each",
                Price = 1.00m
            },
            new()
            {
                Name = "Cucumber",
                ImageUrl = $"{ImageUrlPrefix}cucumber.png",
                Unit = "each",
                Price = 0.90m
            },
            new()
            {
                Name = "Eggplant",
                ImageUrl = $"{ImageUrlPrefix}eggplant.png",
                Unit = "each",
                Price = 1.75m
            },
            new()
            {
                Name = "Farmer",
                ImageUrl = $"{ImageUrlPrefix}farmer.png",
                Unit = "each",
                Price = 5.00m
            },
            new()
            {
                Name = "Ginger",
                ImageUrl = $"{ImageUrlPrefix}ginger.png",
                Unit = "kg",
                Price = 2.20m
            },
            new()
            {
                Name = "Green Beans",
                ImageUrl = $"{ImageUrlPrefix}green_beans.png",
                Unit = "kg",
                Price = 1.60m
            },
            new()
            {
                Name = "Ladyfinger",
                ImageUrl = $"{ImageUrlPrefix}ladyfinger.png",
                Unit = "kg",
                Price = 1.10m
            },
            new()
            {
                Name = "Lettuce",
                ImageUrl = $"{ImageUrlPrefix}lettuce.png",
                Unit = "each",
                Price = 1.30m
            },
            new()
            {
                Name = "Mushroom",
                ImageUrl = $"{ImageUrlPrefix}mushroom.png",
                Unit = "kg",
                Price = 2.80m
            },
            new()
            {
                Name = "Onion",
                ImageUrl = $"{ImageUrlPrefix}onion.png",
                Unit = "kg",
                Price = 0.60m
            },
            new()
            {
                Name = "Pea",
                ImageUrl = $"{ImageUrlPrefix}pea.png",
                Unit = "kg",
                Price = 1.40m
            },
            new()
            {
                Name = "Potato",
                ImageUrl = $"{ImageUrlPrefix}potato.png",
                Unit = "kg",
                Price = 0.50m
            },
            new()
            {
                Name = "Pumpkin",
                ImageUrl = $"{ImageUrlPrefix}pumpkin.png",
                Unit = "each",
                Price = 3.00m
            },
            new()
            {
                Name = "Radish",
                ImageUrl = $"{ImageUrlPrefix}radish.png",
                Unit = "bunch",
                Price = 0.85m
            },
            new()
            {
                Name = "Red Chili",
                ImageUrl = $"{ImageUrlPrefix}red_chili.png",
                Unit = "kg",
                Price = 1.50m
            },
            new()
            {
                Name = "Spinach",
                ImageUrl = $"{ImageUrlPrefix}spinach.png",
                Unit = "bunch",
                Price = 1.20m
            },
            new()
            {
                Name = "Tomato",
                ImageUrl = $"{ImageUrlPrefix}tomato.png",
                Unit = "kg",
                Price = 0.95m
            },
            new()
            {
                Name = "Turnip",
                ImageUrl = $"{ImageUrlPrefix}turnip.png",
                Unit = "each",
                Price = 0.75m
            },
            new()
            {
                Name = "Vegetables",
                ImageUrl = $"{ImageUrlPrefix}vegetables.png",
                Unit = "each",
                Price = 4.00m
            },
            new()
            {
                Name = "Yellow Capsicum",
                ImageUrl = $"{ImageUrlPrefix}yellow_capsicum.png",
                Unit = "each",
                Price = 1.80m
            }
        ];

        return products;
    }
}
