

using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Identity;
using Core.Entities.User;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using API.Helper;
using Core.DTOs.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public VendorController(UserManager<User> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<AuthResponseDto>> Register(UserRegisterDTO userRegisterDTO)
        {
            //if(!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
                var errorMessage = string.Join("; ", errors);
                return BadRequest(AuthResponseDto.ErrorResponse(errorMessage));
            }


            User? user = await _userManager.FindByEmailAsync(userRegisterDTO.Email);

            if (user is not null)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Vendor"))
                    return BadRequest("Email is already registered");
                
                
                return BadRequest("Email is already registered with another role, contact us if you want to be a vendor!");
            }

            //if (await _userManager.FindByNameAsync(userRegisterDTO.UserName) is not null)
            //    return BadRequest("Username is already registered!");

            user = new Vendor
            {
                UserName = userRegisterDTO.UserName,
                Email = userRegisterDTO.Email,
                //Discriminator = userRegisterDTO.Discriminator,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user,userRegisterDTO.Password);

            if(!result.Succeeded)
            {
                string errors = string.Empty;
                foreach(var error in result.Errors)
                {
                    //ModelState.AddModelError(string.Empty, error.Description);
                    errors = string.Join("; ", error.Description);
                }
                return BadRequest(AuthResponseDto.ErrorResponse(errors));
            }

            await _userManager.AddClaimsAsync(user, new List<Claim> {
                new Claim(ClaimTypes.Role,"Vendor"),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            });

            await _userManager.AddToRoleAsync(user, "Vendor");


            AuthResponseDto tokenObject = await TokenHelper.CreateTokenObject(user, _configuration, _userManager, user.Id);
            return Ok(tokenObject);

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponseDto>> Login(UserLoginDto userLoginDto)
        {
            // check email
            User? vendor = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (vendor == null)
                return BadRequest(AuthResponseDto.ErrorResponse("invalid email or password!"));

            // check password
            bool pass = await _userManager.CheckPasswordAsync(vendor, userLoginDto.Password);
            if (!pass)
                return BadRequest(AuthResponseDto.ErrorResponse("invalid email or password!"));

            // check role
            IList<string> roles = await _userManager.GetRolesAsync(vendor);
            if (!roles.Contains("Vendor"))
                return BadRequest(AuthResponseDto.ErrorResponse("Email is already registered with another role, contact us if you want to be a vendor!"));
            

            AuthResponseDto _authResponseDto = await TokenHelper.CreateTokenObject(vendor, _configuration, _userManager,vendor.Id);
            return Ok(_authResponseDto);
        }
    }
}
