using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    //public interface IBookAppService :
    //    ICrudAppService< //Defines CRUD methods
    //        BookDto, //Used to show books
    //        Guid, //Primary key of the book entity
    //        PagedAndSortedResultRequestDto, //Used for paging/sorting
    //        CreateUpdateBookDto> //Used to create/update a book
    //{

    //}

    public interface IBookAppService : IApplicationService
    {
        Task<BookDto> GetAsync(Guid id);

        Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);

        Task<BookDto> CreateAsync(CreateBookDto input);

        Task UpdateAsync(Guid id, UpdateBookDto input);

        Task DeleteAsync(Guid id);

        
    }
}
