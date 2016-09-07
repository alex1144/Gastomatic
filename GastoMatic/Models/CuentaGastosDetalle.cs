using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoMatic.Models
{
    public class CuentaGastosDetalle
    {
        public int IdCuentaGastosDetalle { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string FolioFactura { get; set; }
        public string Descripcion { get; set; }
        public string IdConcepto { get; set; }
    }
}