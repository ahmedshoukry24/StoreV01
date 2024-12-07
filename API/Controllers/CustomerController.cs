using API.Helper;
using AutoMapper;
using Core.DTOs;
using Core.Entities.User;
using Core.Interfaces;
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
        private readonly IMapper _mapper;
        public CustomerController( UserManager<User> userManager, IConfiguration configuration, IMapper mapper ) {

            this._userManager = userManager;
            this._configuration = configuration;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CustomerRegister(UserRegisterDTO customerDto)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          
            User? customer = await _userManager.FindByEmailAsync(customerDto.Email);
            if (customer is not null)
            {

                IList<string> roles =await _userManager.GetRolesAsync(customer);

                if (roles.Contains("Customer"))
                    return BadRequest("Email is already registered!");
                                

                return BadRequest("Email is already registered with another role, you can login directly in customers platform!");
            }

            //if (await _userManager.FindByNameAsync(customerDto.UserName) != null)
            //    return BadRequest("UserName is already registerd!");


            customer = new Customer
            {
                UserName = customerDto.UserName,
                Email = customerDto.Email,
                //Discriminator = customerDto.Discriminator,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                PhoneNumber = customerDto.PhoneNumber
            };

            var result  = await _userManager.CreateAsync(customer, customerDto.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);

            }

            await _userManager.AddClaimsAsync(customer,new List<Claim>
            {
                new Claim(ClaimTypes.Role,"Customer"),
                new Claim(ClaimTypes.NameIdentifier,customer.Id.ToString())
            });

            await _userManager.AddToRoleAsync(customer, "Customer");

            Object tokenObject = await TokenHelper.CreateTokenObject(customer, _configuration, _userManager,customer.Id.ToString());
            return Ok(tokenObject);


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {

            // check email
            User? customer =  await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (customer == null) return BadRequest("invalid email or password!");


            // check password
            var isAuth = await _userManager.CheckPasswordAsync(customer, userLoginDto.Password);
            if (!isAuth)
                return BadRequest("invalid email or password!");


            // check role
            var roles = await _userManager.GetRolesAsync(customer);
            if (!roles.Contains("Customer"))
            {
                await _userManager.AddClaimAsync(customer, new Claim(ClaimTypes.Role, "Customer"));
                await _userManager.AddToRoleAsync(customer, "Customer");
                // TO BE ADDED::: (add foreign key in customers table)
            }


            Object tokenObject = await TokenHelper.CreateTokenObject(customer, _configuration, _userManager, customer.Id.ToString());
            return Ok(tokenObject);
        }

    }
}
