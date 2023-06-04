using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int? id);
        Task<Product> GetByIdWithImagesAsync(int? id);
    }
}

