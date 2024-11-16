using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web.API.Services.DTO
{    
    public class UserDTO
    {
        public string Password { get; set; }
        public UserDTO()
        { }
        public UserDTO(string password)
        {
            Password = password;
        }
    }    
}
