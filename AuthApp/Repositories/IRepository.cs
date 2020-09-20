using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task Update(T oldValue, T newValue);

        Task<T> GetByIdentificatorAsync(object id);

        Task<ICollection<T>> GetAll();

        Task Add(T value);

        Task AddMany(params T[] values);
    }
}
