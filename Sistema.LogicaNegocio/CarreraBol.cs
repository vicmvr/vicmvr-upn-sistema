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
    public class CarreraBol
    {
        //Instanciamos nuestra clase CarreraDal para poder utilizar sus miembros
        private carreraDal _carreraDal = new carreraDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(ECarrera carrera)
        {
            if (ValidarCarrera(carrera))
            {
                if (_carreraDal.GetByid(carrera.idcarrera) == null)
                {
                    _carreraDal.Insert(carrera);
                }
                else
                    _carreraDal.Update(carrera);
            }
        }

        public List<ECarrera> Todos()
        {
            return _carreraDal.GetAll();
        }

        public ECarrera TraerPorId(int idCarrera)
        {
            stringBuilder.Clear();

            if (idCarrera == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _carreraDal.GetByid(idCarrera);
            }
            return null;
        }

        public void Eliminar(int idCarrera)
        {
            stringBuilder.Clear();

            if (idCarrera == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _carreraDal.Delete(idCarrera);
            }
        }

        private bool ValidarCarrera(ECarrera carrera)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(carrera.nombre)) stringBuilder.Append(Environment.NewLine + "El campo año es obligatorio");
            //if (string.IsNullOrEmpty(carrera.periodo)) stringBuilder.Append("El campo periodo es obligatorio");
            //if (string.IsNullOrEmpty(docente.apellidom)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (docente.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}