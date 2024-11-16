using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Web.API.Service.Interfaces;
using Web.API.Domain;
using Web.API.Utilities;
using Web.API.ViewModels;
using Web.API.Service.DTO;
using AutoMapper;

namespace Web.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }        

        /// <summary>
        /// Validar Senha Usuário.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Usuário
        ///     {
        ///        "name": "thyago",        
        ///        "password": "string"
        ///     }           
        ///
        /// </remarks>
        /// <param name="userViewModel"></param>
        /// <returns>Validação senha do usuário.</returns>
        /// <response code="200">Retorna senha do usuário validada.</response>
        /// <response code="401">A senha do usuário não foi validada.</response>

        [HttpPost]
        [Route("/api/v1/users/Validation")]
        public async Task<IActionResult> ValidateUser([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                if (await _userService.ValidatePassword(userDTO))
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Senha validada com sucesso!",
                        Success = true                        
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }



        //static bool IsPasswordValid(string password)
        //{
        //    if (password.Trim().Length < 9)
        //    {
        //        return false;
        //    }

        //    bool hasDigit = false;
        //    bool hasLowerCase = false;
        //    bool hasUpperCase = false;
        //    bool hasSpecialChar = false;
        //    string specialChars = "!@#$%^&*()-+";

        //    foreach (char c in password)
        //    {
        //        if (char.IsDigit(c)) hasDigit = true;
        //        else if (char.IsLower(c)) hasLowerCase = true;
        //        else if (char.IsUpper(c)) hasUpperCase = true;
        //        else if (specialChars.Contains(c)) hasSpecialChar = true;

        //        //Se todos cenários forem atendidos, podemos parar a verificação
        //        if (hasDigit && hasLowerCase && hasUpperCase && hasSpecialChar)
        //        {
        //            return true;
        //        }
        //    }

        //    return hasDigit && hasLowerCase && hasUpperCase && hasSpecialChar;

        //}

    }
}
