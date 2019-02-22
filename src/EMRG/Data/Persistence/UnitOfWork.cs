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
        public ITrackingRepository<Program> Programs { get; }
        public ITrackingRepository<Student> Students { get; }
        public ITrackingRepository<Course> Courses { get; }
        public ITrackingRepository<Room> Rooms { get; }


        public UnitOfWork(AppDbContext db, 
            ITrackingRepository<Department> departments,
            ITrackingRepository<Faculty> faculties,
            ITrackingRepository<Program> programs,
            ITrackingRepository<Student> students,
            ITrackingRepository<Course> courses,
            ITrackingRepository<Room> rooms)
        {
            _db = db;
            Departments = departments;
            Faculties = faculties;
            Programs = programs;
            Students = students;
            Courses = courses;
            Rooms = rooms;
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