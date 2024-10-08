using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetAllByStore(Guid id);
        Task<Branch> GetBySerialAsync(string serial);
        Task<IEnumerable<Branch>> GetAllByStoreSerial(string serial);
    }
}
