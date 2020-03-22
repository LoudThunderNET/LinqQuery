using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BlogContext>()
                .UseSqlServer("Data Source=HOME-PC\\SQLEXPRESS;Initial Catalog=BlogDb;User ID=sa;Password=123456;Pooling=False", s=> 
                { 
                    
                });
            return new BlogContext(builder.Options);
        }
    }
}
