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
    public class VariationRepository : BaseRepository<Variation>, IVariationRepository
    {
        private readonly StoreDbContext _context;

        public VariationRepository(StoreDbContext context) : base(context)
        {
            this._context = context;
        }

        

        public async Task<IEnumerable<Variation>> GetAll(Guid productId)
        {
            return await _context.Variations.Where(p=>p.ProductId == productId).ToListAsync();
        }
    }
}
