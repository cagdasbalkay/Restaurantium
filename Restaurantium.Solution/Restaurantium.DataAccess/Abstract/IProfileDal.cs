using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IProfileDal
    {
        Task<AppUser> GetByIdAsync(int userId); // ID'ye göre kullanıcıyı getir
        Task UpdateAsync(AppUser user); // Kullanıcıyı güncelle
    }
}
