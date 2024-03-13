using AutoMapper;
using FutureProject.API.Controllers;
using FutureProject.Domain.Entities.DTOs;
using FutureProject.Domain.Entities.Models;
using FutureProjectApplication.Abstraction.IService;
using Moq;

namespace FutureProject.Application.Tests.Services.UserService
{
    public class UserServiceTests
    {



        private readonly Mock<IUserService> _userservice = new Mock<IUserService>();
    


        public static IEnumerable<object[]> GetUserFromDataGenerator()
        {
            yield return new object[]
            {

                new UserDTO()
                {
                    Name = "Test Product 3",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                 new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }

            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 4",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                 new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }


            };
            yield return new object[]
          {
                new UserDTO()
                {
                    Name = "Test Product 5",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                 new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }


          };
            yield return new object[]
          {
                new UserDTO()
                {
                    Name = "Test Product 6",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                 new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }


          };
            yield return new object[]
          {
                new UserDTO()
                {
                    Name = "Test Product 7",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                 new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }

          };



        }

        [Theory]
        [MemberData(nameof(GetUserFromDataGenerator), MemberType = typeof(UserServiceTests))]
        public async void Create_User_Test(UserDTO inputUser,User expectedUser)
        {
/*
            var expectedUser1 = new User()
            {
                Name = inputUser1.Name,
                Email = inputUser1.Email,
                Password = inputUser1.Password,
                Login = inputUser1.Login,
                Role = inputUser1.Role

            };
*/


           



            _userservice.Setup(x => x.Create(It.IsAny<UserDTO>()))
          .ReturnsAsync(expectedUser);

            var controller = new UsersController(_userservice.Object);


            // Act
            var createdUser = await controller.CreateUser(inputUser);

            // Assert
            Assert.NotNull(createdUser); 

         //  Assert.Equal(createdUser,expectedUser);

            Assert.True(CompareModels(inputUser,createdUser));
        }


      
            public static bool CompareModels(UserDTO inputUser , User user)
            {
                if(inputUser.Name==user.Name && inputUser.Email==user.Email && inputUser.Password==user.Password
                    && inputUser.Login==user.Login && inputUser.Role == user.Role)
                {
                    return true;
                }
                return false;

            

         //   public static IEnumerable<object[]> GetUserFromDataGenerator()



        }






























        [Fact]
        public async void Create_User_Test1()
        {
             

        var newUser = new UserDTO()
            {
                Name = "Test Product",
                Email = "komilov@gmail.com",
                Password = "123",
                Login = "tes123",
                Role = "Admin"
            };


            var expectedUser = new User()
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Password = newUser.Password,
                Login = newUser.Login,
                Role = newUser.Role
            };


            _userservice.Setup(x => x.Create(It.IsAny<UserDTO>()))
                .ReturnsAsync(expectedUser);

            var controller =  new UsersController(_userservice.Object);
            var createUser = await controller.CreateUser(newUser);


            Assert.NotNull(createUser);
            Assert.Equal(createUser, expectedUser);





        }



          



          




        
    }
}
