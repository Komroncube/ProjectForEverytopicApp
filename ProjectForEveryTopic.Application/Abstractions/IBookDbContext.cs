using Microsoft.EntityFrameworkCore;
using ProjectForEveryTopic.Domain;

namespace ProjectForEveryTopic.Application.Abstractions;
public interface IBookDbContext
{
    public DbSet<Book> Books { get; set; }

    int SaveChanges();
}
