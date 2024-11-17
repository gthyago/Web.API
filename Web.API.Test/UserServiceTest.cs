using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Web.API.Service;
using Web.API.Service.DTO;
using Xunit;

namespace Web.API.Test
{
    public class UserServiceTest
    {       
        //Validar senha deve retornar falso quando a senha for menor que 9 caracteres.
        [Fact]
        public async Task ValidatePassword_ShouldReturnFalse_WhenPasswordIsShorterThan9Characters()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "Short1!" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.False(result);
        }

        //Validar senha deve retornar falso quando a senha não tiver dígitos.
        [Fact]
        public async Task ValidatePassword_ShouldReturnFalse_WhenPasswordLacksDigit()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "NoDigits!" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.False(result);
        }

        //Validar senha deve retornar Falso quando a senha não tiver letras minúsculas.
        [Fact]
        public async Task ValidatePassword_ShouldReturnFalse_WhenPasswordLacksLowerCase()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "NOLOWERCASE1!" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.False(result);

        }

        //Validar senha deve retornar Falso quando a senha não tiver letras maiúsculas.
        [Fact]
        public async Task ValidatePassword_ShouldReturnFalse_WhenPasswordLacksUpperCase()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "nouppercase1!" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.False(result);
        }

        //Validar senha deve retornar falso quando a senha não tiver caracteres especiais.
        [Fact]
        public async Task ValidatePassword_ShouldReturnFalse_WhenPasswordLacksSpecialCharacter()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "NoSpecial1" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.False(result);
        }

        //Validate Password Should Return True When PasswordIs Valid.
        [Fact]
        public async Task ValidatePassword_ShouldReturnTrue_WhenPasswordIsValid()
        {
            // Arrange: Configure os objetos e valores necessários para o teste.
            var userDTO = new UserDTO { Password = "Valid1Password!" };
            var sut = new UserService();
            // Act: Chame o método que você está testando.
            var result = await sut.ValidatePassword(userDTO);
            // Assert: Verifique se o resultado é o esperado.
            Assert.True(result);
        }
    }
}