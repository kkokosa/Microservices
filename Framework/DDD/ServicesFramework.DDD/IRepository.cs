using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesFramework.DDD
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task<bool> SaveChangesAsync();
    }
}
