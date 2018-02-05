using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPuestos
    {
        private int _IdPuesto;
        private string _Nombre;
        private string _NivelRiesgo;
        private decimal _SalarioMin;
        private decimal _SalarioMax;
        private string _Estado;
        private string _TextoBuscar;

        public int IdPuesto { get => _IdPuesto; set => _IdPuesto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string NivelRiesgo { get => _NivelRiesgo; set => _NivelRiesgo = value; }
        public decimal SalarioMin { get => _SalarioMin; set => _SalarioMin = value; }
        public decimal SalarioMax { get => _SalarioMax; set => _SalarioMax = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //Constructor vacio
        public DPuestos()
        {

        }

        //Constructor con parametros
        public DPuestos(int idpuestos, string nombre, string nivelriesgo, decimal salariomin, decimal salariomax, string estado, string textobuscar)
        {
            this.IdPuesto = idpuestos;
            this.Nombre = nombre;
            this.NivelRiesgo = nivelriesgo;
            this.SalarioMin = salariomin;
            this.SalarioMax = salariomax;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DPuestos Puestos)
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
                SqlCmd.CommandText = "spinsertar_puestos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdPuestos = new SqlParameter();
                ParIdPuestos.ParameterName = "@id_puestos";
                ParIdPuestos.SqlDbType = SqlDbType.Int;
                ParIdPuestos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPuestos);

                //Recibe segundo campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Puestos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe tercer campo
                SqlParameter ParNivel = new SqlParameter();
                ParNivel.ParameterName = "@nivel";
                ParNivel.SqlDbType = SqlDbType.VarChar;
                ParNivel.Size = (50);
                ParNivel.Value = Puestos.NivelRiesgo;
                SqlCmd.Parameters.Add(ParNivel);

                //Recibe cuarto campo
                SqlParameter ParSalarioMin = new SqlParameter();
                ParSalarioMin.ParameterName = "salario_min";
                ParSalarioMin.SqlDbType = SqlDbType.Money;
                ParSalarioMin.Value = Puestos.SalarioMin;
                SqlCmd.Parameters.Add(ParSalarioMin);

                //Recibe quinto campo
                SqlParameter ParSalarioMax = new SqlParameter();
                ParSalarioMax.ParameterName = "@salario_max";
                ParSalarioMax.SqlDbType = SqlDbType.Money;
                ParSalarioMax.Value = Puestos.SalarioMax;
                SqlCmd.Parameters.Add(ParSalarioMax);

                //Recibe sexto campo
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Puestos.Estado;
                SqlCmd.Parameters.Add(ParEstado);


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
        public string Editar(DPuestos Puestos)
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
                SqlCmd.CommandText = "speditar_puestos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdPuestos = new SqlParameter();
                ParIdPuestos.ParameterName = "@id_puestos";
                ParIdPuestos.SqlDbType = SqlDbType.Int;
                ParIdPuestos.Value = Puestos.IdPuesto;
                SqlCmd.Parameters.Add(ParIdPuestos);

                //Recibe segundo campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Puestos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe tercer campo
                SqlParameter ParNivel = new SqlParameter();
                ParNivel.ParameterName = "@nivel";
                ParNivel.SqlDbType = SqlDbType.VarChar;
                ParNivel.Size = (50);
                ParNivel.Value = Puestos.NivelRiesgo;
                SqlCmd.Parameters.Add(ParNivel);

                //Recibe cuarto campo
                SqlParameter ParSalarioMin = new SqlParameter();
                ParSalarioMin.ParameterName = "salario_min";
                ParSalarioMin.SqlDbType = SqlDbType.Money;
                ParSalarioMin.Value = Puestos.SalarioMin;
                SqlCmd.Parameters.Add(ParSalarioMin);

                //Recibe quinto campo
                SqlParameter ParSalarioMax = new SqlParameter();
                ParSalarioMax.ParameterName = "@salario_max";
                ParSalarioMax.SqlDbType = SqlDbType.Money;
                ParSalarioMax.Value = Puestos.SalarioMax;
                SqlCmd.Parameters.Add(ParSalarioMax);

                //Recibe sexto campo
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Puestos.Estado;
                SqlCmd.Parameters.Add(ParEstado);


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
        public string Eliminar(DPuestos Puestos)
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
                SqlCmd.CommandText = "speliminar_puestos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdPuestos = new SqlParameter();
                ParIdPuestos.ParameterName = "@id_puestos";
                ParIdPuestos.SqlDbType = SqlDbType.Int;
                ParIdPuestos.Value = Puestos.IdPuesto;
                SqlCmd.Parameters.Add(ParIdPuestos);

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
            DataTable DtResultado = new DataTable("puestos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_puestos";
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
        public DataTable BuscarNombre(DPuestos Puestos)
        {
            DataTable DtResultado = new DataTable("puestos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_puestos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Puestos.TextoBuscar;
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
