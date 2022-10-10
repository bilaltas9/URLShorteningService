using Microsoft.EntityFrameworkCore;
using System;
using URLShorteningService.Entities.Concrete;

namespace URLShorteningService.DataAccess.Context
{
    public class URLShorteningContext : DbContext
    {

        public DbSet<Link> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECT"));
            }
        }
    }
}
