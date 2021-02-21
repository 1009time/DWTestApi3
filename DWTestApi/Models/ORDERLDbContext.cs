using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DWTestApi.Models
{

    public class ORDERLDbContext : DbContext
    {
        public DbSet<ORDERL> ORDERL { get; set; }

        public ORDERLDbContext(DbContextOptions<ORDERLDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ORDERL>().ToTable("ORDERL");
        }


    }
}