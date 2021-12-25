using Infrastructure.Models;
using Infrastructure.ModelsDTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
       Task<User> RegisterUser(CreateUserDTO createUserDTO);
       Task<User> ChangePassword(ChangePasswordDTO update, string email);
       string GenerateJwtToken(LoginUserDTO loginUser);



    }
}
