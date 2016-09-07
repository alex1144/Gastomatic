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
            if (record.rows.count > 0 )
                return record.rows;
            else
                return null
        }

        private string getDatabasePassword(int userId)
        {
            ActiveRecord record = new ActiveRecord();
            return record.ExecuteQuery("SELECT password FROM CuentaGastosUsuarios WHERE Usuario = @UserId");
        }

     


        public bool createUser(string userId, string password, string email, string nombre, string apellidopaterno, string apellidomaterno, string numAcreedor, string perfil)
        {
            this.Usuario = userId;
            string validateUserExists = getDatabaseUser(userId);
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