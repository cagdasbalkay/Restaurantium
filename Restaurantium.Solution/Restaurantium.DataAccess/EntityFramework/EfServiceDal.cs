using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;

public class EfServiceDal : GenericRepository<Service>, IServiceDal
{
    private readonly RestaurantiumContext _restaurantiumContext;

    public EfServiceDal(RestaurantiumContext context) : base(context)
    {
        _restaurantiumContext = context; 
    }

    public async Task<List<Service>> GetLast4ServicesAsync()
    {
        var values = await _restaurantiumContext.Services.Take(4).ToListAsync();
        return values;
    }
}