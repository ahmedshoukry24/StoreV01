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
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly StoreDbContext _context;
        public CategoryRepository(StoreDbContext context):base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            IEnumerable<Category> cats = await _context.Categories.Where(x => x.ParentCategoryId != null).ToListAsync();
            return cats;
        }
    }
}
