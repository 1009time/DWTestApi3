using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DWTestApi.Models
{
    public class DeliveryHisDbContext : DbContext
    {
        public DbSet<DeliveryHis> DeliveryHis { get; set; }

        public DeliveryHisDbContext(DbContextOptions<DeliveryHisDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryHis>().ToTable("DeliveryHis");
        }


    }
}