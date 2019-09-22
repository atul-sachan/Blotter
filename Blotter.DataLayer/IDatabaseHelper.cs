using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.DataLayer
{
    public interface IDatabaseHelper<T>
        where T : Entity
    {
        IRepository<T> CreateDatabaseHelper(string connectionId);
    }
}
