using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Authors
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }

        public ICollection<Guid> BookList { get; set; }

        //public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
