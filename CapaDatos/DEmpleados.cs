using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DEmpleados
    {
        private int _IdEmpleado;
        private string _Cedula;
        private string _Nombre;
        private string _Apellido;
        private DateTime _FechaIni;
        private int _IdPuestos;
        private int _IdDepartamentos;
        private byte[] _Imagen;
        private decimal  _Salario;
        private string _Estado;
        private string _TextoBuscar;

        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public DateTime FechaIni { get => _FechaIni; set => _FechaIni = value; }
        public int IdPuestos { get => _IdPuestos; set => _IdPuestos = value; }
        public int IdDepartamentos { get => _IdDepartamentos; set => _IdDepartamentos = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public decimal Salario { get => _Salario; set => _Salario = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Contructor Vacio
        public DEmpleados()
        {

        }

        //Contrusctor con parametros
        public DEmpleados(int idempleado, string cedula, string nombre, string apellido, DateTime fechaini, int idpuestos, int iddepartamentos, byte[] imagen, decimal salario, string estado, string textobuxcar)
        {
            this.IdEmpleado = idempleado;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaIni = fechaini;
            this.IdPuestos = idpuestos;
            this.IdDepartamentos = iddepartamentos;
            this.Imagen = imagen;
            this.Salario = salario;
            this.Estado = estado;
            this.TextoBuscar = textobuxcar;
        }

        //Metodos 

        //Metodo Insertar
        public string Insertar(DEmpleados Empleados)
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
                SqlCmd.CommandText = "spinsertar_empleados";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdEmpleados = new SqlParameter();
                ParIdEmpleados.ParameterName = "@idempleado";
                ParIdEmpleados.SqlDbType = SqlDbType.Int;
                ParIdEmpleados.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEmpleados);

                //Recibe segundo campo
                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = (13);
                ParCedula.Value = Empleados.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                //Recibe tercer campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe cuarto campo
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = (75);
                ParApellido.Value = Empleados.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Recibe quinto campo 
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Empleados.FechaIni;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe sexto campo
                SqlParameter ParIdPuestos = new SqlParameter();
                ParIdPuestos.ParameterName = "@idpuesto";
                ParIdPuestos.SqlDbType = SqlDbType.Int;
                ParIdPuestos.Value = Empleados.IdPuestos;
                SqlCmd.Parameters.Add(ParIdPuestos);

                //Recibe septimo campo
                SqlParameter ParIdDepartamentos = new SqlParameter();
                ParIdDepartamentos.ParameterName = "@iddepartamento";
                ParIdDepartamentos.SqlDbType = SqlDbType.Int;
                ParIdDepartamentos.Value = Empleados.IdDepartamentos;
                SqlCmd.Parameters.Add(ParIdDepartamentos);

                //Recibe noveno campo
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Empleados.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //Recibe octavo campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Empleados.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                //Recibe  decimo parametros
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Empleados.Estado;
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
        public string Editar(DEmpleados Empleados)
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
                SqlCmd.CommandText = "speditar_empleados";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleados.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //Recibe segundo campo
                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = (13);
                ParCedula.Value = Empleados.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                //Recibe tercer campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Empleados.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe cuarto campo
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = (75);
                ParApellido.Value = Empleados.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Recibe quinto campo 
                SqlParameter ParFechaIni = new SqlParameter();
                ParFechaIni.ParameterName = "@fecha";
                ParFechaIni.SqlDbType = SqlDbType.Date;
                ParFechaIni.Value = Empleados.FechaIni;
                SqlCmd.Parameters.Add(ParFechaIni);

                //Recibe sexto campo
                SqlParameter ParIdPuestos = new SqlParameter();
                ParIdPuestos.ParameterName = "@idpuesto";
                ParIdPuestos.SqlDbType = SqlDbType.Int;
                ParIdPuestos.Value = Empleados.IdPuestos;
                SqlCmd.Parameters.Add(ParIdPuestos);

                //Recibe septimo campo
                SqlParameter ParIdDepartamentos = new SqlParameter();
                ParIdDepartamentos.ParameterName = "@iddepartamento";
                ParIdDepartamentos.SqlDbType = SqlDbType.Int;
                ParIdDepartamentos.Value = Empleados.IdDepartamentos;
                SqlCmd.Parameters.Add(ParIdDepartamentos);

                //Recibe noveno campo
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Empleados.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //Recibe octavo campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Empleados.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                //Recibe  decimo parametros
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.Bit;
                ParEstado.Value = Empleados.Estado;
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
        public string Eliminar(DEmpleados Empleados)
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
                SqlCmd.CommandText = "speliminar_empleados";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idempleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleados.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado); 

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
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleados";
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
        public DataTable BuscarNombre(DEmpleados Empleados)
        {
            DataTable DtResultado = new DataTable("Empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_empleados";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleados.TextoBuscar;
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
