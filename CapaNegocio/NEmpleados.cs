using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NEmpleados
    {
        public static string Insertar(string cedula, string nombre, string apellido, DateTime fecha, int idpuesto, int iddepartamentos,  byte[] imagen, decimal salario, string estado)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.Cedula = cedula;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.FechaIni = fecha;
            Obj.IdPuestos = idpuesto;
            Obj.IdDepartamentos = iddepartamentos;
            Obj.Imagen = imagen;
            Obj.Salario = salario;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idempleado, string cedula, string nombre, string apellido, DateTime fecha, int idpuesto, int iddepartamentos, byte[] imagen, decimal salario, string estado)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.IdEmpleado = idempleado;
            Obj.Cedula = cedula;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.FechaIni = fecha;
            Obj.IdPuestos = idpuesto;
            Obj.IdDepartamentos = iddepartamentos;
            Obj.Imagen = imagen;
            Obj.Salario = salario;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idempleado)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.IdEmpleado = idempleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DEmpleados().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DEmpleados Obj = new DEmpleados();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
