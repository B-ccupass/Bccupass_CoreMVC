using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bccupass_CoreMVC.Repositories
{
    public class DBRepository : IDBRepository
    {
        private readonly BccupassDBContext _context;

        public DBRepository(BccupassDBContext context)
        {
            _context = context;
        }
        public BccupassDBContext Context { get { return _context; } }

        public void Create<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
