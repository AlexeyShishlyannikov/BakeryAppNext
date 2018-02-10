using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
using NextSugarCat.Persistance;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly BakeryDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            IMapper mapper,
            BakeryDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.mapper = mapper;
            this.context = context;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return Ok(await GenerateJwtToken(model.Email, appUser));
            }

            //throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = mapper.Map<RegisterDTO, IdentityUser>(model);
            user.UserName = user.Email;
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                //throw new ApplicationException("FAILED_REGISTRATION");
                return BadRequest(result);
            await userManager.AddToRoleAsync(user, "Client");
            var client = mapper.Map<RegisterDTO, Client>(model);
            client.IdentityId = user.Id;
            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();

            await signInManager.SignInAsync(user, false);
            //return Ok(result1);
            return Ok(await GenerateJwtToken(model.Email, user));
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtAudience"],
                claims.ToArray(),
                expires: expires,
                signingCredentials: creds
            );
            var tokenObject = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return tokenObject;
        }
    }
}
