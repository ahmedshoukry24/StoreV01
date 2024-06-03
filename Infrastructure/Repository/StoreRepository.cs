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
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        private readonly StoreDbContext _dbContext;
        public StoreRepository(StoreDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
            
        }
        public async Task<IEnumerable<Store>> GetAll()
        {
            return await _dbContext.Stores.ToListAsync();
        }
    }
}
