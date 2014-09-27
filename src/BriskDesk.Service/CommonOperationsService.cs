using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriskDesk.Service
{
    /// <summary>
    /// This does not do much. It exists just to make unit testing easier
    /// </summary>
    public interface ICommonOperationsService
    {
        Guid GetNewGuid();
        DateTime GetDateTimeUtcNow();
    }

    public class CommonOperationsService : ICommonOperationsService
    {
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        public DateTime GetDateTimeUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}

