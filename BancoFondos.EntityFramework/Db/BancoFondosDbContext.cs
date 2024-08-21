using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoFondos.Core.Entidades;
using Microsoft.EntityFrameworkCore;


namespace BancoFondos.EntityFramework.Db
{
    public class BancoFondosDbContext : DbContext
    {
        public BancoFondosDbContext(DbContextOptions<BancoFondosDbContext> options)
            : base(options)
        {
        }

        // DbSets para las entidades
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fondo> Fondos { get; set; }
        public DbSet<Transaccion> Transacciones  { get; set; }
        public DbSet<FondosInfo> FondosInfos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
               
                entity.Property(c => c.Saldo).HasPrecision(18, 2);

            });
            modelBuilder.Entity<Fondo>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

              

                entity.Property(f => f.Rendimiento)
                      .HasColumnType("decimal(18,2)");
            });

            // Configuración de la entidad Transaccion
            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Fecha)
                      .IsRequired();

                entity.Property(t => t.Monto)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(t => t.Tipo)
                      .IsRequired()
                      .HasMaxLength(50);

                // Configuración de la relación con Cliente
                entity.HasOne(t => t.Cliente)
                      .WithMany(c => c.Transacciones)
                      .HasForeignKey(t => t.ClienteId);

                // Configuración de la relación con Fondo
                entity.HasOne(t => t.Fondo)
                      .WithMany(f => f.Transacciones)
                      .HasForeignKey(t => t.FondoId);
            });

            modelBuilder.Entity<FondosInfo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.MontoMinimo)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Categoria)
                      .HasMaxLength(50);

                // Agregar datos quemados
                entity.HasData(
                    new FondosInfo { Id = 1, Nombre = "FPV_BTG_PACTUAL_RECAUDADORA", MontoMinimo = 75000m, Categoria = "FPV" },
                    new FondosInfo { Id = 2, Nombre = "FPV_BTG_PACTUAL_ECOPETROL", MontoMinimo = 125000m, Categoria = "FPV" },
                    new FondosInfo { Id = 3, Nombre = "DEUDAPRIVADA", MontoMinimo = 50000m, Categoria = "FIC" },
                    new FondosInfo { Id = 4, Nombre = "FDO-ACCIONES", MontoMinimo = 250000m, Categoria = "FIC" },
                    new FondosInfo { Id = 5, Nombre = "FPV_BTG_PACTUAL_DINAMICA", MontoMinimo = 100000m, Categoria = "FPV" }
                );
            });
        }

    }
}
