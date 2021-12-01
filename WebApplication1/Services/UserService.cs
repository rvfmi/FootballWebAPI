﻿using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Infrastructure.ModelsDTO.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Database;

namespace WebApplication1.Services
{
    public class UserService : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;

        public UserService(DatabaseContext databaseContext, IMapper mapper, IPasswordHasher<User> hasher)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _hasher = hasher;
        }


        public async Task Login(LoginUserDTO loginUser)
        {
            if (!loginUser.Email.Contains("@"))
                throw new Exception();
            var userFromDb = await _databaseContext.users.SingleOrDefaultAsync(x => x.Email == loginUser.Email);
            if (userFromDb == null)
                throw new Exception("Wrong email");
            var result = _hasher.VerifyHashedPassword(userFromDb, userFromDb.HashedPassword, loginUser.Password);
            if (result != PasswordVerificationResult.Success)
                throw new Exception("Wrong password");

        }

        public async Task<User> RegisterUser(CreateUserDTO user)
        {
            if (!user.Email.Contains("@"))
                throw new Exception();
            if (user.ConfirmPassword != user.Password)
                throw new Exception();
            var userToAdd = _mapper.Map<User>(user);
            string hashedPassword = _hasher.HashPassword(userToAdd, user.Password);
            userToAdd.HashedPassword = hashedPassword;
            
            _databaseContext.users.Add(userToAdd);
            await _databaseContext.SaveChangesAsync();
            return userToAdd;
        }
    }
}