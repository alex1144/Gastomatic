using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GastoMatic.Models
{
    public class UserServiceModel : ActiveRecord
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CodigoAcreditacion { get; set; }
        public string Perfil { get; set; }

        public UserServiceModel(string userId, string password, string email, string nombre, string apellidopaterno, string apellidomaterno, string numAcreedor, string perfil)
        {
            this.Usuario = userId;
            this.Contrasena = password;
            this.Correo = email;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidomaterno;
            this.ApellidoMaterno = apellidomaterno;
            this.CodigoAcreditacion = numAcreedor;
            this.Perfil = perfil;
        }

        public bool validateUserLogin()
        {
            try{
                if (getDatabaseUser() == this.Usuario)
                    if (getDatabasePassword() == this.Contrasena)
                        return true;
                    else
                        throw new Exception("La contraseña es incorrecta");
                else
                    throw new Exception("No existe el usuario ");
            } 
            catch
            {
                return false;
            }

        }

        private string getDatabaseUser(string userId)
        {
            ActiveRecord record = new ActiveRecord();
            record.ExecuteQuery("SELECT usuario FROM CuentaGastosUsuarios WHERE Usuario = @UserId");
            if (record.rows.count > 0)
                return record.rows;
            else
                return null;
        }

        private bool deleteDatabaseUser(string userId)
        {
            ActiveRecord record = new ActiveRecord();
            record.ExecuteQuery("DELETE * FROM CuentaGastosUsuarios WHERE Usuario = @UserId");
            if (record.rows.count > 0)
                return record.rows;
            else
                return null;
        }

     


        public bool createUser()
        {
            string validateUserExists = getDatabaseUser(this.Usuario);
            if (validateUserExists!=null)
            {

                return false;
            }
            else
            {
                ActiveRecord record = new ActiveRecord();
                string insertUser = "INSERT INTO CuentaGastosUsuarios (Usuario, Contrasena, Nombre,ApellidoPaterno,ApellidoMaterno,NumeroAcreedor,email,Perfil) VALUES (";
               record.ExecuteQuery(insertUser);

               return true;
            }
        }
    }
}