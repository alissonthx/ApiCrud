using ApirCrud.Students;
using Microsoft.EntityFrameworkCore;

namespace ApirCrud.Data;

public class AppDbContext: DbContext{
    DbSet<Student>Students {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = Database.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}