using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Domain;
using Web.API.Service.DTO;

namespace Web.API.Service.Interfaces
{
    public interface IUserService
    {                
        Task<bool> ValidatePassword(UserDTO userDTO);
    }
}
