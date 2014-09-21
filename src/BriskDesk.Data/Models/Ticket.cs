using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public User Customer { get; set; }
        public User SupportRepresentative { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime OpeningDate { get; set; }
        public TicketStatus Status { get; set; }
    }
}
