using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectForEveryTopic.Application.Abstractions;
using ProjectForEveryTopic.Domain;

namespace ProjectForEveryTopic.Infrastructure;
public class BookDbContext : DbContext, IBookDbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            if (!databaseCreator.CanConnect()) databaseCreator.Create();
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
    public DbSet<Book> Books { get; set; }

}
