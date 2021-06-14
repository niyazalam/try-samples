using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */
            //builder.Entity<BookAuthor>().HasKey(BA => new { BA.BookId, BA.Authors });

            //builder.Entity<BookAuthor>().HasOne<Book>(sc => sc.Books).WithMany(s => s.BookAuthorList).HasForeignKey(sc => sc.BookId);
            //builder.Entity<BookAuthor>().HasOne<Author>(sc => sc.Authors).WithMany(s => s.BookAuthorList).HasForeignKey(sc => sc.AuthorId);

            //builder.Entity<Book>(b =>
            //{
            //    b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
            //              BookStoreConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            //});

            //builder.Entity<Author>(b =>
            //{
            //    b.ToTable(BookStoreConsts.DbTablePrefix + "Authors",
            //        BookStoreConsts.DbSchema);

            //    b.ConfigureByConvention();
            //    b.Property(x => x.Name)
            //        .IsRequired()
            //        .HasMaxLength(AuthorConsts.MaxNameLength);

            //    b.HasIndex(x => x.Name);
            //});
        }
    }
}
