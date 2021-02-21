using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DWTestApi.Models
{
    public class ArriveDbContext : DbContext
    {
        public DbSet<Arrive> Arrive { get; set; }

        public ArriveDbContext(DbContextOptions<ArriveDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arrive>().ToTable("Arrive");
        }


    }
}