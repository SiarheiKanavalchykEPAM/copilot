using System.Collections.Generic;
using System.Threading.Tasks;
using bookDestributedLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace bookDestributedLibrary.Data.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<Book>> GetAllAsync()
        {
            return _context.Books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
