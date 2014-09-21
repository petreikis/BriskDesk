using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Models.EntityTypeConfiguration
{
    public class TicketEntityTypeConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketEntityTypeConfiguration()
        {
            this.HasRequired(t => t.Customer)
                .WithMany(c => c.Tickets)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.SupportRepresentative)
                .WithMany(c => c.Tickets)
                .WillCascadeOnDelete(false);
            this.HasMany(t => t.Messages)
                .WithRequired(m => m.Ticket)
                .WillCascadeOnDelete(true);
        }
    }
}
