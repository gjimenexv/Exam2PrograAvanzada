using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DAL.EF
{
    public class SolutionDBContext : DbContext
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) : base(options)
        {

        }

        public DbSet<BaTranDiario> batrandiario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaTranDiario>()
               .HasKey(c => new { c.CodEmpresa, c.IdCuenta, c.NumSecuencia, c.TipTransaccion });
        }

    }
}
