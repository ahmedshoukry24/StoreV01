using API.Helper;
using Core.DTOs;
using Core.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public CustomerController( UserManager<User> userManager, IConfiguration configuration ) {

            this._userManager = userManager;
            this._configuration = configuration;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userManager.FindByEmailAsync(customerDto.Email) is not null)
                return BadRequest("Email is already registerd!");

            if (await _userManager.FindByNameAsync(customerDto.UserName) != null)
                return BadRequest("UserName is already registerd!");


            var user = new User
            {
                UserName = customerDto.UserName,
                Email = customerDto.Email,
                Discriminator = customerDto.Discriminator,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber
            };

            var result  = await _userManager.CreateAsync(user, customerDto.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);

            }

            await _userManager.AddClaimsAsync(user,new List<Claim>
            {
                new Claim(ClaimTypes.Role,"Customer"),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });

            await _userManager.AddToRoleAsync(user, "Customer");

            // create token for registered customer

            IList<Claim> claims = await _userManager.GetClaimsAsync(user);
            string? issuer = _configuration.GetSection("JWT").GetValue<string>("issuer");
            string? audience = _configuration.GetSection("JWT").GetValue<string>("audience");
            DateTime expiryDate = DateTime.Now.AddDays(3);

            var key = TokenHelper.GenerateKey(_configuration);

            var token = TokenHelper.GenerateToken(key, claims, issuer, audience, expiryDate);

            return Ok(new
            {
                Token = token,
                ExpiryDate = expiryDate
            });


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
           var customer =  await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (customer == null) return BadRequest("Email is not registerd!");

            var isAuth = await _userManager.CheckPasswordAsync(customer, userLoginDto.Password);
            if (!isAuth)
                return BadRequest("Wrong Password!");

            IList<Claim> claims =  await _userManager.GetClaimsAsync(customer);
            var issuer = _configuration.GetSection("JWT").GetValue<string>("issuer");
            var audience = _configuration.GetSection("JWT").GetValue<string>("audience");

            var secretKey = TokenHelper.GenerateKey(_configuration);
            DateTime expiryDate = DateTime.Now.AddDays(3);

            var token = TokenHelper.GenerateToken(secretKey, claims, issuer, audience, expiryDate);
            return Ok(new
            {
                Token= token,
                ExpiryDate= expiryDate
            });
        }

    }
}
