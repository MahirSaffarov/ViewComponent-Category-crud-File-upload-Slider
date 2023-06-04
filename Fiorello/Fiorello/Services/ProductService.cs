using System;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public ProductService(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.products.Include(m => m.Images).Take(8).Where(m => !m.SoftDelete).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task<Product> GetByIdWithImagesAsync(int? id)
        {
            return await _context.products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}

