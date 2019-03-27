using System.Threading.Tasks;

using Domain;

namespace Data.Core
{
    public interface IUnitOfWork
    {
        ITrackingRepository<Department> Departments { get; }
        ITrackingRepository<Faculty> Faculties { get; }
        ITrackingRepository<Program> Programs { get; }
        ITrackingRepository<Student> Students { get; }
        ITrackingRepository<Course> Courses { get; }
        ITrackingRepository<Room> Rooms { get; }
        ITrackingRepository<Semester> Semesters { get; }
        ITrackingRepository<Section> Sections { get; }

        void Complete();

        Task CompleteAsync();
    }
}