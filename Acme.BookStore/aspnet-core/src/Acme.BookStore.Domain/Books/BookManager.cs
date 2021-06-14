using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Books
{
    public class BookManager : DomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public async Task<Book> CreateAsync(string name, BookType type, DateTime dateTime, float price)
        {
            return new Book(
                   GuidGenerator.Create(),
                   name,
                   type,
                   dateTime,
                   price
               );

        }


    }
}
