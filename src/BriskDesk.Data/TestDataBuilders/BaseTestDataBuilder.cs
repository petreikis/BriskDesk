using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Data.TestDataBuilders
{
    public abstract class BaseTestDataBuilder<T> where T : class
    {
        protected T _entity;

        public T Build()
        {
            return _entity;
        }
    }
}

