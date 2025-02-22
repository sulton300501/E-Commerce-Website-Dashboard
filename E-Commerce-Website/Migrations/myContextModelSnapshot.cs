﻿// <auto-generated />
using E_Commerce_Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace E_Commerce_Website.Migrations
{
    [DbContext(typeof(myContext))]
    partial class myContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce_Website.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("admin_id"));

                    b.Property<string>("admin_email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("admin_image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("admin_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("admin_password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("admin_id");

                    b.ToTable("tbl_admin");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Cart", b =>
                {
                    b.Property<int>("cart_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cart_id"));

                    b.Property<int>("cart_status")
                        .HasColumnType("integer");

                    b.Property<int>("cust_id")
                        .HasColumnType("integer");

                    b.Property<int>("prod_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_quantity")
                        .HasColumnType("integer");

                    b.HasKey("cart_id");

                    b.ToTable("tbl_carts");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("category_id");

                    b.ToTable("tbl_categories");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("customer_id"));

                    b.Property<string>("customer_address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("customer_phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("customer_id");

                    b.ToTable("tbl_customer");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Faqs", b =>
                {
                    b.Property<int>("faq_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("faq_id"));

                    b.Property<string>("faq_answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("faq_question")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("faq_id");

                    b.ToTable("tbl_faqs");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Feedback", b =>
                {
                    b.Property<int>("feedback_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("feedback_id"));

                    b.Property<string>("user_message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("feedback_id");

                    b.ToTable("tbl_feedbacks");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("product_id"));

                    b.Property<int>("cat_id")
                        .HasColumnType("integer");

                    b.Property<string>("product_description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("product_price")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("product_id");

                    b.HasIndex("cat_id");

                    b.ToTable("tbl_products");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Product", b =>
                {
                    b.HasOne("E_Commerce_Website.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("cat_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce_Website.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
