using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DIdiomas
    {
        private int _IdIdiomas;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdIdiomas { get => _IdIdiomas; set => _IdIdiomas = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DIdiomas()
        {

        }
        //Constructor con parametros 
        public DIdiomas(int ididiomas, string nombre, string estado, string textobuscar)
        {
            this.IdIdiomas = ididiomas;
            this.Nombre = nombre;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DIdiomas Idiomas)
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
                SqlCmd.CommandText = "spinsertar_idiomas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_idiomas)
                SqlParameter ParIdidioma = new SqlParameter();
                ParIdidioma.ParameterName = "@id_idiomas";
                ParIdidioma.SqlDbType = SqlDbType.Int;
                ParIdidioma.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdidioma);

                //Segundo parametro a recibir(Nombre)
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Idiomas.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Idiomas.Estado;
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
        public string Editar(DIdiomas Idiomas)
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
                SqlCmd.CommandText = "speditar_idiomas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_idiomas)
                SqlParameter ParIdidiomas = new SqlParameter();
                ParIdidiomas.ParameterName = "@id_idiomas";
                ParIdidiomas.SqlDbType = SqlDbType.Int;
                ParIdidiomas.Value = Idiomas.IdIdiomas;
                SqlCmd.Parameters.Add(ParIdidiomas);

                //Segundo parametro a recibir(Nombre)
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Idiomas.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Idiomas.Estado;
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
        public string Eliminar(DIdiomas Idiomas)
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
                SqlCmd.CommandText = "speliminar_idiomas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_idiomas)
                SqlParameter ParIdidiomas = new SqlParameter();
                ParIdidiomas.ParameterName = "@id_idiomas";
                ParIdidiomas.SqlDbType = SqlDbType.Int;
                ParIdidiomas.Value = Idiomas.IdIdiomas;
                SqlCmd.Parameters.Add(ParIdidiomas);

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
            DataTable DtResultado = new DataTable("idiomas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_idiomas";
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
        public DataTable BuscarNombre(DIdiomas Idiomas)
        {
            DataTable DtResultado = new DataTable("idiomas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_idiomas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Idiomas.TextoBuscar;
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
