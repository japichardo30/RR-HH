using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCompetencias
    {
        //Metodo Insertar que llama al metodo Insertar de la clase Dcompetencias
        //De la CapaDatos
        public static string Insertar(string descripcion, string estado)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase Dcompetencias
        //De la CapaDatos
        public static string Editar(int idcompetencia, string descripcion, string estado)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.Idcompetencia = idcompetencia;
            Obj.Descripcion = descripcion;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }


        //Metodo Eliminar que llama al metodo Eliminar de la clase Dcompetencias
        //De la CapaDatos
        public static string Eliminar(int idcompetencia)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.Idcompetencia = idcompetencia;
            return Obj.Eliminar(Obj);
        }


        //Metodo Mostrar que llama al metodo Mostrar de la clase Dcompetencias
        //De la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCompetencias().Mostrar();
        }


        //Metodo BuscarNombre que se llama al metodo BuscarNombre
        //de la clase Dcompetencias de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCompetencias Obj = new DCompetencias();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
