using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoMatic.Models
{
    public class CuentaGastos
    {
        public int IdCuentaGastos { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string NumeroAcreedor { get; set; }
        public string Descripcion { get; set; }
    }
}