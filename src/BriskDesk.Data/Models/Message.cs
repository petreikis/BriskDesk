using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime TimePosted { get; set; }
        public Ticket Ticket { get; set; }
    }
}
