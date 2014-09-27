using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BriskDesk.Service;
using BriskDesk.Data.Repositories;
using Moq;
using BriskDesk.Data.Models;

namespace BriskDesk.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _moqUserRepository;
        private UserService _userService;

        [TestInitialize]
        public void Initializer()
        {
            _moqUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_moqUserRepository.Object);

        }

        [TestMethod]
        public void UserServiceTests_GetById_ReturnCorrectUser()
        {
            //ARRANGE
            var user = new User() { Id = Guid.NewGuid() };
            _moqUserRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == user.Id))).Returns(user);
            //ACT
            var result = _userService.GetById(user.Id);
            //ASSERT
            Assert.AreEqual(user, result);
        }
    }
}
