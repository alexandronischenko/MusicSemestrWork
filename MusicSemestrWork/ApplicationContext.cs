using System;
using Microsoft.EntityFrameworkCore;
using MusicSemestrWork.Models;

namespace MusicSemestrWork
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
    }
}
