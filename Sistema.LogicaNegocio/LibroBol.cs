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
    public class LibroBol
    {
        //Instanciamos nuestra clase LibroDal para poder utilizar sus miembros
        private libroDal _libroDal = new libroDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(ELibro libro)
        {
            if (Validarlibro(libro))
            {
                if (_libroDal.GetByid(libro.id) == null)
                {
                    _libroDal.Insert(libro);
                }
                else
                    _libroDal.Update(libro);
            }
        }

        public List<ELibro> Todos()
        {
            return _libroDal.GetAll();
        }

        public ELibro TraerPorId(int idLibro)
        {
            stringBuilder.Clear();

            if (idLibro == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _libroDal.GetByid(idLibro);
            }
            return null;
        }

        public void Eliminar(int idLibro)
        {
            stringBuilder.Clear();

            if (idLibro == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _libroDal.Delete(idLibro);
            }
        }

        private bool Validarlibro(ELibro libro)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(libro.titulo)) stringBuilder.Append("El campo titulo es obligatorio");
            //if (string.IsNullOrEmpty(libro.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            //if (libro.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}