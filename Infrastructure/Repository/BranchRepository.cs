using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly StoreDbContext _dbContext;
        public BranchRepository(StoreDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<IEnumerable<Branch>> GetAllByStore(Guid id)
        {
           return await this._dbContext.Branches.Where<Branch>(s=>s.StoreId == id).ToListAsync();
        }
        public async Task<IEnumerable<Branch>> GetAllByStoreSerial(string serial)
        {
            Store? store = await this._dbContext.Stores.FirstOrDefaultAsync(x => x.Serial == serial);
            if(store != null)
                return await this._dbContext.Branches.Include(x=>x.Media).Where<Branch>(s=>s.StoreId == store.ID).ToListAsync();

            return new List<Branch>();               
        }


        public async Task<Branch> GetBySerialAsync(string serial)
        {
            return await _dbContext.Branches.Include(x=>x.Media).FirstOrDefaultAsync(x=>x.Serial == serial);
        }


    }
}
