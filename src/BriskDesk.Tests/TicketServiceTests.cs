﻿using System;
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
        private TicketService _service;

        [TestInitialize]
        public void Initializer()
        {
            _moqTicketRepository = new Mock<ITicketRepository>();
            _service = new TicketService(_moqTicketRepository.Object);
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
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TicketService_PostMessage_UpdateInDb()
        {
            throw new NotImplementedException();
        }
    }
}
