using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Gummi.Models;

namespace Gummi.Migrations
{
    [DbContext(typeof(GummiDbContext))]
    partial class GummiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Gummi.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Gummi.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<int>("Price");

                    b.Property<string>("ReviewInfo");

                    b.HasKey("ReviewId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Gummi.Models.Review", b =>
                {
                    b.HasOne("Gummi.Models.Category", "Category")
                        .WithMany("Reviews")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
