using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NExperencia
    {
        public static string Insertar(string empresa, string puesto_ocupado, DateTime fecha_ini, DateTime fecha_fin, decimal salario)
        {
            DExperencia Obj = new DExperencia();
            Obj.Empresa = empresa;
            Obj.Puesto_ocupado = puesto_ocupado;
            Obj.Fecha_ini = fecha_ini;
            Obj.Fecha_fin = fecha_fin;
            Obj.Salario = salario;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idexperencia, string empresa, string puesto_ocupado, DateTime fecha_ini, DateTime fecha_fin, decimal salario)
        {
            DExperencia Obj = new DExperencia();
            Obj.IdExperencia = idexperencia;
            Obj.Empresa = empresa;
            Obj.Puesto_ocupado = puesto_ocupado;
            Obj.Fecha_ini = fecha_ini;
            Obj.Fecha_fin = fecha_fin;
            Obj.Salario = salario;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idexperencia)
        {
            DExperencia Obj = new DExperencia();
            Obj.IdExperencia = idexperencia;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DExperencia().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DExperencia Obj = new DExperencia();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
