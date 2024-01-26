using BookListWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListWeb.Data;

public class ApplicationContext :DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}
