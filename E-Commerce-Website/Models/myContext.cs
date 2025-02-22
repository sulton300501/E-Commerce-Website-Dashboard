﻿using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website.Models
{
    public class myContext : DbContext
    {
        public myContext(DbContextOptions<myContext> options):base(options)
        {
            
        }

         public DbSet<Admin> tbl_admin { get; set; }
         public DbSet<Customer> tbl_customer { get; set; }
         public DbSet<Category> tbl_categories { get; set; }
         public DbSet<Product> tbl_products { get; set; }

         public DbSet<Cart> tbl_carts { get; set;}
         public DbSet<Feedback> tbl_feedbacks { get; set;}
         public DbSet<Faqs> tbl_faqs { get; set;}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.cat_id);
        }


    }
}
