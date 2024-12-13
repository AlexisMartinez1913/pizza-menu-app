﻿// <auto-generated />
using MenuPizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MenuPizza.Migrations
{
    [DbContext(typeof(MenuContext))]
    partial class MenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MenuPizza.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.hogarmania.com%2Fcocina%2Frecetas%2Fpastas-pizzas%2Fpizza-hawaiana.html&psig=AOvVaw2bNE0-FfE2CycX3mL6T3nt&ust=1733863809036000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCKCrlJTIm4oDFQAAAAAdAAAAABAh",
                            Name = "Hawaina",
                            price = 7.5
                        });
                });

            modelBuilder.Entity("MenuPizza.Models.DishIngredient", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("DishId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("DishIngredients");

                    b.HasData(
                        new
                        {
                            DishId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            DishId = 1,
                            IngredientId = 2
                        },
                        new
                        {
                            DishId = 1,
                            IngredientId = 3
                        });
                });

            modelBuilder.Entity("MenuPizza.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Queso Fundido"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Piña"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jamón"
                        });
                });

            modelBuilder.Entity("MenuPizza.Models.DishIngredient", b =>
                {
                    b.HasOne("MenuPizza.Models.Dish", "Dish")
                        .WithMany("DishIngredients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MenuPizza.Models.Ingredient", "Ingredient")
                        .WithMany("DishIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("MenuPizza.Models.Dish", b =>
                {
                    b.Navigation("DishIngredients");
                });

            modelBuilder.Entity("MenuPizza.Models.Ingredient", b =>
                {
                    b.Navigation("DishIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
