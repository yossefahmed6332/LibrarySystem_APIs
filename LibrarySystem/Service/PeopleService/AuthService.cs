using LibrarySystem.DTOs.People.CustomerDtos;
using LibrarySystem.DTOs.People.EmployeesDtos;
using LibrarySystem.DTOs.People.PersonDtos;
using LibrarySystem.Interfaces.PeopleIServices;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace LibrarySystem.Service.PeopleService
{
    public class AuthService : IAuthService

    {
        private readonly UserManager<User> _userManager; 
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> _userManager, IConfiguration _configuration)
        {
            this._userManager = _userManager;
            this._configuration = _configuration;
        }
        public async Task<string> LoginUserAsync(string email, string password)
        {
            var user =await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("you have an inaccurate data , check email and password then try again");
            }

            var isValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isValid)
            {
                throw new Exception("you have an inaccurate data , check email and password then try again ");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var token = await GenerateTokenAsync(user);

            return token;
          


        }
      

        public async Task RegisterCustomerAsync(CreateCustomerDto dto)
        {
            var user = new Customer
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                MembershipType = dto.MembershipType,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to register customer");
            }
            await _userManager.AddToRoleAsync(user, "Customer");
        }

        public async Task RegisterEmployeeAsync(CreateEmployeeDto dto)
        {
            var user = new Employee
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role,
                SalaryPerHour = dto.SalaryPerHour,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to register employee");
            }
            await _userManager.AddToRoleAsync(user, "Employee");
        }

        public async Task<string> GenerateTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName!),
        new Claim(ClaimTypes.Email, user.Email!)
    };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key!)
            );

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])
                ),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
