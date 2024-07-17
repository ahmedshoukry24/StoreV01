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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Product>> GetAll()
        {
           return await this._context.Products.ToListAsync();
        }
        
    }
}
