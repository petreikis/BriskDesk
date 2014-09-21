using BriskDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Repositories
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Ticket GetById(Guid id);
    }

    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public Ticket GetById(Guid id)
        {
            return DB.Tickets.Find(id);
        }
    }
}
