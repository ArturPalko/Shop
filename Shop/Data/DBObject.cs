using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Book.Any())
            {
                content.AddRange(
                    new Book
                    {
                        name = "Harry Potter_1",
                        shortDesc = "Частина 1",
                        longDesc = "Гаррі Поттер та філософський камінь",
                        img = "/img/Harry Potter_1.jpg",
                        price = 10,
                        isNew = false,
                        available = true,
                        Category = Categories["Художні"]
                    },
                    new Book
                    {
                        name = "Harry Potter_2",
                        shortDesc = "Частина 2",
                        longDesc = "Гаррі Поттер і таємна кімната",
                        img = "/img/Harry Potter_2.jpg",
                        price = 11,
                        isNew = false,
                        available = true,
                        Category = Categories["Художні"]
                    },
                    new Book
                    {
                        name = "Harry Potter_3",
                        shortDesc = "Частина 3",
                        longDesc = "Гаррі Поттер і в'язень Азкабану",
                        img = "/img/Harry Potter_3.jpg",
                        price = 12,
                        isNew = false,
                        available = true,
                        Category = Categories["Художні"]
                    },
                    new Book
                    {
                        name = "97 for programmers",
                        shortDesc = "Coding",
                        longDesc = "97 for programmers",
                        img = "/img/97 for programmers.jpg",
                        price = 24,
                        isNew = true,
                        available = false,
                        Category = Categories["Наукові"]
                    },
                    new Book
                    {
                        name = "Coders at work",
                        shortDesc = "Coding",
                        longDesc = "Coders at work",
                        img = "/img/Coders at work.jpg",
                        price = 27,
                        isNew = false,
                        available = true,
                        Category = Categories["Наукові"]
                    },
                     new Book
                     {
                         name = "The Shellcoder`s",
                         shortDesc = "Coding",
                         longDesc = "The Shellcoder`s Handbook",
                         img = "/img/The Shellcoder`s.jpg",
                         price = 30,
                         isNew = true,
                         available = true,
                         Category = Categories["Наукові"]
                     }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category { categoryName = "Художні"},
                        new Category { categoryName = "Наукові" }
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }
    }
}