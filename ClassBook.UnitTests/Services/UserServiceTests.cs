using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.Authorization.PasswordHashers;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.BLL.Services;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using ClassBook.Domain.Enums;
using ClassBook.UnitTests.Helpers;
using Microsoft.AspNetCore.Identity;
using Moq;
using FluentAssertions;
using Xunit;

namespace ClassBook.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly Mock<IGenericRepository<User>> _genericRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IPasswordHasher> _passwordHasherMock;
        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _genericRepositoryMock = new Mock<IGenericRepository<User>>();
            _userService = new UserService(_genericRepositoryMock.Object, MapperHelper.GetMapperForTests(), _userRepositoryMock.Object, _passwordHasherMock.Object);

        }

        [Fact]
        public async Task Get_By_Email_For_Valid_Data_Should_Return_UserResponseDto()
        {
            //Arrange
            var email = It.IsAny<string>();
            var user = new User();
            _userRepositoryMock.Setup(m => m.GetUserByEmail(email)).ReturnsAsync(user);

            //Act
            var result = await _userService.GetByEmail(email);

            //Assert
            result.Should().BeOfType<UserResponseDto>();
        }

        [Fact]
        public async Task Get_By_Email_For_InValid_Email_Should_Throw_NotFoundException()
        {
            //Arrange 
            var email = It.IsAny<string>();
            _userRepositoryMock.Setup(x => x.GetUserByEmail(email)).ReturnsAsync(default(User));

            //Act
            var result = async () => await _userService.GetByEmail(email);

            //Assert
            await result.Should().ThrowAsync<NotFoundException>();

        }

        [Fact]
        public async Task Get_Users_Sorted_By_Last_Name_Should_Invoke_Get_All_Users_Sorted_By_Last_Name_Async()
        {
            //Act
            var result = await _userService.GetUsersSortedByLastNameAsync();

            //Assert
            _userRepositoryMock.Verify(x => x.GetAllUsersSortedByLastNameAsync(), Times.Once);
        }

        [Fact]
        public async Task Login_For_Valid_Credentials_Should_Return_TokenDto()
        {
            //Arrange
            var loginDto = new LoginDto("email", "haslo");
            var user = new User{Password =  "hash_haslo", Email = loginDto.Email, Role = It.IsAny<Role>()};
            _userRepositoryMock.Setup(x => x.GetUserByEmail(loginDto.Email)).ReturnsAsync(user);
            _passwordHasherMock.Setup(x => x.VerifyPassword(loginDto.Password, user.Password)).Returns(true);

            //Act
            var result = await _userService.Login(loginDto, "secret_key_example");

            //Assert
            result.Should().BeOfType<TokenDto>();
        }

        [Fact]
        public async Task Login_For_InValid_Email_Should_Throw_NotFoundException()
        {
            //Arrange
            var loginDto = new LoginDto("email", "haslo");
            _userRepositoryMock.Setup(x => x.GetUserByEmail(loginDto.Email)).ReturnsAsync(default(User));

            //Act
            var result = async () => await _userService.Login(loginDto, "secret_key_example");

            //Assert
            await result.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task Login_For_InValid_Password_Should_Throw_WrongPasswordException()
        {
            //Arrange
            var loginDto = new LoginDto("email", "haslo");
            var user = new User { Password = "hash_haslo", Email = loginDto.Email, Role = It.IsAny<Role>() };
            _userRepositoryMock.Setup(x => x.GetUserByEmail(loginDto.Email)).ReturnsAsync(user);
            _passwordHasherMock.Setup(x => x.VerifyPassword(loginDto.Password, user.Password)).Returns(false);

            //Act
            var result = async () => await _userService.Login(loginDto, "secret_key_example");

            //Assert
            await result.Should().ThrowAsync<WrongPasswordException>();
        }

        [Fact]
        public async Task Add_Student_To_Class_For_InValid_Email_Should_Throw_NotFoundException()
        {
            //Arrange
            var email = "Email";
            var clasId = It.IsAny<int>();
            var clas = new Class();
            _userRepositoryMock.Setup(x => x.GetStudentAndClass(email, clasId)).ReturnsAsync((null, clas));

            //Act
            var result = async() => await _userService.AddStudentToClass(email, clasId);

            //Assert
            await result.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task Add_Student_To_Class_For_InValid_Class_Should_Throw_NotFoundException()
        {
            //Arrange
            var email = "Email";
            var clasId = It.IsAny<int>();
            var user = new User();
            _userRepositoryMock.Setup(x => x.GetStudentAndClass(email, clasId)).ReturnsAsync((user, null));

            //Act
            var result = async () => await _userService.AddStudentToClass(email, clasId);

            //Assert
            await result.Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task Add_Student_To_Class_For_Valid_Data_Should_Invoke_Get_Student_And_Class()
        {
            //Arrange
            var email = "Email";
            var clasId = 1;
            _userRepositoryMock.Setup(x => x.GetStudentAndClass(email,clasId)).ReturnsAsync((new User{Classes = new List<Class>()}, new Class{}));

            //Act
            await _userService.AddStudentToClass(email, clasId);

            //Assert
            _userRepositoryMock.Verify(x => x.GetStudentAndClass(email, clasId), Times.Once);
        }
    }
}
