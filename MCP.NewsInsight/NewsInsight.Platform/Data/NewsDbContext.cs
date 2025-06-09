using Microsoft.EntityFrameworkCore;
using NewsInsight.Shared.Models;
using System.Collections.Generic;

namespace NewsInsight.Platform.Data
{
    public class NewsDbContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }
    }
}