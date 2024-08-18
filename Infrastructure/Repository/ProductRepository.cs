using Core.DTOs.Models;
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

        public async Task<IList<ProductSearchProps>> GetSearchProductChange(string searchText)
        {
            IList<ProductSearchProps> result = await _context.Products.Where(x => x.Name.Contains(searchText) || x.Description.Contains(searchText))
                .Select<Product,ProductSearchProps>(s => new ProductSearchProps
                {
                    Name = s.Name,
                    Description = s.Description,
                    Serial = s.Serial
                }).ToListAsync();
            return result;
        }
        
    }
}
