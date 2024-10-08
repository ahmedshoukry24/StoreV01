using Core.DTOs.Models;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetAll();

        Task<IList<ProductSearchProps>> GetSearchProductChange(string searchText);

        Task<IList<ProductSearchProps>> GetProductByCategoryId(Guid categoryId);

    }
}
