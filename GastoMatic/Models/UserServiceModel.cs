using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

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

        private UserServiceModel getDatabaseUser(string userId)
        {
            UserServiceModel usuario = null;
            ActiveRecord record = new ActiveRecord();
            using (SqlConnection con = new SqlConnection(this.cadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CuentaGastosUsuarios WHERE Usuario = @UserId", con);
                SqlDataReader reader = cmd.ExecuteReader()
                if (reader.HasRows)
                {
                    usuario = new UserServiceModel{
                        Usuario = reader.Getvalue("usuario"),
                        Contrasena = rows.password,
                        Correo = rows.email,
                        Nombre = rows.nombre,
                        ApellidoPaterno = rows.Apellido,
                        ApellidoMaterno = rows.ApeMat,
                        CodigoAcreditacion = rows.codigo,
                        Perfil = rows.perfil
                    };
                }
            }
            return usuario;
            else
                return null;
        }

        private bool deleteDatabaseUser(string userId)
        {
            ActiveRecord record = new ActiveRecord();
            string datosConexion = this.cadenaConexion;

            try
            {
                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    string textoCmd = "DELETE * FROM CuentaGastosUsuarios WHERE Usuario = '" + userId+"'";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.RecordsAffected>0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
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