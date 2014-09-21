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
    }
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
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
    }
}
