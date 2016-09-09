using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace GastoMatic.Models
{
    public class CuentaGastos : ActiveRecord
    {
        public int IdCuentaGastos { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "La Fecha de Inicio es requerida")]
        public DateTime FechaInicial { get; set; }
        [Required(ErrorMessage = "La Fecha de Fin es requerida")]
        public DateTime FechaFinal { get; set; }
        [Required(ErrorMessage = "El Numero Acreedor es requerida")]
        public string NumeroAcreedor { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerida")]
        public string Descripcion { get; set; }

        public void crearCuentaGasto()
        {
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    String query = "INSERT INTO dbo.CuentaGastos (FechaCreacion,NumeroAcreedor,Descripcion,FechaInicial,FechaFinal) VALUES(@FechaCreacion,@NumeroAcreedor, @Descripcion,@FechaInicial,@FechaFinal)";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@FechaCreacion", this.FechaCreacion);
                    command.Parameters.Add("@NumeroAcreedor", this.NumeroAcreedor);
                    command.Parameters.Add("@Descripcion", this.Descripcion);
                    command.Parameters.Add("@FechaInicial", this.FechaInicial);
                    command.Parameters.Add("@FechaFinal", this.FechaFinal);

                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void modificarCuentaGasto()
        {
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    String query = "UPDATE dbo.CuentaGastos SET NumeroAcreedor=@NumeroAcreedor,Descripcion=@Descripcion,FechaInicial=@FechaInicial,FechaFinal=@FechaFinal WHERE CuentaGastoId=@IdCuentaGastos";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@NumeroAcreedor", this.NumeroAcreedor);
                    command.Parameters.Add("@Descripcion", this.Descripcion);
                    command.Parameters.Add("@FechaInicial", this.FechaInicial);
                    command.Parameters.Add("@FechaFinal", this.FechaFinal);
                    command.Parameters.Add("@IdCuentaGastos", this.IdCuentaGastos);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public CuentaGastos verCuentaGastos()
        {
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();

            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    string textoCmd = "SELECT * FROM CuentaGastos WHERE CuentaGastoId = @CuentaGastoId";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlParameter p1 = new SqlParameter("@CuentaGastoId", this.IdCuentaGastos);
                    cmd.Parameters.Add(p1);
                    SqlDataReader reader = cmd.ExecuteReader();

                    try
                    {

                        while (reader.Read())
                        {

                            this.IdCuentaGastos = Int32.Parse(reader[0].ToString());
                            this.Descripcion = reader[3].ToString();
                            this.NumeroAcreedor = reader[2].ToString();
                            this.FechaCreacion = DateTime.Parse(reader[1].ToString());
                            this.FechaInicial = DateTime.Parse(reader[4].ToString());
                            this.FechaFinal = DateTime.Parse(reader[5].ToString());

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    reader.Close();

                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }

            return this;
        }

        public ArrayList listCuentaGastos()
        {
            ArrayList lista = new ArrayList();
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
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
                            CuentaGastos cg = new CuentaGastos();
                            cg.IdCuentaGastos = Int32.Parse(reader[0].ToString());
                            cg.Descripcion = reader[3].ToString();
                            cg.NumeroAcreedor = reader[2].ToString();
                            cg.FechaCreacion = DateTime.Parse(reader[1].ToString());
                            cg.FechaInicial = DateTime.Parse(reader[4].ToString());
                            cg.FechaFinal = DateTime.Parse(reader[5].ToString());
                            lista.Add(cg);
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    reader.Close();

                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return lista;
        }

        public void deleteCuentaCargo()
        {
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    String query = "DELETE FROM CuentaGastos WHERE CuentaGastoId=@IdCuentaGastos";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@IdCuentaGastos", this.IdCuentaGastos);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}