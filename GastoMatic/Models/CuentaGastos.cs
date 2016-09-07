using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace GastoMatic.Models
{
    public class CuentaGastos : ActiveRecord
    {
        public int IdCuentaGastos { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string NumeroAcreedor { get; set; }
        public string Descripcion { get; set; }
        
        public bool crearCuentaGasto() {
            bool resultado = false;

            return resultado;
        }

        public bool modificarCuentaGasto()
        {
            bool resultado = false;

            return resultado;
        }

        public CuentaGastos verCuentaGastos() {
            return this;
        }

        public ArrayList listCuentaGastos() { 
            ArrayList lista = new ArrayList();
            string datosConexion = this.cadenaConexion;

            try
            {
                using (SqlConnection con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();

                    // Paso 3 - Crear un nuevo comando

                    string textoCmd = "SELECT * FROM CuentaGastos";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    SqlDataReader reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format(" {0},{1}",
                            reader[0], reader[1]));
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    reader.Close();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return lista;
        }
    }
}