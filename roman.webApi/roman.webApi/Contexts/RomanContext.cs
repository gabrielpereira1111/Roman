using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using roman.webApi.Domains;

#nullable disable

namespace roman.webApi.Contexts
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<Tema> Temas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog = RomanNovo; user Id = sa; pwd = senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__projeto__8FCCED76AF419364");

                entity.ToTable("projeto");

                entity.HasIndex(e => e.Projeto1, "UQ__projeto__A0D353146576E277")
                    .IsUnique();

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Projeto1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("projeto");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__projeto__idTema__403A8C7D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__projeto__idUsuar__412EB0B6");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__tema__BCD9EB4863CC7D44");

                entity.ToTable("tema");

                entity.HasIndex(e => e.Tema1, "UQ__tema__E0F97FFF769F8A25")
                    .IsUnique();

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.Tema1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tema");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipoUsua__BDD0DFE1CA05A2CE");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6DA93B7BC");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Usuario1, "UQ__usuario__9AFF8FC6B6277526")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__usuario__idTipo__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
