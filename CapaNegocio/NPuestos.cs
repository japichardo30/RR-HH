using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPuestos
    {
        public static string Insertar(string nombre, string nivel_riesgo, decimal salario_min, decimal salario_max, string estado)
        {
            DPuestos Obj = new DPuestos();
            Obj.Nombre = nombre;
            Obj.NivelRiesgo = nivel_riesgo;
            Obj.SalarioMin = salario_min;
            Obj.SalarioMax = salario_max;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idpuesto, string nombre, string nivel_riesgo, decimal salario_min, decimal salario_max, string estado)
        {
            DPuestos Obj = new DPuestos();
            Obj.IdPuesto = idpuesto;
            Obj.Nombre = nombre;
            Obj.NivelRiesgo = nivel_riesgo;
            Obj.SalarioMin = salario_min;
            Obj.SalarioMax = salario_max;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idpuesto)
        {
            DPuestos Obj = new DPuestos();
            Obj.IdPuesto = idpuesto;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DPuestos().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPuestos Obj = new DPuestos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
