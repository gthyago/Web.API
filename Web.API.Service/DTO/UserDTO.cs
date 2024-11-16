using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Service.DTO
{
    public class UserDTO
    {               
        public string Password { get; set; }

        public UserDTO()
        { }
        public UserDTO(string name, string email, string password)
        {            
            Password = password;
        }
    }
}
