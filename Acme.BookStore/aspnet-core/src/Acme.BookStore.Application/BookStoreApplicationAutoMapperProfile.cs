using AutoMapper;
using Acme.BookStore.Users;
using Volo.Abp.AutoMapper;
using Acme.BookStore.Books;
using Acme.BookStore.Authors;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserDto>().Ignore(x => x.ExtraProperties);
            CreateMap<Book, BookDto>();

            //CreateMap<CreateUpdateBookDto, Book>();

            CreateMap<Author, AuthorDto>();

        }
    }
}