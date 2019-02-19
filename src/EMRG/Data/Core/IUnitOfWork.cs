using System.Threading.Tasks;

using Domain;

namespace Data.Core
{
    public interface IUnitOfWork
    {
        ITrackingRepository<Department> Departments { get; }
        ITrackingRepository<Faculty> Faculties { get; }
        void Complete();

        Task CompleteAsync();
    }
}