using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDepartamentos
    {
        private int _IdDepartamentos;
        private string _Nombre;
        private string _Estado;
        private string _TextoBuscar;

        public int IdDepartamentos { get => _IdDepartamentos; set => _IdDepartamentos = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //Constructor vacio
        public DDepartamentos()
        {

        }

        //Constructor con parametros
        public DDepartamentos(int iddepartamentos, string nombre, string estado, string textobuscar)
        {
            this.IdDepartamentos = iddepartamentos;
            this.Nombre = nombre;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DDepartamentos Departamentos)
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
                SqlCmd.CommandText = "spinsertar_departamentos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_departamentos)
                SqlParameter ParIddepartamentos = new SqlParameter();
                ParIddepartamentos.ParameterName = "@id_departamento";
                ParIddepartamentos.SqlDbType = SqlDbType.Int;
                ParIddepartamentos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddepartamentos);

                //Segundo parametro a recibir(Nombre)
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Departamentos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Departamentos.Estado;
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
        public string Editar(DDepartamentos Departamentos)
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
                SqlCmd.CommandText = "speditar_departamentos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_departamentos)
                SqlParameter ParIddepartamentos = new SqlParameter();
                ParIddepartamentos.ParameterName = "@id_departamento";
                //Esto esta asi porque erroneamente lo escribi mal en la BD y no quiero cambiarlo
                ParIddepartamentos.SqlDbType = SqlDbType.Int;
                ParIddepartamentos.Value = Departamentos.IdDepartamentos;
                SqlCmd.Parameters.Add(ParIddepartamentos);

                //Segundo parametro a recibir(Nombre)
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 256;
                ParNombre.Value = Departamentos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Tercer parametro a recibir(Estado)
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Departamentos.Estado;
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
        public string Eliminar(DDepartamentos Departamentos)
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
                SqlCmd.CommandText = "speliminar_departamentos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer parametro a recibir(id_competencias)
                SqlParameter ParIdDepartamento = new SqlParameter();
                ParIdDepartamento.ParameterName = "@id_departamento";
                ParIdDepartamento.SqlDbType = SqlDbType.Int;
                ParIdDepartamento.Value = Departamentos.IdDepartamentos;
                SqlCmd.Parameters.Add(ParIdDepartamento);

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
            DataTable DtResultado = new DataTable("Departamentos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_departamentos";
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
        public DataTable BuscarNombre(DDepartamentos Departamentos)
        {
            DataTable DtResultado = new DataTable("Departamentos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_departamentos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Departamentos.TextoBuscar;
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
