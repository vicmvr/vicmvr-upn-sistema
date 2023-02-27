using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class ELibro
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string clasificacion { get; set; }
        public string existencias { get; set; }
        public string isbn { get; set; }

    }
}
