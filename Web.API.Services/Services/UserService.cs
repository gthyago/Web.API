using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Services.DTO;
using Web.API.Services.Interfaces;

namespace Web.API.Services.Services
{
    internal class UserService: IUserService
    {
        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await  _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuáro cadastrado com o e-mail informado.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> PasswordValidation(UserDTO userDTO)
        {
            var user = userDTO;

            user.Password


            if (userExists != null)
                throw new DomainException("Já existe um usuáro cadastrado com o e-mail informado.");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }
    }
}
