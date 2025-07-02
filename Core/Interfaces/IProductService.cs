using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.DTOs;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>>GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductDto productDto);
        Task<Product> UpdateProductAsync(int id, ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);

    }
}
