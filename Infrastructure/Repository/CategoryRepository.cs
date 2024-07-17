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
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext context):base(context)
        {
            this._context = context;
        }
    }
}
