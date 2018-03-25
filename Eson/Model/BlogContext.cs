using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Citys { get; set; }
    }




}
