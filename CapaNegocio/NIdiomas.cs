using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIdiomas
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DIdiomas
        //De la CapaDatos
        public static string Insertar(string nombre, string estado)
        {
            DIdiomas Obj = new DIdiomas();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase Dcompetencias
        //De la CapaDatos
        public static string Editar(int ididiomas, string nombre, string estado)
        {
            DIdiomas Obj = new DIdiomas();
            Obj.IdIdiomas = ididiomas;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }


        //Metodo Eliminar que llama al metodo Eliminar de la clase DIdiomas
        //De la CapaDatos
        public static string Eliminar(int ididiomas)
        {
            DIdiomas Obj = new DIdiomas();
            Obj.IdIdiomas = ididiomas;
            return Obj.Eliminar(Obj);
        }


        //Metodo Mostrar que llama al metodo Mostrar de la clase DIdiomas
        //De la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIdiomas().Mostrar();
        }


        //Metodo BuscarNombre que se llama al metodo BuscarNombre
        //de la clase DIdiomas de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DIdiomas Obj = new DIdiomas();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
