using Bccupass_CoreMVC.Models.DBEntity;
using System.Linq;

namespace Bccupass_CoreMVC.Repositories.Interface
{
    public interface IDBRepository
    {
        public interface IDBRepository
        {
            public BccupassDBContext Context { get; }

            public void Create<T>(T entity) where T : class;
            public void Update<T>(T entity) where T : class;
            public void Delete<T>(T entity) where T : class;
            public IQueryable<T> GetAll<T>() where T : class;
            public void Save();

        }
    }
}
