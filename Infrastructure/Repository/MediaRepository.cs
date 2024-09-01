using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public MediaRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
            this._storeDbContext = storeDbContext;
            
        }
    }
}
