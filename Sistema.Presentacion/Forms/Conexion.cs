using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public class Conexion
    {
        public static String NuevaConexion()
        {
            String connstring;
            int entorno = 0; //0 test   1 Prod
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            if (entorno == 1)
                { 
                return connstring = css.ConnectionStrings["Sistema.Properties.Settings.ConnectionStringProd"].ConnectionString;
            }
            else { 
            return connstring = css.ConnectionStrings["Sistema.Properties.Settings.ConnectionStringTest"].ConnectionString;
            }
        }
    }
}
