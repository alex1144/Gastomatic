using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace GastoMatic.Models
{
    public class ConceptosServiceModel : ActiveRecord
    {
        public int IdConcepto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ConceptosServiceModel() {
            this.IdConcepto = -1;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }
        public bool CreaConcepto() {
            bool Result = false;
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    con.Open();
                    string textoCmd = " INSERT INTO CuentaGastosConceptos (Concepto, Descripcion) " +
                                               " values(@Concepto, @Descripcion); " +
                                               " SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    cmd.Parameters.Add(new SqlParameter() {  ParameterName = "@Concepto", Value = this.Nombre, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Descripcion", Value = this.Descripcion, SqlDbType = SqlDbType.VarChar });
                    //cmd.ExecuteNonQuery();
                    this.IdConcepto =int.Parse(cmd.ExecuteScalar().ToString());
                    Result = true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return Result;
        }
        public bool GetCuentaGastosConceptos() {
            bool Result=false;
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    string textoCmd = " SELECT top 1 CuentaGastoConceptoId, Concepto, Descripcion " +
                                       " FROM CuentaGastosConceptos " +
                                       " WHERE CuentaGastoConceptoId=@CuentaGastoConceptoId ";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CuentaGastoConceptoId", Value = this.IdConcepto, SqlDbType = SqlDbType.Int });
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Nombre=reader[1].ToString();
                        this.Descripcion=reader[2].ToString();
                        Result=true;
                     }
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
            return Result;
        }
        public bool ActualizaConcepto()
        {
            bool Result = false;
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    con.Open();
                    string textoCmd = " Update CuentaGastosConceptos SET Concepto=@Concepto, Descripcion = @Descripcion" +
                                               " where CuentaGastoConceptoId=@CuentaGastoConceptoId ";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Concepto", Value = this.Nombre, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Descripcion", Value = this.Descripcion, SqlDbType = SqlDbType.VarChar });
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CuentaGastoConceptoId", Value = this.IdConcepto, SqlDbType = SqlDbType.Int });
                    cmd.ExecuteNonQuery();
                    Result = true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return Result;
        }
        public bool BorraConcepto()
        {
            bool Result = false;
            string datosConexion = this.cadenaConexion;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    con.Open();
                    string textoCmd = " Delete from CuentaGastosConceptos " +
                                               " where CuentaGastoConceptoId=@CuentaGastoConceptoId ";
                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@CuentaGastoConceptoId", Value = this.IdConcepto, SqlDbType = SqlDbType.Int });
                    cmd.ExecuteNonQuery();
                    Result = true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return Result;
        }
        public ArrayList GetListCuentaGastos() {
            ArrayList Result = new ArrayList();
            string datosConexion = this.cadenaConexion;
            ConceptosServiceModel sm = new ConceptosServiceModel();
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(datosConexion))
                {
                    //Paso 2 - Abrir la conexión
                    con.Open();
                    // Paso 3 - Crear un nuevo comando
                    string textoCmd = " SELECT CuentaGastoConceptoId, Concepto, Descripcion " +
                                       " FROM CuentaGastosConceptos ";

                    SqlCommand cmd = new SqlCommand(textoCmd, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            sm = new ConceptosServiceModel();
                            Result.Add(new ConceptosServiceModel() { IdConcepto = int.Parse(reader[0].ToString()), Nombre = reader[1].ToString(), Descripcion = reader[2].ToString() });
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
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return Result;
        }
    }
    //public class ConceptosServiceModels : ActiveRecord
    //{
    //    public List<ConceptosServiceModel> Conceptos { get; set; }
    //    public ConceptosServiceModels()
    //    {
    //       this.Conceptos= new List<ConceptosServiceModel>();
    //    }
    //    public List<ConceptosServiceModel> Getconcepts() {
    //        List<ConceptosServiceModel> Result = new List<ConceptosServiceModel>();
    //        string datosConexion = this.cadenaConexion;
    //        ConceptosServiceModel sm = new ConceptosServiceModel();
    //        SqlConnection con= new SqlConnection();
    //        try
    //        {
    //            using (con = new SqlConnection(datosConexion))
    //            {
    //                //Paso 2 - Abrir la conexión
    //                con.Open();
    //                // Paso 3 - Crear un nuevo comando
    //                string textoCmd = " SELECT CuentaGastoConceptoId, Concepto, Descripcion " +
    //                                   " FROM CuentaGastosConceptos ";

    //                SqlCommand cmd = new SqlCommand(textoCmd, con);
    //                SqlDataReader reader = cmd.ExecuteReader();
    //                try
    //                {
    //                    while (reader.Read())
    //                    {
    //                        sm = new ConceptosServiceModel();
    //                        Result.Add(new ConceptosServiceModel() { IdConcepto= int.Parse(reader[0].ToString()), Nombre= reader[1].ToString(), Descripcion=reader[2].ToString()});
    //                    }
    //                }
    //                catch (SqlException e)
    //                {
    //                    Console.WriteLine(e.Message);
    //                }
    //                reader.Close();
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //        if (con != null && con.State == ConnectionState.Open){
    //            con.Close();
    //        }
    //        return Result;
    //    }
    //}
}