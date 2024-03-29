﻿// <auto-generated />
using Catalogo.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalogo.API.Migrations
{
    [DbContext(typeof(CatalogoContext))]
    partial class CatalogoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalogo.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("ProdutoId");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("Catalogo.Domain.Entities.TabelaNutricional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Calorias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Carboidratos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FibraAlimentar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GordurasSaturadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GordurasTotais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("Proteínas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sodio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId")
                        .IsUnique();

                    b.ToTable("tabelaNutricionals");
                });

            modelBuilder.Entity("Catalogo.Domain.Entities.TabelaNutricional", b =>
                {
                    b.HasOne("Catalogo.Domain.Entities.Produto", null)
                        .WithOne("TabelaNutricional")
                        .HasForeignKey("Catalogo.Domain.Entities.TabelaNutricional", "ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catalogo.Domain.Entities.Produto", b =>
                {
                    b.Navigation("TabelaNutricional")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
