using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Acme.BookStore.Books
{
    public class GetBookListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
