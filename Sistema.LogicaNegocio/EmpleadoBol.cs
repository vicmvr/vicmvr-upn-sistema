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
    public class EmpleadoBol
    {
        //Instanciamos nuestra clase PacienteDal para poder utilizar sus miembros
        private pacienteDal _pacienteDal = new pacienteDal();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EPaciente paciente)
        {
            if (Validarpaciente(paciente))
            {
                if (_pacienteDal.GetByid(paciente.id) == null)
                {
                    _pacienteDal.Insert(paciente);
                }
                else
                    _pacienteDal.Update(paciente);
            }
        }

        public List<EPaciente> Todos()
        {
            return _pacienteDal.GetAll();
        }

        public EPaciente TraerPorId(int idPaciente)
        {
            stringBuilder.Clear();

            if (idPaciente == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _pacienteDal.GetByid(idPaciente);
            }
            return null;
        }

        public void Eliminar(int idPaciente)
        {
            stringBuilder.Clear();

            if (idPaciente == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _pacienteDal.Delete(idPaciente);
            }
        }

        private bool Validarpaciente(EPaciente paciente)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(paciente.apellido)) stringBuilder.Append("El campo apellido es obligatorio");
            if (string.IsNullOrEmpty(paciente.nombre)) stringBuilder.Append(Environment.NewLine + "El campo nombre es obligatorio");
            //if (paciente.direccion <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}