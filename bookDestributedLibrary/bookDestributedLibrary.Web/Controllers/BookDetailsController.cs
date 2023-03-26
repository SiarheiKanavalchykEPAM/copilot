using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace bookDestributedLibrary3.Web.Controllers
{
    [Authorize]
    public class BookDetailsController : Controller
    {
        private readonly IGenericRepository<Book> _bookRepository;

        //add constructor with injecting db context
        public BookDetailsController(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Get book details
        [HttpGet]
        [Route("book/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return View(book);
        }

        // Add book to user's library
        [HttpGet]
        [Route("book/add")]
        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        // Add book post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("book/add")]
        public async Task<IActionResult> AddBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.AddAsync(book);
                
                return RedirectToAction("Index", "Home");
            }

            return View(book);
        }

        //Edit book
        [HttpGet]
        [Route("book/edit/{id}")]
        public async Task<IActionResult> EditBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return View(book);
        }

        //Edit book post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("book/edit/{id}")]
        public async Task<IActionResult> EditBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.UpdateAsync(book);

                return RedirectToAction("Index", "Home");
            }

            return View(book);
        }

        //Delete book post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("book/delete/{id}")]
        public async Task<IActionResult> DeleteBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.DeleteAsync(book);

                return RedirectToAction("Index", "Home");
            }

            return View(book);
        }

    }
}