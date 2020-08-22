using System;
using System.Collections.Generic;

namespace Examen2.UI.Models
{
    public partial class BaTranDiario
    {
        public string CodEmpresa { get; set; }
        public decimal IdCuenta { get; set; }
        public decimal NumSecuencia { get; set; }
        public string TipTransaccion { get; set; }
        public string SubtipTransac { get; set; }
        public DateTime? FecTransaccion { get; set; }
        public string CodMoneda { get; set; }
        public string CodSistema { get; set; }
        public string CodCliente { get; set; }
        public decimal? MonMovimiento { get; set; }
        public decimal? TipCambio { get; set; }
        public decimal? AsientoContable { get; set; }
        public string Beneficiario { get; set; }
        public string IndEstado { get; set; }
        public string Observaciones { get; set; }
        public string NumDocumento { get; set; }
        public string IndEnvCajas { get; set; }
        public string CodCajero { get; set; }
        public string CtaExterna { get; set; }
        public string NumReferencia { get; set; }
        public DateTime? TransactionTime { get; set; }
    }
}
