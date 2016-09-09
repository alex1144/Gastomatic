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
    public class CuentaGastosDetalle : ActiveRecord
    {
        public int IdCuentaGastosDetalle { get; set; }
        public DateTime Fecha { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$",ErrorMessage = "Debe tener el formato 0000.00")]
        public double Monto { get; set; }
        public string FolioFactura { get; set; }
        public string Descripcion { get; set; }
        public string IdConcepto { get; set; }
        public string MetodoPago { get; set; }
        public int CuentaGastoId { get; set; }

        public void createCuentaGastoDetalle()
        {
            //bool resultado = false;
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    String query = "INSERT INTO dbo.CuentaGastosDetalle (CuentaGastoId,ConceptoId,FechaConsumo,Monto,FolioFactura,Descripcion,MetodoPago) VALUES(@CuentaGastoId,@ConceptoId, @FechaConsumo,@Monto,@FolioFactura,@Descripcion,@MetodoPago)";

                    SqlCommand command = new SqlCommand(query, con);
                    //command.Parameters.Add("@CuentaGastoId", this.IdCuentaGastos);
                    command.Parameters.Add("@CuentaGastoId", this.CuentaGastoId);
                    command.Parameters.Add("@ConceptoId", this.IdConcepto);
                    command.Parameters.Add("@FechaConsumo", this.Fecha);
                    command.Parameters.Add("@Monto", this.Monto);
                    command.Parameters.Add("@FolioFactura", this.FolioFactura);
                    command.Parameters.Add("@Descripcion", this.Descripcion);
                    command.Parameters.Add("@MetodoPago", this.MetodoPago);

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

        public ArrayList listCuentaGastosDetalle()
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
                    string textoCmd = "SELECT * FROM CuentaGastosDetalle WHERE CuentaGastoId = @CuentaGastoId";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);

                    cmd.Parameters.Add("@CuentaGastoId", this.CuentaGastoId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            CuentaGastosDetalle cg = new CuentaGastosDetalle()
                            {
                                IdCuentaGastosDetalle = Int32.Parse(reader[0].ToString()),
                                CuentaGastoId = Int32.Parse(reader[1].ToString()),
                                Descripcion = reader[6].ToString(),
                                FolioFactura = reader[5].ToString(),
                                IdConcepto = reader[2].ToString(),
                                MetodoPago = reader[7].ToString(),
                                Fecha = DateTime.Parse(reader[3].ToString()),
                                Monto = Double.Parse(reader[4].ToString())
                            };
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

        public void modificarCuentaGastoDetalle()
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
                    String query = "UPDATE dbo.CuentaGastosDetalle SET ConceptoId=@ConceptoId,FechaConsumo=@FechaConsumo,Monto=@Monto,FolioFactura=@FolioFactura,Descripcion=@Descripcion,MetodoPago = @MetodoPago WHERE DetalleCuentaGastoId=@DetalleCuentaGastoId";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@ConceptoId", this.IdConcepto);
                    command.Parameters.Add("@FechaConsumo", this.Fecha);
                    command.Parameters.Add("@Monto", this.Monto);
                    command.Parameters.Add("@FolioFactura", this.FolioFactura);
                    command.Parameters.Add("@Descripcion", this.Descripcion);
                    command.Parameters.Add("@MetodoPago", this.MetodoPago);
                    command.Parameters.Add("@DetalleCuentaGastoId", this.IdCuentaGastosDetalle);
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

        public CuentaGastosDetalle verCuentaGastosDetalle()
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
                    string textoCmd = "SELECT * FROM CuentaGastosDetalle WHERE DetalleCuentaGastoId = @DetalleCuentaGastoId";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlParameter p1 = new SqlParameter("@DetalleCuentaGastoId", this.IdCuentaGastosDetalle);
                    cmd.Parameters.Add(p1);
                    SqlDataReader reader = cmd.ExecuteReader();

                    try
                    {

                        while (reader.Read())
                        {
                            this.IdCuentaGastosDetalle = Int32.Parse(reader[0].ToString());
                            this.CuentaGastoId = Int32.Parse(reader[1].ToString());
                            this.Descripcion = reader[6].ToString();
                            this.FolioFactura = reader[5].ToString();
                            this.IdConcepto = reader[2].ToString();
                            this.MetodoPago = reader[7].ToString();
                            this.Fecha = DateTime.Parse(reader[3].ToString());
                            this.Monto = Double.Parse(reader[4].ToString());
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

        public void deleteCuentaCargoDetalle()
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
                    String query = "DELETE FROM CuentaGastosDetalle WHERE DetalleCuentaGastoId = @DetalleCuentaGastoId";

                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@DetalleCuentaGastoId", this.IdCuentaGastosDetalle);
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