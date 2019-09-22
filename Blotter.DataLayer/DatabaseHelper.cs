using Autofac;

namespace Blotter.DataLayer
{
    public class DatabaseHelper<T> : IDatabaseHelper<T>
        where T : Entity
    {
        private IContainer container;


        public DatabaseHelper(IContainer container)
        {
            this.container = container;
        }

        public IRepository<T> CreateDatabaseHelper(string connectionId)
        {
            return container.Resolve<IRepository<T>>(new NamedParameter("connectionId", connectionId));
        }
    }
}
