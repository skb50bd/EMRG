using System.Threading.Tasks;

using Data.Core;

using Domain;

namespace Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public ITrackingRepository<Department> Departments { get; }
        public ITrackingRepository<Faculty> Faculties { get; }

        public UnitOfWork(AppDbContext db, 
            ITrackingRepository<Department> departments,
            ITrackingRepository<Faculty> faculties)
        {
            _db = db;
            Departments = departments;
            Faculties = faculties;
        }
        public void Complete()
        {
            _db.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}