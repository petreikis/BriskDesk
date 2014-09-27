using BriskDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Repositories
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Message GetById(Guid id);
    }

    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public Message GetById(Guid id)
        {
            return DB.Messages.Find(id);
        }
    }
}
