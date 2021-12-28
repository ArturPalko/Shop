using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class BooksController : Controller
    {

        private readonly IAllBooks _allBooks;
        private readonly IBooksCategory _allCategories;

        public BooksController(IAllBooks iAllBooks, IBooksCategory iBooksCat)
        {
            _allBooks = iAllBooks;
            _allCategories = iBooksCat;
        }
        [Route("Books/List")]
        [Route("Books/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Book> books = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                books = _allBooks.Books.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Science", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Наукові")).OrderBy(i => i.id);
                 
                }
                else if (string.Equals("Art", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Художні")).OrderBy(i => i.id);
                    
                }
            }
            currCategory = _category;

            var bookObj = new BooksListViewModel
            {
                allBooks = books,
           
            };
            ViewBag.Title = "Книги";
            return View(bookObj);
        }


    }
}