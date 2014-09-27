using BriskDesk.Data;
using BriskDesk.Data.Models;
using BriskDesk.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Service
{
    public interface ITicketService
    {
        Ticket GetById(Guid id);
        void ChangeStatus(Guid ticketId, TicketStatus status);
        void AssignToUser(Guid ticketId, Guid userId);
        void PostMessage(Guid ticket, Guid userId, string text);
    }
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ICommonOperationsService _commonOperationsService;

        public TicketService(ITicketRepository ticketRepository, IUserRepository userRepository, IMessageRepository messageRepository, ICommonOperationsService commonOperationsService)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _commonOperationsService = commonOperationsService;
        }

        public Ticket GetById(Guid id)
        {
            return _ticketRepository.GetById(id);
        }

        public void ChangeStatus(Guid ticketId, TicketStatus status)
        {
            var ticket = GetById(ticketId);
            ticket.Status = status;
            _ticketRepository.Update(ticket);
        }

        public void AssignToUser(Guid ticketId, Guid userId)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            var user = _userRepository.GetById(userId);
            ticket.SupportRepresentative = user;
            _ticketRepository.Update(ticket);
        }

        public void PostMessage(Guid ticketId, Guid userId, string text)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            var user = _userRepository.GetById(userId);
            var message = new Message()
            {
                Text = text,
                Ticket = ticket,
                User = user,
                TimePosted = _commonOperationsService.GetDateTimeUtcNow()
            };
            _messageRepository.Add(message);
        }
    }
}
