using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCandidatos
    {
        public static string Insertar(string cedula, string nombre, string apellido, decimal  salario, byte[] imagen, string recomendado,int ididiomas, int idcompetencias, int idexperiencia, int idpuesto, int idcapacitaciones)
        {
            DCandidatos Obj = new DCandidatos();
            Obj.Cedula = cedula;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Salario = salario;
            Obj.Imagen = imagen;
            Obj.Recomendado = recomendado;
            Obj.IdIdiomas = ididiomas;
            Obj.IdCompetencias = idcompetencias;
            Obj.IdExperiencia = idexperiencia;
            Obj.IdPuestos = idpuesto;
            Obj.IdCapacitaciones = idcapacitaciones;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcandidato, string cedula, string nombre, string apellido, decimal salario, byte[] imagen, string recomendado, int ididiomas, int idcompetencias, int idexperiencia, int idpuesto, int idcapacitaciones)
        {
            DCandidatos Obj = new DCandidatos();
            Obj.IdCandidatos = idcandidato;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Salario = salario;
            Obj.Imagen = imagen;
            Obj.Recomendado = recomendado;
            Obj.IdIdiomas = ididiomas;
            Obj.IdCompetencias = idcompetencias;
            Obj.IdExperiencia = idexperiencia;
            Obj.IdPuestos = idpuesto;
            Obj.IdCapacitaciones = idcapacitaciones;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcandidato)
        {
            DCandidatos Obj = new DCandidatos();
            Obj.IdCandidatos = idcandidato;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCandidatos().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCandidatos Obj = new DCandidatos();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
