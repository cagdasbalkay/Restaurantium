using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Concrete.Repositories.AppUserRepositories
{
    public class ProfileRepository : IProfileDal
    {
        private readonly RestaurantiumContext _context;

        public ProfileRepository(RestaurantiumContext context)
        {
            _context = context;
        }
        public async Task<AppUser> GetByIdAsync(int userId)
        {
            return await _context.AppUsers.FindAsync(userId); 
        }

        public async Task UpdateAsync(AppUser user)
        {
            _context.AppUsers.Update(user);  // Kullanıcıyı güncelle
            await _context.SaveChangesAsync();  // Değişiklikleri kaydet
        }
    }
}
