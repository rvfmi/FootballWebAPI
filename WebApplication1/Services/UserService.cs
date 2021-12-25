using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace WebApplication1.Services
{
    public class UserService : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;
        private readonly AuthenticationSettings _authentication;

        public UserService(DatabaseContext databaseContext, IMapper mapper, IPasswordHasher<User> hasher, AuthenticationSettings authentication)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _hasher = hasher;
            _authentication = authentication;
        }

        public async Task<User> ChangePassword(ChangePasswordDTO update, string email)
        {
            //LoginUserDTO loginUser = new LoginUserDTO();
            //loginUser.Email = update.Email;
            //loginUser.Password = update.OldPassword;
            //await Login(loginUser);
            var updatepassword = await _databaseContext.users.SingleOrDefaultAsync(x => x.Email == email);
            string hashedPassword = _hasher.HashPassword(updatepassword, update.Password);
            updatepassword.HashedPassword = hashedPassword;
            await _databaseContext.SaveChangesAsync();
            return updatepassword;
        }
        public string GenerateJwtToken(LoginUserDTO loginUser)
        {
            var user = _databaseContext.users
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Email == loginUser.Email);
            if(user is null)
            {
                throw new WrongDataException("Invalid username or password");
            }
            var result = _hasher.VerifyHashedPassword(user, user.HashedPassword, loginUser.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                throw new WrongDataException("Invalid username or password");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role}"),
                new Claim("Nationality", user.Nationality)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authentication.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authentication.JwtExpireDays);

            var token = new JwtSecurityToken(_authentication.JwtIssuer,
                _authentication.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> RegisterUser(CreateUserDTO user)
        {
            var userToAdd = _mapper.Map<User>(user);
            string hashedPassword = _hasher.HashPassword(userToAdd, user.Password);
            userToAdd.HashedPassword = hashedPassword;
            
            _databaseContext.users.Add(userToAdd);
            await _databaseContext.SaveChangesAsync();
            return userToAdd;
        }
    }
}
