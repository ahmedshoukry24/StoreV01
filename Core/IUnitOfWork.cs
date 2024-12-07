using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();

        IStoreRepository StoreRepository { get; }
    }
}
