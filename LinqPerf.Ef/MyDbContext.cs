using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LinqPerf.Ef
{
    public class MyDbContext : DbContext
    {
        public static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mydb.db");

        public MyDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Model> MyModel { get; set; }

        public static async Task<MyDbContext> CreateAsync(DbLogger logger)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlite($"Data Source={DbPath};");
            optionsBuilder.LogTo(logger.Log);

            var context = new MyDbContext(optionsBuilder.Options);
            await context.Database.EnsureCreatedAsync()
                .ConfigureAwait(false);

            return context;
        }

        public static void DeleteDb()
        {
            File.Delete(DbPath);
        }
    }
}
