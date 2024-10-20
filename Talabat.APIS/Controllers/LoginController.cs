using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIS.DTOs;
using Talabat.APIS.Errors;
using Talabat.Core.Entities.IdentityEntities;

namespace Talabat.APIS.Controllers
{
 
    public class LoginController : BaseApiController
    {
        private readonly UserManager<AppUser>   _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController( UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
           _userManager = userManager;
           _signInManager = signInManager;
        }


        [HttpPost("Login")]
        public async Task< ActionResult<UserDto>> Login (LoginDto loginDto)  
        {
            var user= await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) { return Unauthorized(new ApiResponseError(401)); }

            var result= await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            if (result.Succeeded is false) { return Unauthorized(new ApiResponseError(401)); }

            return Ok(new UserDto
            {
                DisplayName= user.DisplayedName,
                Email=user.Email,
                Token="The Token that will be passed"
            });
        }






    }
}
