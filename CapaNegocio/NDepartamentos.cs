using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NDepartamentos
    {
        //Metodo Insertar que llama al metodo Insertar de la clase Dcompetencias
        //De la CapaDatos
        public static string Insertar(string nombre, string estado)
        {
            DDepartamentos Obj = new DDepartamentos();
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }


        //Metodo Editar que llama al metodo Editar de la clase Dcompetencias
        //De la CapaDatos
        public static string Editar(int iddepartamentos, string nombre, string estado)
        {
            DDepartamentos Obj = new DDepartamentos();
            Obj.IdDepartamentos = iddepartamentos;
            Obj.Nombre = nombre;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }


        //Metodo Eliminar que llama al metodo Eliminar de la clase Dcompetencias
        //De la CapaDatos
        public static string Eliminar(int iddepartamentos)
        {
            DDepartamentos Obj = new DDepartamentos();
            Obj.IdDepartamentos = iddepartamentos;
            return Obj.Eliminar(Obj);
        }


        //Metodo Mostrar que llama al metodo Mostrar de la clase Dcompetencias
        //De la CapaDatos
        public static DataTable Mostrar()
        {
            return new DDepartamentos().Mostrar();
        }


        //Metodo BuscarNombre que se llama al metodo BuscarNombre
        //de la clase Dcompetencias de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DDepartamentos Obj = new DDepartamentos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
