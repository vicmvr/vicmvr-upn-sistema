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
    public class AsignaturaBol
    {
        //Instanciamos nuestra clase CargaDal para poder utilizar sus miembros
        private asignaturaDal _asignaturaDal = new asignaturaDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EAsignatura asignatura)
        {
            if (Validarcarga(asignatura))
            {
                if (_asignaturaDal.GetByid(asignatura.idasignatura) == null)
                {
                    _asignaturaDal.Insert(asignatura);
                }
                else
                    _asignaturaDal.Update(asignatura);
            }
        }

        public List<EAsignatura> Todos()
        {
            return _asignaturaDal.GetAll();
        }
        public List<EAsignatura> TodosFiltrado(int idcarrera, int idsemestre)
        {
            return _asignaturaDal.GetAllFiltrado(idcarrera, idsemestre);
        }

        public EAsignatura TraerPorId(int idAsignatura)
        {
            stringBuilder.Clear();

            if (idAsignatura == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _asignaturaDal.GetByid(idAsignatura);
            }
            return null;
        }

        public void Eliminar(int idAsignatura)
        {
            stringBuilder.Clear();

            if (idAsignatura == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _asignaturaDal.Delete(idAsignatura);
            }
        }

        private bool Validarcarga(EAsignatura asignatura)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(asignatura.nombre)) stringBuilder.Append(Environment.NewLine + "El campo año es obligatorio");
            if (string.IsNullOrEmpty(asignatura.idcarrera)) stringBuilder.Append("El campo periodo es obligatorio");
            //if (string.IsNullOrEmpty(docente.apellidom)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (docente.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}