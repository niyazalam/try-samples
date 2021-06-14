using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        public ICollection<Book> BookList;
        public BookStoreDataSeederContributor(IRepository<Book, Guid> bookRepository, IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            //var orwell = await _authorRepository.InsertAsync(
            //    await _authorManager.CreateAsync(
            //        "George Orwell",
            //        new DateTime(1903, 06, 25),
            //        "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
            //    )
            //);

            //var douglas = await _authorRepository.InsertAsync(
            //    await _authorManager.CreateAsync(
            //        "Douglas Adams",
            //        new DateTime(1952, 03, 11),
            //        "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
            //    )
            //);
            //if (await _bookRepository.GetCountAsync() <= 0)
            //{
            //    await _bookRepository.InsertAsync(
            //        new Book
            //        {
            //            Name = "1984",
            //            Type = BookType.Dystopia,
            //            PublishDate = new DateTime(1949, 6, 8),
            //            Price = 19.84f
            //        },
            //        autoSave: true
            //    );

            //    await _bookRepository.InsertAsync(
            //        new Book
            //        {
            //            Name = "The Hitchhiker's Guide to the Galaxy",
            //            Type = BookType.ScienceFiction,
            //            PublishDate = new DateTime(1995, 9, 27),
            //            Price = 42.0f
            //        },
            //        autoSave: true
            //    );
            //}
            //============================================
            Author objNewAuthow = new Author();




            Book objNewBook = new Book();
            objNewBook.Name = "1984";
            objNewBook.Type = BookType.Dystopia;
            objNewBook.PublishDate = new DateTime(1949, 6, 8);
            objNewBook.Price = 19.84f;

            Book objNewBook1 = new Book();
            objNewBook.Name = "The Hitchhiker's Guide to the Galaxy";
            objNewBook.Type = BookType.ScienceFiction;
            objNewBook.PublishDate = new DateTime(1995, 9, 27);
            objNewBook.Price = 42.0f;

            if (await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(objNewBook, autoSave: true); 

                await _bookRepository.InsertAsync( objNewBook1, autoSave: true);
            }

            //====================================
            //Author objNewAuthor = new Author();
            //objNewAuthor.Name = "George Orwell";
            //objNewAuthor.Type = BookType.Dystopia;
            //objNewBook.PublishDate = new DateTime(1949, 6, 8);
            //objNewBook.Price = 19.84f;

            //Author objNewAuthor1 = new Author();
            //objNewBook.Name = "The Hitchhiker's Guide to the Galaxy";
            //objNewBook.Type = BookType.ScienceFiction;
            //objNewBook.PublishDate = new DateTime(1995, 9, 27);
            //objNewBook.Price = 42.0f;

            //BookList = new ICollection<Book>();
            BookList.Add(objNewBook);
            BookList.Add(objNewBook1);
            var orwell = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949).",
                    BookList
                )
            );

            var douglas = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                    , BookList
                    )
            );



        }
    }
}
