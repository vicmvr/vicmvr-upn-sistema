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
    public class CargaBol
    {
        //Instanciamos nuestra clase CargaDal para poder utilizar sus miembros
        private cargaDal _cargaDal = new cargaDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(ECarga carga)
        {
            if (Validarcarga(carga))
            {
                if (_cargaDal.GetByid(carga.idcarga) == null)
                {
                    _cargaDal.Insert(carga);
                }
                else
                    _cargaDal.Update(carga);
            }
        }

        public List<ECarga> Todos()
        {
            return _cargaDal.GetAll();
        }

        public ECarga TraerPorId(int idCarga)
        {
            stringBuilder.Clear();

            if (idCarga == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _cargaDal.GetByid(idCarga);
            }
            return null;
        }

        public void Eliminar(int idCarga)
        {
            stringBuilder.Clear();

            if (idCarga == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _cargaDal.Delete(idCarga);
            }
        }

        private bool Validarcarga(ECarga carga)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(carga.ano)) stringBuilder.Append(Environment.NewLine + "El campo año es obligatorio");
            if (string.IsNullOrEmpty(carga.periodo)) stringBuilder.Append("El campo periodo es obligatorio");
            //if (string.IsNullOrEmpty(docente.apellidom)) stringBuilder.Append("El campo apellido es obligatorio");
            //if (docente.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}