// Books Service
using System.Collections.Generic;
using System.Threading.Tasks;
using bookDestributedLibrary.Data.Models;
// repository using
using bookDestributedLibrary.Data.Repositories;

using bookDestributedLibrary.Application.Services;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _bookRepository;

    public BookService(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddBookAsync(Book book)
    {
        await _bookRepository.AddAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        await _bookRepository.DeleteAsync(id);
    }

    public async Task EditBookAsync(Book book)
    {
        await _bookRepository.UpdateAsync(book);
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return (await _bookRepository.GetAllAsync()).ToList();
    }

    public async Task<List<Book>> GetBorrowedBooksAsync(int userId)
    {
        return (await _bookRepository.GetAllAsync()).Where(book => 
            book.ContributorId == userId ||
            book.CurrentKeeperId != null).ToList();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<List<Book>> GetOwnedBooksAsync(int userId)
    {
        return (await _bookRepository.GetAllAsync()).Where(book => book.ContributorId == userId).ToList();
    }
}
