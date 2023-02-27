using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Sistema.Presentacion
{
    public partial class FrmConexion : Form
    {
        public FrmConexion()
        {
            InitializeComponent();
        }

        private void btnEjemplo_Click(object sender, EventArgs e)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            String cadena = css.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString + ";";

            //Dividir cadena y separar palabras entre los signos = y ;
            int v = 0;
            char[] delimiterChars = { '=', ';' };
            string[] words = cadena.Split(delimiterChars);
            string[] campos = new string[9];
            foreach (string s in words)
            {
                //guardamos vector campos
                campos[v] = s;
                v++;
                //Asignamos palabaras a textbox desde vector campos segun posicion de la palabara en la cadena
                txtServidor.Text = campos[1];
                txtUsuario.Text = campos[3];
                txtBaseDatos.Text = campos[5];
                txtContrasena.Text = campos[7];
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            String cadena = css.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString + ";";

            //Dividir cadena y separar palabras entre los signos = y ;
            int v = 0;
            char[] delimiterChars = { '=', ';' };
            string[] words = cadena.Split(delimiterChars);
            string[] campos = new string[11];
            foreach (string s in words)
            {
                //guardamos vector campos
                campos[v] = s;
                v++;
                
            }//Asignamos palabaras a textbox desde vector campos segun posicion
                txtServidor.Text = campos[1];
                txtUsuario.Text = campos[3];
                txtBaseDatos.Text = campos[5];
                txtContrasena.Text = campos[7];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtServidor.Text != "")
            {
                if (txtUsuario.Text != "")
                {
                    if (txtContrasena.Text != "")
                    {
                        if (txtBaseDatos.Text != "")
                        {
                            String cadena = "server=" + txtServidor.Text + ";User Id=" + txtUsuario.Text + ";Password=" + txtContrasena.Text + ";database=" + txtBaseDatos.Text;
                            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                            ConnectionStringsSection css = conf.ConnectionStrings;
                            css.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString = cadena;
                            conf.Save();
                            MessageBox.Show("La Conexion ha sido guardada con exito!", "La Conexion ha sido guardada con exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Coloca el nombre de la base de datos.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Coloca la contraseña de la base de datos.");
                    }
                }
                else
                {
                    MessageBox.Show("Coloca el nombre de usuario de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Coloca la direccion ip del servidor donde se encuentra la base de datos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConexion_Load(object sender, EventArgs e)
        {

        }
    }
}
