using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Abstract;
using Restaurantium.Business.Concrete;
using Restaurantium.Dto.ProfileDtos;
using System.Security.Claims;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileManager _profileManager;

        public ProfileController(ProfileManager profileManager)
        {
            _profileManager = profileManager;
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Kullanıcı ID'sini string'den int'e dönüştür
            if (int.TryParse(userIdString, out int userId))
            {
                var userProfile = await _profileManager.GetUserProfileAsync(userId);
                if (userProfile == null) return NotFound("User not found.");
                return Ok(userProfile);
            }

            return BadRequest("Invalid user ID."); //bunu döndü
        }


        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromBody] ResultProfileDto updateUserDto)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Kullanıcı ID'sini string'den int'e dönüştür
            if (int.TryParse(userIdString, out int userId))
            {
                var result = await _profileManager.UpdateUserProfileAsync(userId, updateUserDto);
                if (!result) return BadRequest("Profile update failed.");

                return Ok("Profile updated successfully.");
            }

            return Unauthorized(); // Kullanıcı ID'si geçerli değilse Unauthorized döndür
        }


    }
}
