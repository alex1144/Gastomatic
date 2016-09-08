﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

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

        private UserServiceModel getDatabaseUser(string userId)
        {
            try
            {
                UserServiceModel usuario = null;
                ActiveRecord record = new ActiveRecord();
                using (SqlConnection con = new SqlConnection(this.cadenaConexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM CuentaGastosUsuarios WHERE Usuario = @User", con);
                    cmd.Parameters.Add(new SqlParameter("@User", SqlDbType.VarChar)).Value = userId;
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        usuario = new UserServiceModel{
                            Usuario = reader.GetString(0).ToString(),
                            Contrasena = reader.GetString(1).ToString(),
                            Correo = reader.GetString(2).ToString(),
                            Nombre = reader.GetString(3).ToString(),
                            ApellidoPaterno = reader.GetString(4).ToString(),
                            ApellidoMaterno = reader.GetString(5).ToString(),
                            CodigoAcreditacion = reader.GetString(6).ToString(),
                            Perfil = reader.GetString(7).ToString()
                        };
                        return usuario;
                    } 
                }
                }
                 catch (Exception ex)
                {
                    con.Close();
                    Console.WriteLine(ex.Message);
                    return null;
                }
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

        public bool userExists(string user)
        {
            try
            {
                string datosConexion = this.cadenaConexion;
                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    string textoCmd = "SELECT * FROM CuentaGastosUsuarios WHERE Usuario = '" + user + "'";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.RecordsAffected > 0)
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
            bool validateUserExists = userExists(this.Usuario);
            if (validateUserExists == true)
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