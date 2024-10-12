using Restaurantium.Dto.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IAppUserService
    {
        Task<ResultCheckAppUserDto> ResultCheckAppUserAsync(CheckAppUserDto dto);

        Task CreateUser(ResultSignInDto createAppUserDto);
    }
}
