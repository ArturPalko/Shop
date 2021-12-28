using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
     public interface IAllBooks
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> getNewBooks { get; }
        Book getObjectBook(int bookId);
    }
}
