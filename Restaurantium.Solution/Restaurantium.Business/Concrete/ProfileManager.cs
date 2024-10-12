using Restaurantium.Business.Abstract;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.Dto.ProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private readonly IProfileDal _profileDal;

        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public async Task<ResultProfileDto> GetUserProfileAsync(int userId)
        {
            var user = await _profileDal.GetByIdAsync(userId);  // Kullanıcıyı repository'den getir
            if (user == null) return null;

            // Kullanıcı bilgilerini DTO'ya dönüştür ve geri döndür
            return new ResultProfileDto
            {
                UserID = user.AppUserID,
                Username = user.Username,
                Password = user.Password  
            };
        }

        public async Task<bool> UpdateUserProfileAsync(int userId, ResultProfileDto userProfileDto)
        {
            var user = await _profileDal.GetByIdAsync(userId);
            if (user == null) return false;

            // Kullanıcı bilgilerini güncelle
            user.Username = userProfileDto.Username;
            user.Password = userProfileDto.Password;  // Not: Şifreyi hashlemek gerekebilir

            await _profileDal.UpdateAsync(user);  // Güncelleme işlemini repository'de gerçekleştir
            return true;
        }
    }
}
