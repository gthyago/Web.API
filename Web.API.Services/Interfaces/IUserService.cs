using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Services.DTO;

namespace Web.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> PasswordValidation(UserDTO userDTO);
    }
}
