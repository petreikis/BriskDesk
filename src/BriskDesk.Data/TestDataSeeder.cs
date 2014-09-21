using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data
{
    public class TestDataSeeder
    {
        public void Seed(BriskContext context)
        {
            var seedAlreadyPerformed = context.Users.Any();
            if (seedAlreadyPerformed)
                return;

            //TODO: generate some test users


            //TODO: generate some support personnel


            //TODO: randomly add some tickets for customers. some of them assigned to staff, some not. some closed, some open

            //let's try to save changes
            context.SaveChanges();
        }
    }
}
