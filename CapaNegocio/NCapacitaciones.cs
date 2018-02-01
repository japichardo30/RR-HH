using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCapacitaciones
    {
        public static string Insertar(string descripcion, string nivel, DateTime fecha_ini, DateTime fecha_fin, string institucion)
        {
            DCapacitaciones Obj = new DCapacitaciones();
            Obj.Descripcion = descripcion;
            Obj.Nivel = nivel;
            Obj.Fecha_ini = fecha_ini;
            Obj.Fecha_fin = fecha_fin;
            Obj.Institucion = institucion;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcapacitaciones, string descripcion, string nivel, DateTime fecha_ini, DateTime fecha_fin, string institucion)
        {
            DCapacitaciones Obj = new DCapacitaciones();
            Obj.Idcapacitaciones = idcapacitaciones;
            Obj.Descripcion = descripcion;
            Obj.Nivel = nivel;
            Obj.Fecha_ini = fecha_ini;
            Obj.Fecha_fin = fecha_fin;
            Obj.Institucion = institucion;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcapacitaciones)
        {
            DCapacitaciones Obj = new DCapacitaciones();
            Obj.Idcapacitaciones = idcapacitaciones;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCapacitaciones().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCapacitaciones Obj = new DCapacitaciones();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
