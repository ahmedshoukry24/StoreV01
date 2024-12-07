using Core;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        public IStoreRepository StoreRepository { get; }

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

            StoreRepository = new StoreRepository(dbContext);
        }


        public IDatabaseTransaction BeginTransaction()
        {
            return new DatabaseTransaction(_dbContext);
        }
        public void Dispose()=> _dbContext.Dispose();
    }
}
