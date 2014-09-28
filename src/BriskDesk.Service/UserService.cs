using BriskDesk.Data.Models;
using BriskDesk.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Service
{
    public interface IUserService
    {
        User GetById(Guid id);
        //TODO: create new user
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository; 

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }
    }
}
