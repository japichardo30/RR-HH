using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DLogin
    {

        private int _idusuario;
        private string _users;
        private string _password;
        private string _accesos;

        public int Idusuario { get => _idusuario; set => _idusuario = value; }
        public string Users { get => _users; set => _users = value; }
        public string Password { get => _password; set => _password = value; }
        public string Accesos { get => _accesos; set => _accesos = value; }


        //Metodo Buscar Nombre
        public DataTable Login(DLogin Login)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Primer Parametro
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Login.Users;
                SqlCmd.Parameters.Add(ParUsuario);

                //Segundo Parametro
                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Login.Password;
                SqlCmd.Parameters.Add(ParPassword);


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
