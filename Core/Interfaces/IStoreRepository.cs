using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Task<IEnumerable<Store>> GetAll();
        Task<IEnumerable<Store>> GetAllWithBranches();
    }
}
