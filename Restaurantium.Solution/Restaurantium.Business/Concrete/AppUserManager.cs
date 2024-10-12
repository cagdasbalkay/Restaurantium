using Restaurantium.Business.Abstract;
using Restaurantium.Business.Enums;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    
    public class AppUserManager : IAppUserService
    {
        private readonly IGenericDal<AppUser> _appUserDal;
        private readonly IGenericDal<AppRole> _appRoleDal;

        public AppUserManager(IGenericDal<AppUser> appUserDal, IGenericDal<AppRole> appRoleDal)
        {
            _appUserDal = appUserDal;
            _appRoleDal = appRoleDal;
        }

        public async Task CreateUser(ResultSignInDto createAppUserDto)
        {
            await _appUserDal.Create(new AppUser
            {
                Username = createAppUserDto.Username,
                Password = createAppUserDto.Password,
                AppRoleID = (int)RoleType.Visitor
            });
        }

        public async Task<ResultCheckAppUserDto> ResultCheckAppUserAsync(CheckAppUserDto dto)
        {
            var values = new ResultCheckAppUserDto();
            var user = await _appUserDal.GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);

            if(user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Username = dto.Username;
                values.Role = (await _appRoleDal.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).AppRoleName;
                values.ID = user.AppUserID;

            }
            return values;
            

        }
    }
}
