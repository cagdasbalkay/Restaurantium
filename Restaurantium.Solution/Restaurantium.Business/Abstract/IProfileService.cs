using Restaurantium.Dto.ProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IProfileService
    {
        Task<ResultProfileDto> GetUserProfileAsync(int userId);  
        Task<bool> UpdateUserProfileAsync(int userId, ResultProfileDto userProfileDto);
    }
}
