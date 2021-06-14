
using Acme.BookStore.Permissions;

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq;


namespace Acme.BookStore.Books
{

    //[Authorize(BookStorePermissions.Books.Default)]
    public class BookAppService : BookStoreAppService, IBookAppService
    {
        //private readonly AuthorManager _authorManager;
        private readonly IBookRepository _bookRepository;
        private readonly BookManager _bookManager;
        //private readonly IAuthorRepository _authorRepository;
        public BookAppService(IBookRepository bookRepository, BookManager bookManager)
        {
            _bookRepository = bookRepository;
            _bookManager = bookManager;
            //_authorRepository = authorRepository;
            //GetPolicyName = BookStorePermissions.Books.Default;
            //GetListPolicyName = BookStorePermissions.Books.Default;
            //CreatePolicyName = BookStorePermissions.Books.Create;
            //UpdatePolicyName = BookStorePermissions.Books.Edit;
            //DeletePolicyName = BookStorePermissions.Books.Create;

        }



        public async Task<BookDto> CreateAsync(CreateBookDto input)
        {
            var book = await _bookManager.CreateAsync(
                           
                            input.Name,
                            input.Type,
                            input.PublishDate,
                            input.Price
                        );

            await _bookRepository.InsertAsync(book);

            return ObjectMapper.Map<Book, BookDto>(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await _bookRepository.GetAsync(id);
            return ObjectMapper.Map<Book, BookDto>(book);
        }
        //public async Task<BookDto> GetAsync(Guid id)
        //{
        //    //Get the IQueryable<Book> from the repository
        //    var queryable = await _bookRepository.GetQueryableAsync();

        //    //Prepare a query to join books and authors
        //    var query = from book in queryable
        //                join author in _authorRepository on book.AuthorId equals author.Id
        //                where book.Id == id
        //                select new { book, author };

        //    //Execute the query and get the book with author
        //    var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        //    if (queryResult == null)
        //    {
        //        throw new EntityNotFoundException(typeof(Book), id);
        //    }

        //    var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);
        //    bookDto.AuthorName = queryResult.author.Name;
        //    return bookDto;
        //}


        public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        {

            var books = await _bookRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _bookRepository.CountAsync()
                : await _bookRepository.CountAsync(
                    book => book.Name.Contains(input.Filter));

            return new PagedResultDto<BookDto>(
                totalCount,
                ObjectMapper.Map<List<Book>, List<BookDto>>(books)
            );
        }
        //public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
        //{
        //    //Get the IQueryable<Book> from the repository
        //    var queryable = await _bookRepository.GetQueryableAsync();

        //    //Prepare a query to join books and authors
        //    var query = from book in queryable
        //                join author in _authorRepository on book.AuthorId equals author.Id
        //                select new { book, author };

        //    //Paging
        //    query = query
        //        // .OrderBy(NormalizeSorting(input.Sorting))
        //        .Skip(input.SkipCount)
        //        .Take(input.MaxResultCount);

        //    //Execute the query and get a list
        //    var queryResult = await AsyncExecuter.ToListAsync(query);

        //    //Convert the query result to a list of BookDto objects
        //    var bookDtos = queryResult.Select(x =>
        //    {
        //        var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
        //        bookDto.AuthorName = x.author.Name;
        //        return bookDto;
        //    }).ToList();

        //    //Get the total count with another query
        //    var totalCount = await _bookRepository.GetCountAsync();

        //    return new PagedResultDto<BookDto>(
        //        totalCount,
        //        bookDtos
        //    );
        //}





        public async Task UpdateAsync(Guid id, UpdateBookDto input)
        {
            var book = await _bookRepository.GetAsync(id);


            book.Name = input.Name;
            book.PublishDate = input.PublishDate;
            book.Price = input.Price;
            await _bookRepository.UpdateAsync(book);
        }

        //public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        //{
        //    var authors = await _authorRepository.GetListAsync();

        //    return new ListResultDto<AuthorLookupDto>(
        //        ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
        //    );
        //}

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"book.{nameof(Book.Name)}";
            }

            if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "authorName",
                    "author.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"book.{sorting}";
        }

        //============================
        //Task<BookDto> IBookAppService.CreateAsync(CreateBookDto input)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IBookAppService.DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<BookDto> IBookAppService.GetAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<PagedResultDto<BookDto>> IBookAppService.GetListAsync(GetBookListDto input)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IBookAppService.UpdateAsync(Guid id, UpdateBookDto input)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
