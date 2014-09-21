using BriskDesk.Data.Models;
using BriskDesk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.TestDataBuilders
{
    public class UserTestBuilder : BaseTestDataBuilder<User>
    {
        public UserTestBuilder()
        {
            var firstName = RandomTestDataGenerator.GetFirstName();
            _entity = new User()
            {
                FirstName = firstName,
                LastName = RandomTestDataGenerator.GetLastName(),
                Email = string.Format("{0}{1}@gmail.com", firstName, StaticRandomNumberGenerator.Next(1, 1000)),
                Address = RandomTestDataGenerator.GetAddress(),
                City = RandomTestDataGenerator.GetCity(),
                Country = RandomTestDataGenerator.GetCountry(),
                Organization = RandomTestDataGenerator.GetCompany(),
                Phone = RandomTestDataGenerator.GetPhone(),
                Tickets = new List<Ticket>()
            };
        }
    }
}
