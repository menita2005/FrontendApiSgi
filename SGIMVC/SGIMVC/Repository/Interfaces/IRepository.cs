using System.Collections;

namespace SGIMVC.Repository.Interfaces
{
    public interface IRepository<in T> where T : class
    {
        Task<IEnumerable> GetAllAsync(string url);
        Task<bool> PostAsync(string url, T entity);
        Task<bool> UpdateAsync(string url, T entity);
        Task<bool> DeleteAsync(string url, int id);

    }
}
