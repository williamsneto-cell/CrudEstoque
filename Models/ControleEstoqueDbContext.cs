using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Models;

public partial class ControleEstoqueDbContext : DbContext
{
    public ControleEstoqueDbContext()
    {
    }

    public ControleEstoqueDbContext(DbContextOptions<ControleEstoqueDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC03LAB2819\\SENAI;Database=ControleEstoqueDB;User id=sa;Password=senai.123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07BE80A065");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forneced__3214EC07D60E42F0");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3214EC0763AB5CEB");

            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produtos_Categorias");

            entity.HasOne(d => d.Fornecedor).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.FornecedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produtos_Fornecedores");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
