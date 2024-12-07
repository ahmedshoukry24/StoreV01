using Core;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _dbTransaction;
        public DatabaseTransaction(StoreDbContext dbContext)
        {
            _dbTransaction = dbContext.Database.BeginTransaction();
        }
        public void Commit() => _dbTransaction.Commit();

        public void Dispose() => _dbTransaction.Dispose();

        public void Rollback() => _dbTransaction.Rollback();
    }
}
