
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using System.Diagnostics.CodeAnalysis;
using Acme.BookStore.Authors;

namespace Acme.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        public ICollection<Author> Authors { get; set; }
        public Book()
        {

        }

        public Book(
            Guid id,
            [NotNull] string name,
            BookType type,
            DateTime publishDate,
            float price = 0,
            ICollection<Author> authors=null) : base(id)
        {
            Name = name;
            Type = type;
            PublishDate = publishDate;
            Price = price;
            Authors = authors;
        }


        //Navigation Properties




    }
}
