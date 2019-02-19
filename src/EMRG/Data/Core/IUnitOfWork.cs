using System.Threading.Tasks;

namespace Data.Core
{
    public interface IUnitOfWork
    {

        void Complete();

        Task CompleteAsync();
    }
}