using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.API.Domain;
using Web.API.Service.DTO;
using Web.API.Service.Interfaces;

namespace Web.API.Service
{
    public class UserService : IUserService
    {         
        public async Task<bool> ValidatePassword(UserDTO userDTO)
        {
            if (userDTO.Password.Trim().Length < 9)
            {
                return false;
            }

            bool hasDigit = false;
            bool hasLowerCase = false;
            bool hasUpperCase = false;
            bool hasSpecialChar = false;
            string specialChars = "!@#$%^&*()-+";

            foreach (char c in userDTO.Password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                else if (char.IsLower(c)) hasLowerCase = true;
                else if (char.IsUpper(c)) hasUpperCase = true;
                else if (specialChars.Contains(c)) hasSpecialChar = true;

                //Se todos cenários forem atendidos, podemos parar a verificação
                if (hasDigit && hasLowerCase && hasUpperCase && hasSpecialChar)
                {
                    return true;
                }
            }

            return hasDigit && hasLowerCase && hasUpperCase && hasSpecialChar;
        }
    }
}
