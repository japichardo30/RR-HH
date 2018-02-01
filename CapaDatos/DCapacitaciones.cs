using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCapacitaciones
    {
        private int _Idcapacitaciones;
        private string _Descripcion;
        private string _Nivel;
        private DateTime _Fecha_ini;
        private DateTime _Fecha_fin;
        private string _Institucion;
        private string _TextoBuscar;

        public int Idcapacitaciones { get => _Idcapacitaciones; set => _Idcapacitaciones = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Nivel { get => _Nivel; set => _Nivel = value; }
        public DateTime Fecha_ini { get => _Fecha_ini; set => _Fecha_ini = value; }
        public DateTime Fecha_fin { get => _Fecha_fin; set => _Fecha_fin = value; }
        public string Institucion { get => _Institucion; set => _Institucion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DCapacitaciones()
        {

        }

        //Constructor con parametros
        public DCapacitaciones(int idcapacitaciones, string descripcion, string nivel, DateTime fecha_ini, DateTime fecha_fin, string institucion, string textobuscar)
        {
            this.Idcapacitaciones = idcapacitaciones;
            this.Descripcion = descripcion;
            this.Nivel = nivel;
            this.Fecha_ini = fecha_ini;
            this.Fecha_fin = fecha_fin;
            this.Institucion = institucion;
            this.TextoBuscar = textobuscar;

        }

        //Metodo Insertar
        public string Insertar(DCapacitaciones Capacitaciones)
        {
            string rpta =    "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_capacitaciones";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCapacitaciones = new SqlParameter();
                ParIdCapacitaciones.ParameterName = "@id_capacitaciones";
                ParIdCapacitaciones.SqlDbType = SqlDbType.Int;
                ParIdCapacitaciones.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCapacitaciones);

                //Recibe segundo campo
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = (256);
                ParDescripcion.Value = Capacitaciones.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Recibe tercer campo
                SqlParameter ParNivel = new SqlParameter();
                ParNivel.ParameterName = "@nivel";
                ParNivel.SqlDbType = SqlDbType.VarChar;
                ParNivel.Size = (50);
                ParNivel.Value = Capacitaciones.Nivel;
                SqlCmd.Parameters.Add(ParNivel);

                //Recibe cuarto campo
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha_ini";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Capacitaciones.Fecha_ini;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe quinto campo
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.Date;
                ParFechaFin.Value = Capacitaciones.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Recibe sexto campo
                SqlParameter ParInstitucion = new SqlParameter();
                ParInstitucion.ParameterName = "@institucion";
                ParInstitucion.SqlDbType = SqlDbType.VarChar;
                ParInstitucion.Size = (120);
                ParInstitucion.Value = Capacitaciones.Institucion;
                SqlCmd.Parameters.Add(ParInstitucion);


                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
            }
            catch(Exception ex)
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
        public string Editar(DCapacitaciones Capacitaciones)
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
                SqlCmd.CommandText = "speditar_capacitaciones";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCapacitaciones = new SqlParameter();
                ParIdCapacitaciones.ParameterName = "@id_capacitaciones";
                ParIdCapacitaciones.SqlDbType = SqlDbType.Int;
                ParIdCapacitaciones.Value = Capacitaciones.Idcapacitaciones;
                SqlCmd.Parameters.Add(ParIdCapacitaciones);

                //Recibe segundo campo
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = (256);
                ParDescripcion.Value = Capacitaciones.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Recibe tercer campo
                SqlParameter ParNivel = new SqlParameter();
                ParNivel.ParameterName = "@nivel";
                ParNivel.SqlDbType = SqlDbType.VarChar;
                ParNivel.Size = (50);
                ParNivel.Value = Capacitaciones.Nivel;
                SqlCmd.Parameters.Add(ParNivel);

                //Recibe cuarto campo
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha_ini";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Capacitaciones.Fecha_ini;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe quinto campo
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.Date;
                ParFechaFin.Value = Capacitaciones.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Recibe sexto campo
                SqlParameter ParInstitucion = new SqlParameter();
                ParInstitucion.ParameterName = "@institucion";
                ParInstitucion.SqlDbType = SqlDbType.VarChar;
                ParInstitucion.Size = (120);
                ParInstitucion.Value = Capacitaciones.Institucion;
                SqlCmd.Parameters.Add(ParInstitucion);


                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
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
        public string Eliminar(DCapacitaciones Capacitaciones)
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
                SqlCmd.CommandText = "speliminar_capacitaciones";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCapacitaciones = new SqlParameter();
                ParIdCapacitaciones.ParameterName = "@id_capacitaciones";
                ParIdCapacitaciones.SqlDbType = SqlDbType.Int;
                ParIdCapacitaciones.Value = Capacitaciones.Idcapacitaciones;
                SqlCmd.Parameters.Add(ParIdCapacitaciones);

                //Ejecucion del comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
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

        //Metodo Mostrar tabla
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("capacitaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_capacitaciones";
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

        //Metodo Buscar nombre
        public DataTable BuscarNombre(DCapacitaciones Capacitaciones)
        {
            DataTable DtResultado = new DataTable("capacitaciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_capacitaciones";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Capacitaciones.TextoBuscar;
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
