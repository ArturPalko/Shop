using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class NewBooksController : Controller
    {

        private IAllBooks _bookRep;

        public NewBooksController(IAllBooks bookRep)
        {
            _bookRep = bookRep;
        }

        public ViewResult Index()
        {
            var newBooks = new NewBooksViewModel
            {
                newBooks = _bookRep.getNewBooks
            };
            return View(newBooks);
        }

    }
}