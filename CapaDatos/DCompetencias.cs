using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCompetencias
    {
        private int _idcompetencia;
        private string _Descripcion;
        private string _Estado;

        private string _TextoBuscar;

        public int Idcompetencia { get => _idcompetencia; set => _idcompetencia = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Contructor Vacio
        public DCompetencias()
        {

        }

        //Constructor con parametros
        public DCompetencias(int idcompetencia, string descripcion, string estado, string textobuscar)
        {
            this.Idcompetencia = idcompetencia;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }
        
        //Metodo Insertar
        public string Insertar(DCompetencias Competencias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_competencias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_competencia)
                SqlParameter ParIdcompetencias = new SqlParameter();
                ParIdcompetencias.ParameterName = "@id_competencia";
                ParIdcompetencias.SqlDbType = SqlDbType.Int;
                ParIdcompetencias.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcompetencias);

                //Segundo parametro a recibir(Descripcion)
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Competencias.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Competencias.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Editar
        public string Editar(DCompetencias Competencias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_competencias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_competencias)
                SqlParameter ParIdcompetencias = new SqlParameter();
                ParIdcompetencias.ParameterName = "@id_categoria";
                //Esto esta asi porque erroneamente lo escribi mal en la BD y no quiero cambiarlo
                ParIdcompetencias.SqlDbType = SqlDbType.Int;
                ParIdcompetencias.Value = Competencias.Idcompetencia;
                SqlCmd.Parameters.Add(ParIdcompetencias);

                //Segundo parametro a recibir(Descripcion)
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Competencias.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Competencias.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(DCompetencias Competencias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_competencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_competencias)
                SqlParameter ParIdcompetencias = new SqlParameter();
                ParIdcompetencias.ParameterName = "@id_competencia";
                ParIdcompetencias.SqlDbType = SqlDbType.Int;
                ParIdcompetencias.Value = Competencias.Idcompetencia;
                SqlCmd.Parameters.Add(ParIdcompetencias);

                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_competencias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo Buscar Nombre
        public DataTable BuscarNombre(DCompetencias Competencias)
        {
            DataTable DtResultado = new DataTable("Competencias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_competencias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Competencias.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
