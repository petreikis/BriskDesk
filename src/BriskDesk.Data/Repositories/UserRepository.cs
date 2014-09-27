using BriskDesk.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);   
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetById(Guid id)
        {
            return DB.Users.Find(id);
        }
    }
}
