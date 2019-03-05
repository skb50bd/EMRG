using System.Collections.Generic;
using System.Threading.Tasks;

using Domain;

namespace Data.Core
{
    public interface ITrackingRepository<T> : IRepository<T> where T : Document
    {
        Task Remove(int id);
        Task<IList<T>> GetRemovedItems();
        Task<bool> IsRemoved(int id);
        Task<Faculty> GetByInitial(string initial);
    }
}
