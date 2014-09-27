using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BriskDesk.Data.Repositories;
using Moq;
using BriskDesk.Service;
using BriskDesk.Data.Models;
using System.Collections.Generic;
using BriskDesk.Data;

namespace BriskDesk.Tests
{
    [TestClass]
    public class TicketServiceTests
    {
        private Mock<ITicketRepository> _moqTicketRepository;
        private Mock<IUserRepository> _moqUserRepository;
        private Mock<IMessageRepository> _moqMessageRepository;
        private Mock<ICommonOperationsService> _moqCommonOperationsService;
        private TicketService _service;

        [TestInitialize]
        public void Initializer()
        {
            _moqTicketRepository = new Mock<ITicketRepository>();
            _moqUserRepository = new Mock<IUserRepository>();
            _moqMessageRepository = new Mock<IMessageRepository>();
            _moqCommonOperationsService = new Mock<ICommonOperationsService>();
            _service = new TicketService(_moqTicketRepository.Object, _moqUserRepository.Object, _moqMessageRepository.Object, _moqCommonOperationsService.Object);
        }

        [TestMethod]
        public void TicketService_GetById_ReturnCorrectTicket()
        {
            //ARRANGE
            var ticket = new Ticket() { Id = Guid.NewGuid() };
            _moqTicketRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == ticket.Id))).Returns(ticket);
            //ACT
            var result = _service.GetById(ticket.Id);
            //ASSERT
            Assert.AreSame(ticket, result);
        }

        [TestMethod]
        public void TicketService_ChangeStatus_UpdateInDb()
        {
            //ARRANGE
            var ticket = new Ticket() { Id = Guid.NewGuid(), Status = TicketStatus.Open };
            var newTicketStatus = TicketStatus.Closed;
            _moqTicketRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == ticket.Id))).Returns(ticket);
            //ACT
            _service.ChangeStatus(ticket.Id, newTicketStatus);
            //ASSERT
            _moqTicketRepository.Verify(r => r.Update(It.Is<Ticket>(t => t == ticket)), Times.Once);
            Assert.AreEqual(ticket.Status, newTicketStatus);
        }

        [TestMethod]
        public void TicketService_Assign_UpdateInDb()
        {
            //ARRANGE
            var ticket = new Ticket() { Id = Guid.NewGuid(), Status = TicketStatus.Open };
            var user = new User() { Id = Guid.NewGuid() };
            _moqTicketRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == ticket.Id))).Returns(ticket);
            _moqUserRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == user.Id))).Returns(user);
            //ACT
            _service.AssignToUser(ticket.Id, user.Id);
            //ASSERT
            _moqTicketRepository.Verify(r => r.Update(It.Is<Ticket>(t => t.Id == ticket.Id && t.SupportRepresentative.Id == user.Id)), Times.Once);
        }

        [TestMethod]
        public void TicketService_PostMessage_UpdateInDb()
        {
            //ARRANGE
            var dateForMessage = DateTime.Now;
            string message = "test";
            var ticket = new Ticket() { Id = Guid.NewGuid(), Status = TicketStatus.Open };
            var user = new User() { Id = Guid.NewGuid() };
            _moqTicketRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == ticket.Id))).Returns(ticket);
            _moqUserRepository.Setup(r => r.GetById(It.Is<Guid>(g => g == user.Id))).Returns(user);
            _moqCommonOperationsService.Setup(s => s.GetDateTimeUtcNow()).Returns(dateForMessage);
            //ACT
            _service.PostMessage(ticket.Id, user.Id, message);
            //ASSERT
            _moqMessageRepository.Verify(r => r.Add(It.Is<Message>(t => t.Ticket == ticket && t.User == user && t.TimePosted == dateForMessage)), Times.Once);
        }
    }
}
