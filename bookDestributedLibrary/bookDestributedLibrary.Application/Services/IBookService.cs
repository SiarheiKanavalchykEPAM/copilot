// Book Service Interface

using System.Collections.Generic;
using System.Threading.Tasks;
using bookDestributedLibrary.Data.Models;

namespace bookDestributedLibrary.Application.Services
{
    public interface IBookService
    {
        //Get owned books
        Task<List<Book>> GetOwnedBooksAsync(int userId);
        //Get borrowed books
        Task<List<Book>> GetBorrowedBooksAsync(int userId);
        //Get all books
        Task<List<Book>> GetAllBooksAsync();
        //Get book by id
        Task<Book> GetBookByIdAsync(int id);
        //Add book
        Task AddBookAsync(Book book);
        //Edit book
        Task EditBookAsync(Book book);
        //Delete book
        Task DeleteBookAsync(int id);
    }
}