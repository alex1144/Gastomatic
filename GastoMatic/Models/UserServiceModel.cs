using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoMatic.Models
{
    public class UserServiceModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CodigoAcreditacion { get; set; }
        public UserServiceModel()
        {

        }
    }
}