using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!await dbContext.Restaurants.AnyAsync())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new(){
                Name = "Pasta Palace",
                Description = "A cozy Italian restaurant serving authentic pasta dishes.",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "contact@pasta.com",
                ContactNumber = "+1234567890",
                Dishes = [
                    new()
                    {
                        Name = "Spaghetti Carbonara",
                        Description = "Classic Roman pasta with eggs, cheese, pancetta, and pepper.",
                        Price = 12.99m,
                    },
                    new()
                    {
                        Name = "Margherita Pizza",
                        Description = "Traditional pizza with fresh tomatoes, mozzarella, and basil.",
                        Price = 10.99m,
                    }
                ],
                Address = new(){
                    City = "Rome",
                    Street = "Via Roma 123",
                    PostalCode = "00100"
                }

            },
            new(){
                Name = "Burger Haven",
                Description = "A modern burger joint with gourmet burgers and craft beers.",
                Category = "American",
                HasDelivery = true,
                ContactEmail = "text@test.com",
                ContactNumber = "+0987654321",
                Dishes = [
                    new()
                    {
                        Name = "Cheeseburger Deluxe",
                        Description = "Juicy beef patty with cheddar cheese, lettuce, tomato, and special sauce.",
                        Price = 9.99m,
                    },
                    new()
                    {
                        Name = "Veggie Burger",
                        Description = "Grilled vegetable patty with avocado, lettuce, and tomato.",
                        Price = 8.99m,
                    }
                ],
                Address = new(){
                    City = "New York",
                    Street = "Broadway 456",
                    PostalCode = "10001"
                }
            },
            new()
            {
                Name = "Sushi Spot",
                Description = "A trendy sushi bar offering a wide variety of sushi rolls and sashimi.",
                Category = "Japanese",
                HasDelivery = false,
                ContactEmail = "testhdd@jdjk.com",
                ContactNumber = "+1122334455",
                Address = new()
                {
                    City = "Tokyo",
                    Street = "Shibuya 789",
                    PostalCode = "150-0002"
                },
            }
            ];

        return restaurants;
    }
}
