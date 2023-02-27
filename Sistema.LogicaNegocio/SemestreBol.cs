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
    public class SemestreBol
    {
        //Instanciamos nuestra clase SemestreDal para poder utilizar sus miembros
        private semestreDal _semestreDal = new semestreDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Semestre, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(ESemestre semestre)
        {
            if (ValidarSemestre(semestre))
            {
                if (_semestreDal.GetByid(semestre.idsemestre) == null)
                {
                    _semestreDal.Insert(semestre);
                }
                else
                    _semestreDal.Update(semestre);
            }
        }

        public List<ESemestre> Todos()
        {
            return _semestreDal.GetAll();
        }

        public ESemestre TraerPorId(int idSemestre)
        {
            stringBuilder.Clear();

            if (idSemestre == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _semestreDal.GetByid(idSemestre);
            }
            return null;
        }

        public void Eliminar(int idSemestre)
        {
            stringBuilder.Clear();

            if (idSemestre == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _semestreDal.Delete(idSemestre);
            }
        }

        private bool ValidarSemestre(ESemestre semestre)
        {
            stringBuilder.Clear();

            //if (string.IsNullOrEmpty(semestre.semestre)) stringBuilder.Append(Environment.NewLine + "El campo año es obligatorio");
            //if (string.IsNullOrEmpty(semestre.idcarrera)) stringBuilder.Append("El campo periodo es obligatorio");
            //if (string.IsNullOrEmpty(docente.apellidom)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (docente.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}