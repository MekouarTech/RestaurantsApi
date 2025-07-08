using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    //public Task AddAsync(Restaurant restaurant)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task DeleteAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    //public Task<Restaurant> GetByIdAsync(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task UpdateAsync(Restaurant restaurant)
    //{
    //    throw new NotImplementedException();
    //}
}
