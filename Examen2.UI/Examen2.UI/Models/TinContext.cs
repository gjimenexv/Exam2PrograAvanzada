using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examen2.UI.Models
{
    public partial class TinContext : DbContext
    {
        public TinContext()
        {
        }

        public TinContext(DbContextOptions<TinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BaTranDiario> BaTranDiario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=GUILLERMO;Database=Tin;User Id=guillesa;Password=oracle;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(x => x.Auid)
                    .HasName("PK_authors2");

                entity.ToTable("authors");

                entity.Property(e => e.Auid)
                    .HasColumnName("auid")
                    .HasViewColumnName("auid");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasViewColumnName("address")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Aufname)
                    .IsRequired()
                    .HasColumnName("aufname")
                    .HasViewColumnName("aufname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Aulname)
                    .IsRequired()
                    .HasColumnName("aulname")
                    .HasViewColumnName("aulname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasViewColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Contract)
                    .HasColumnName("contract")
                    .HasViewColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasViewColumnName("phone")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasViewColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasViewColumnName("zip")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BaTranDiario>(entity =>
            {
                entity.HasKey(x => new { x.CodEmpresa, x.IdCuenta, x.NumSecuencia, x.TipTransaccion });

                entity.ToTable("BA_TRAN_DIARIO");

                entity.Property(e => e.CodEmpresa)
                    .HasColumnName("COD_EMPRESA")
                    .HasViewColumnName("COD_EMPRESA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IdCuenta)
                    .HasColumnName("ID_CUENTA")
                    .HasViewColumnName("ID_CUENTA")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.NumSecuencia)
                    .HasColumnName("NUM_SECUENCIA")
                    .HasViewColumnName("NUM_SECUENCIA")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.TipTransaccion)
                    .HasColumnName("TIP_TRANSACCION")
                    .HasViewColumnName("TIP_TRANSACCION")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AsientoContable)
                    .HasColumnName("ASIENTO_CONTABLE")
                    .HasViewColumnName("ASIENTO_CONTABLE")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Beneficiario)
                    .HasColumnName("BENEFICIARIO")
                    .HasViewColumnName("BENEFICIARIO")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CodCajero)
                    .HasColumnName("COD_CAJERO")
                    .HasViewColumnName("COD_CAJERO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodCliente)
                    .HasColumnName("COD_CLIENTE")
                    .HasViewColumnName("COD_CLIENTE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodMoneda)
                    .IsRequired()
                    .HasColumnName("COD_MONEDA")
                    .HasViewColumnName("COD_MONEDA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodSistema)
                    .IsRequired()
                    .HasColumnName("COD_SISTEMA")
                    .HasViewColumnName("COD_SISTEMA")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CtaExterna)
                    .HasColumnName("CTA_EXTERNA")
                    .HasViewColumnName("CTA_EXTERNA")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FecTransaccion)
                    .HasColumnName("FEC_TRANSACCION")
                    .HasViewColumnName("FEC_TRANSACCION")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndEnvCajas)
                    .HasColumnName("IND_ENV_CAJAS")
                    .HasViewColumnName("IND_ENV_CAJAS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IndEstado)
                    .HasColumnName("IND_ESTADO")
                    .HasViewColumnName("IND_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MonMovimiento)
                    .HasColumnName("MON_MOVIMIENTO")
                    .HasViewColumnName("MON_MOVIMIENTO")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.NumDocumento)
                    .HasColumnName("NUM_DOCUMENTO")
                    .HasViewColumnName("NUM_DOCUMENTO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NumReferencia)
                    .HasColumnName("NUM_REFERENCIA")
                    .HasViewColumnName("NUM_REFERENCIA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasViewColumnName("OBSERVACIONES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubtipTransac)
                    .HasColumnName("SUBTIP_TRANSAC")
                    .HasViewColumnName("SUBTIP_TRANSAC")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TipCambio)
                    .HasColumnName("TIP_CAMBIO")
                    .HasViewColumnName("TIP_CAMBIO")
                    .HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TransactionTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
