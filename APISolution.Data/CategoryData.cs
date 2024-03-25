using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace APISolution.Data
{
    public class CategoryData : ICategoryData
    {
        private readonly AppDbContext _context;
        public CategoryData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var categories = await GetById(id);
                if (categories == null)
                {
                    throw new ArgumentException("Category not found");
                }
                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _context.Categories.OrderBy(c => c.CategoryName).ToListAsync();
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found");
            }
            return category;
        }


        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            var categories = await _context.Categories
            .Where(c => c.CategoryName.Contains(name))
            .ToListAsync();

            if (categories == null)
            {
                return Enumerable.Empty<Category>(); // Atau cara lain untuk menangani nilai null
            }

            return categories;
        }

        public async Task<int> GetCountCategories(string name)
        {
            var count = await _context.Categories
                .Where(c => c.CategoryName
                .Contains(name))
                .CountAsync();
            return count;
        }

        public async Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            var categories = await _context.Categories
                .Where(c => c.CategoryName
                .Contains(name))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return categories;

        }

        public async Task<Category> Insert(Category entity)
        {
            // pak erik code
            try
            {
                _context.Categories.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //My Code 
            //var category = new Category
            //{
            //	CategoryName = entity.CategoryName
            //};
            //await _context.Categories.AddAsync(category);
            //await _context.SaveChangesAsync();
            //return category;
        }


        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id, Category entity)
        {
            var category = await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
            if (category != null)
            {
                category.CategoryName = entity.CategoryName;
                await _context.SaveChangesAsync();
            }
            return category;

        }
    }
}
