using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NLogin
    {
        public static DataTable Login(string users, string password)
        {
            DLogin Obj = new DLogin();
            Obj.Users = users;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}
