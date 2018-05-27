using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCandidatos
    {
        private int _IdCandidatos;
        private string _Cedula;
        private string _Nombre;
        private string _Apellido;
        private Decimal _Salario;
        private byte[] _Imagen;
        private string _Recomendado;
        private int _IdIdiomas;
        private int _IdCompetencias;
        private int _IdExperiencia;
        private int _IdPuestos;
        private int _IdCapacitaciones;
        private string _TextoBuscar;

        public int IdCandidatos { get => _IdCandidatos; set => _IdCandidatos = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public decimal Salario { get => _Salario; set => _Salario = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public string Recomendado { get => _Recomendado; set => _Recomendado = value; }
        public int IdIdiomas { get => _IdIdiomas; set => _IdIdiomas = value; }
        public int IdCompetencias { get => _IdCompetencias; set => _IdCompetencias = value; }
        public int IdExperiencia { get => _IdExperiencia; set => _IdExperiencia = value; }
        public int IdPuestos { get => _IdPuestos; set => _IdPuestos = value; }
        public int IdCapacitaciones { get => _IdCapacitaciones; set => _IdCapacitaciones = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DCandidatos()
        {

        }

        //Contructor con parametros
        public DCandidatos(int idcandidatos, string cedula, string nombre, string apellido, decimal salario, byte[] imagen, string recomendado, int ididioma, int idcompetencia, int idexperiencia, int idpuestos, int idcapacitaciones, string textobuscar)
        {
            this.IdCandidatos = idcandidatos;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Salario = salario;
            this.Imagen = imagen;
            this.Recomendado = recomendado;
            this.IdIdiomas = ididioma;
            this.IdCompetencias = idcompetencia;
            this.IdExperiencia = idexperiencia;
            this.IdPuestos = idpuestos;
            this.IdCapacitaciones = idcapacitaciones;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(DCandidatos Candidatos)
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
                SqlCmd.CommandText = "spinsertar_candidatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCandidatos = new SqlParameter();
                ParIdCandidatos.ParameterName = "@idcandidato";
                ParIdCandidatos.SqlDbType = SqlDbType.Int;
                ParIdCandidatos.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCandidatos);

                //Recibe segundo campo
                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = (13);
                ParCedula.Value = Candidatos.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                //Recibe tercer campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Candidatos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe cuarto campo
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = (75);
                ParApellido.Value = Candidatos.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Recibe quinto campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Candidatos.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                //Recibe sexto campo
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Candidatos.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //Recibe septimo campo
                SqlParameter ParRecomendado = new SqlParameter();
                ParRecomendado.ParameterName = "@recomendado";
                ParRecomendado.SqlDbType = SqlDbType.VarChar;
                ParRecomendado.Size = (75);
                ParRecomendado.Value = Candidatos.Recomendado;
                SqlCmd.Parameters.Add(ParRecomendado);

                //Recibe octavo campo
                SqlParameter ParIdIdioma = new SqlParameter();
                ParIdIdioma.ParameterName = "@ididiomas";
                ParIdIdioma.SqlDbType = SqlDbType.Int;
                ParIdIdioma.Value = Candidatos.IdIdiomas;
                SqlCmd.Parameters.Add(ParIdIdioma);

                //Recibe noveno campo
                SqlParameter ParIdCompetencias = new SqlParameter();
                ParIdCompetencias.ParameterName = "@idcompetencias";
                ParIdCompetencias.SqlDbType = SqlDbType.VarChar;
                ParIdCompetencias.Value = Candidatos.IdCompetencias;
                SqlCmd.Parameters.Add(ParIdCompetencias);

                //Recibe decimo campo
                SqlParameter ParIdExperiencia = new SqlParameter();
                ParIdExperiencia.ParameterName = "@idexperiencia";
                ParIdExperiencia.SqlDbType = SqlDbType.VarChar;
                ParIdExperiencia.Value = Candidatos.IdExperiencia;
                SqlCmd.Parameters.Add(ParIdExperiencia);

                //Recibe decimo primer campo
                SqlParameter ParIdPuesto = new SqlParameter();
                ParIdPuesto.ParameterName = "@idpuesto";
                ParIdPuesto.SqlDbType = SqlDbType.VarChar;
                ParIdPuesto.Value = Candidatos.IdPuestos;
                SqlCmd.Parameters.Add(ParIdPuesto);

                //Recibe decimo segundo campo
                SqlParameter ParIdCapacitaciones = new SqlParameter();
                ParIdCapacitaciones.ParameterName = "@idcapacitaciones";
                ParIdCapacitaciones.SqlDbType = SqlDbType.VarChar;
                ParIdCapacitaciones.Value = Candidatos.IdCapacitaciones;
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

        //Metodo Editar
        public string Editar(DCandidatos Candidatos)
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
                SqlCmd.CommandText = "speditar_candidatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCandidato = new SqlParameter();
                ParIdCandidato.ParameterName = "@idcandidato";
                ParIdCandidato.SqlDbType = SqlDbType.Int;
                ParIdCandidato.Value = Candidatos.IdCandidatos;
                SqlCmd.Parameters.Add(ParIdCandidato);

                //Recibe segundo campo
                SqlParameter ParCedula = new SqlParameter();
                ParCedula.ParameterName = "@cedula";
                ParCedula.SqlDbType = SqlDbType.VarChar;
                ParCedula.Size = (13);
                ParCedula.Value = Candidatos.Cedula;
                SqlCmd.Parameters.Add(ParCedula);

                //Recibe tercer campo
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = (50);
                ParNombre.Value = Candidatos.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Recibe cuarto campo
                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = (75);
                ParApellido.Value = Candidatos.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                //Recibe quinto campo
                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Money;
                ParSalario.Value = Candidatos.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                //Recibe sexto campo
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Candidatos.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //Recibe septimo campo
                SqlParameter ParRecomendado = new SqlParameter();
                ParRecomendado.ParameterName = "@recomendado";
                ParRecomendado.SqlDbType = SqlDbType.VarChar;
                ParRecomendado.Size = (75);
                ParRecomendado.Value = Candidatos.Recomendado;
                SqlCmd.Parameters.Add(ParRecomendado);

                //Recibe octavo campo
                SqlParameter ParIdIdioma = new SqlParameter();
                ParIdIdioma.ParameterName = "@ididiomas";
                ParIdIdioma.SqlDbType = SqlDbType.VarChar;
                ParIdIdioma.Value = Candidatos.IdIdiomas;
                SqlCmd.Parameters.Add(ParIdIdioma);

                //Recibe noveno campo
                SqlParameter ParIdCompetencias = new SqlParameter();
                ParIdCompetencias.ParameterName = "@idcompetencias";
                ParIdCompetencias.SqlDbType = SqlDbType.VarChar;
                ParIdCompetencias.Value = Candidatos.IdCompetencias;
                SqlCmd.Parameters.Add(ParIdCompetencias);

                //Recibe decimo campo
                SqlParameter ParIdExperiencia = new SqlParameter();
                ParIdExperiencia.ParameterName = "@idexperiencia";
                ParIdExperiencia.SqlDbType = SqlDbType.VarChar;
                ParIdExperiencia.Value = Candidatos.IdExperiencia;
                SqlCmd.Parameters.Add(ParIdExperiencia);

                //Recibe decimo primer campo
                SqlParameter ParIdPuesto = new SqlParameter();
                ParIdPuesto.ParameterName = "@idpuesto";
                ParIdPuesto.SqlDbType = SqlDbType.VarChar;
                ParIdPuesto.Value = Candidatos.IdPuestos;
                SqlCmd.Parameters.Add(ParIdPuesto);

                //Recibe decimo segundo campo
                SqlParameter ParIdCapacitaciones = new SqlParameter();
                ParIdCapacitaciones.ParameterName = "@idcapacitaciones";
                ParIdCapacitaciones.SqlDbType = SqlDbType.VarChar;
                ParIdCapacitaciones.Value = Candidatos.IdCapacitaciones;
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

        //Metodo Eliminar
        public string Eliminar(DCandidatos Candidatos)
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
                SqlCmd.CommandText = "speliminar_candidatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParIdCandidato = new SqlParameter();
                ParIdCandidato.ParameterName = "@idcandidato";
                ParIdCandidato.SqlDbType = SqlDbType.Int;
                ParIdCandidato.Value = Candidatos.IdCandidatos;
                SqlCmd.Parameters.Add(ParIdCandidato);

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

        //Metodo Eliminar por cedula
        public string EliminarCanByCedula(DCandidatos Candidatos)
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
                SqlCmd.CommandText = "speliminar_candidatos_ced";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Recibe primer campo
                SqlParameter ParEliCedula = new SqlParameter();
                ParEliCedula.ParameterName = "@cedulaCandidato";
                ParEliCedula.SqlDbType = SqlDbType.VarChar;
                ParEliCedula.Value = Candidatos.Cedula;
                SqlCmd.Parameters.Add(ParEliCedula);

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
            DataTable DtResultado = new DataTable("Candidatos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_candidatos";
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
        public DataTable BuscarNombre(DCandidatos Candidatos)
        {
            DataTable DtResultado = new DataTable("Candidatos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_candidatos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Candidatos.TextoBuscar;
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
