using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hacemos las importaciones del espacio de nombres de los dos proyectos que referenciamos
//observe como esta capa solo referencio a Tienda-AccessData y no a Tienda-Presentacion
//observe también como aquí no es requerida la referencia a System.Data.SqlServerCe
using Sistema.AccesoDatos;
using Sistema.Entidades;
namespace Sistema.LogicaNegocio
{
    public class AlumnoBol
    {
        //Instanciamos nuestra clase AlumnoDal para poder utilizar sus miembros
        private alumnoDal _alumnoDal = new alumnoDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EAlumno alumno)
        {
            if (Validaralumno(alumno))
            {
                if (_alumnoDal.GetByid(alumno.id) == null)
                {
                    _alumnoDal.Insert(alumno);
                }
                else
                    _alumnoDal.Update(alumno);

            }
        }

        public List<EAlumno> Todos()
        {
            return _alumnoDal.GetAll();
        }

        public EAlumno TraerPorId(int idAlumno)
        {
            stringBuilder.Clear();

            if (idAlumno == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _alumnoDal.GetByid(idAlumno);
            }
            return null;
        }

        public void Eliminar(int idAlumno)
        {
            stringBuilder.Clear();

            if (idAlumno == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _alumnoDal.Delete(idAlumno);
            }
        }

        private bool Validaralumno(EAlumno alumno)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(alumno.apellidop)) stringBuilder.Append("El campo apellido es obligatorio");
            if (string.IsNullOrEmpty(alumno.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            //if (alumno.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}