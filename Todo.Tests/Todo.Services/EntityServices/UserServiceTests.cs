using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Repository.Repositories.Interfaces;
using Todo.Services.EntityServices;
namespace Todo.Tests.Todo.Services.EntityServices
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly UserService _userService;
        private readonly Fixture _fixture;

        public UserServiceTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_repositoryMock.Object);
            _fixture = new AutoFixture.Fixture();
        }
        [Fact]
        public async void ShouldCallInsertWithSpecificUser()
        {
            var user = _fixture.Create<User>();
            _repositoryMock.Setup(x => x.Insert(It.IsAny<User>())).Returns(Task.CompletedTask);

            await _userService.InsertAsync(user);


            _repositoryMock.Verify(repo => repo.Insert(user), Times.Once);

        }

        [Fact]
        public async void ShouldCallGetAllAsyncFromRepository()
        {
            var users = new List<User>();
            _repositoryMock.Setup(x => x.GetAllAsync(null)).ReturnsAsync(users);
            var response = await _userService.GetAllAsync();


            await _userService.GetAllAsync();

            _repositoryMock.Verify(repo => repo.GetAllAsync(null), Times.Exactly(2));
            Assert.NotNull(response);

        }
    }
}
