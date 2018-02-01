using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DExperencia
    {
        private int _IdExperencia;
        private string _Empresa;
        private string _Puesto_ocupado;
        private DateTime _Fecha_ini;
        private DateTime _Fecha_fin;
        private decimal _Salario;
        private string _TextoBuscar;

        public int IdExperencia { get => _IdExperencia; set => _IdExperencia = value; }
        public string Empresa { get => _Empresa; set => _Empresa = value; }
        public string Puesto_ocupado { get => _Puesto_ocupado; set => _Puesto_ocupado = value; }
        public DateTime Fecha_ini { get => _Fecha_ini; set => _Fecha_ini = value; }
        public DateTime Fecha_fin { get => _Fecha_fin; set => _Fecha_fin = value; }
        public decimal Salario { get => _Salario; set => _Salario = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DExperencia()
        {

        }

        //Constructor con parametros
        public DExperencia(int idexperencia, string empresa, string puesto_ocupado, DateTime fecha_ini, DateTime fecha_fin, decimal salario, string textobuscar)
        {
            this.IdExperencia = idexperencia;
            this.Empresa = empresa;
            this.Puesto_ocupado = puesto_ocupado;
            this.Fecha_ini = fecha_ini;
            this.Fecha_fin = fecha_fin;
            this.Salario = salario;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DExperencia Experencia)
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
                SqlCmd.CommandText = "spinsertar_experencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdExperencia = new SqlParameter();
                ParIdExperencia.ParameterName = "@id_experencia";
                ParIdExperencia.SqlDbType = SqlDbType.Int;
                ParIdExperencia.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdExperencia);

                //Recibe segundo campo
                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = (80);
                ParEmpresa.Value = Experencia.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                //Recibe tercer campo
                SqlParameter ParPuesto = new SqlParameter();
                ParPuesto.ParameterName = "@puesto_ocupado";
                ParPuesto.SqlDbType = SqlDbType.VarChar;
                ParPuesto.Size = (50);
                ParPuesto.Value = Experencia.Puesto_ocupado;
                SqlCmd.Parameters.Add(ParPuesto);

                //Recibe cuarto campo
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha_ini";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Experencia.Fecha_ini;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe quinto campo
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.Date;
                ParFechaFin.Value = Experencia.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Recibe sexto campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Experencia.Salario;
                SqlCmd.Parameters.Add(ParSalario);


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

        //Metodo Editar
        public string Editar(DExperencia Experencia)
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
                SqlCmd.CommandText = "speditar_experencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdExperencia = new SqlParameter();
                ParIdExperencia.ParameterName = "@id_capacitaciones";
                ParIdExperencia.SqlDbType = SqlDbType.Int;
                ParIdExperencia.Value = Experencia.IdExperencia;
                SqlCmd.Parameters.Add(ParIdExperencia);

                //Recibe segundo campo
                SqlParameter ParEmpresa = new SqlParameter();
                ParEmpresa.ParameterName = "@empresa";
                ParEmpresa.SqlDbType = SqlDbType.VarChar;
                ParEmpresa.Size = (80);
                ParEmpresa.Value = Experencia.Empresa;
                SqlCmd.Parameters.Add(ParEmpresa);

                //Recibe tercer campo
                SqlParameter ParPuesto = new SqlParameter();
                ParPuesto.ParameterName = "@puesto_ocupado";
                ParPuesto.SqlDbType = SqlDbType.VarChar;
                ParPuesto.Size = (50);
                ParPuesto.Value = Experencia.Puesto_ocupado;
                SqlCmd.Parameters.Add(ParPuesto);

                //Recibe cuarto campo
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha_ini";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Experencia.Fecha_ini;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe quinto campo
                SqlParameter ParFechaFin = new SqlParameter();
                ParFechaFin.ParameterName = "@fecha_fin";
                ParFechaFin.SqlDbType = SqlDbType.Date;
                ParFechaFin.Value = Experencia.Fecha_fin;
                SqlCmd.Parameters.Add(ParFechaFin);

                //Recibe sexto campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Experencia.Salario;
                SqlCmd.Parameters.Add(ParSalario);


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
        public string Eliminar(DExperencia Experencia)
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
                SqlCmd.CommandText = "speliminar_experencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdExperencia = new SqlParameter();
                ParIdExperencia.ParameterName = "@id_capacitaciones";
                ParIdExperencia.SqlDbType = SqlDbType.Int;
                ParIdExperencia.Value = Experencia.IdExperencia;
                SqlCmd.Parameters.Add(ParIdExperencia);

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
            DataTable DtResultado = new DataTable("experencia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_experencia";
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
        public DataTable BuscarNombre(DExperencia Experencia)
        {
            DataTable DtResultado = new DataTable("experencia");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_experencia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Experencia.TextoBuscar;
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
