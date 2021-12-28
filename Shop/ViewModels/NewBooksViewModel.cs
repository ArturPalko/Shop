using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class NewBooksViewModel
    {
        public IEnumerable<Book> newBooks { get; set; }
    }
}