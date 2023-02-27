using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class EPaciente
    {
        public int id { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string telefonoCasa { get; set; }
        public string telefonoCelular { get; set; }
        public string telefonoTrabajo { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string cp { get; set; }
        public string pais { get; set; }
        public int numeroControl { get; set; }
        public DateTime fechaCaptura { get; set; }
        public string email { get; set; }
        public string rfc { get; set; }
        public string razonSocial { get; set; }
        public string ocupacion { get; set; }
    }
}
