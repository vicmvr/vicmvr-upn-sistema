using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
//Hacemos las importaciones del espacio de nombres de los dos proyectos que referenciamos
//observe como esta capa solo referencio a Tienda-LogicNegocio y a Tienda-Entidades
//observe como no se referencia a la clase de acceso a Datos
using Sistema.LogicaNegocio;
using Sistema.Entidades;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Sistema.Presentacion
{
    public partial class FrmGrupo : Form
    {
        //
        //
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private EDocente _docente;
        private readonly DocenteBol _docenteBol = new DocenteBol();
        int index = 0;

        public FrmGrupo()
        {
            InitializeComponent();
        }
        //
        //Limpiamos los controles
        //
        private void Nuevo()
        {
            txtId.Clear();
            txtId.Focus();
        }
        //
        //Creamos los métodos generales llenando y leyendo objetos
        //
        /// <summary>
        /// 
        /// </summary>
        private void Guardar()
        {
            try
            {
                if (_docente == null) _docente = new EDocente();


                //_docente.nombre = txtNombre.Text;
                //_docente.apellidop = txtApellidoP.Text;
                //_docente.apellidom = txtApellidoM.Text;
                //_docente.curp = txtCURP.Text;
                //_docente.rfc = txtRFC.Text;
                //_docente.correo = txtCorreo.Text;
                //_docente.telefono = txtCelular.Text;
                //_docente.matricula = txtMatricula.Text;
                //_docente.referencia = txtReferencia.Text;
                //_docente.programa = txtPrograma.Text;
                //_docente.grupo = txtGrupo.Text;
                //_docente.generacion = txtGeneracion.Text;
                //_docente.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                //_docente.edonac = txtEdoNac.Text;
                //_docente.sexo = txtSexo.Text;
                //_docente.nss = txtNSS.Text;
                //_docente.sangre = txtSangre.Text;
                //_docente.telefonoCasa = txtTelefono.Text;
                //_docente.bachillerato = txtBachillerato.Text;
                //_docente.prombachillerato = txtPromBachillerato.Text;
                //_docente.direccion = txtDireccion.Text;
                //_docente.comentario = txtComentario.Text;
                
        _docenteBol.Registrar(_docente);

                if (_docenteBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_docenteBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Docente registrado/actualizado con éxito");

                    //TraerTodos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void TraerTodos()
        {
            List<EDocente> docentes = _docenteBol.Todos();

            if (docentes.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = docentes;
                dgvDatos.Columns["id"].HeaderText = "Id UPN";
                dgvDatos.Columns["idcreson"].HeaderText = "Id CRESON";
                dgvDatos.Columns["apellidop"].HeaderText = "Apellido Paterno";
                dgvDatos.Columns["apellidom"].HeaderText = "Apellido Materno";
                dgvDatos.Columns["nombre"].HeaderText = "Nombre";
                dgvDatos.Columns["matricula"].HeaderText = "Matricula";
                dgvDatos.Columns["curp"].HeaderText = "CURP";
                dgvDatos.Columns["referencia"].HeaderText = "Referencia de pagos";
                dgvDatos.Columns["programa"].HeaderText = "Programa";
                dgvDatos.Columns["grupo"].HeaderText = "Grupo";
                dgvDatos.Columns["generacion"].HeaderText = "Generacion";
                dgvDatos.Columns["fechaNacimiento"].HeaderText = "Fecha de nacimiento";
                dgvDatos.Columns["edonac"].HeaderText = "Estado de Nacimiento";
                dgvDatos.Columns["sexo"].HeaderText = "Sexo";
                dgvDatos.Columns["nss"].HeaderText = "NSS";
                dgvDatos.Columns["sangre"].HeaderText = "Tipo de Sangre";
                dgvDatos.Columns["telefonoCelular"].HeaderText = "Celular";
                dgvDatos.Columns["telefonoCasa"].HeaderText = "Telefono";
                dgvDatos.Columns["correo"].HeaderText = "Correo";
                dgvDatos.Columns["bachillerato"].HeaderText = "Bachillerato";
                dgvDatos.Columns["prombachillerato"].HeaderText = "Promedio";
                dgvDatos.Columns["direccion"].HeaderText = "Direccion";
                dgvDatos.Columns["comentario"].HeaderText = "Comentario";
                ////////////////////////////////////////////////////////////////////////////////////////
                //dgvDatos.Columns["id"].DataPropertyName = "id";
                //dgvDatos.Columns["idcreson"].DataPropertyName = "Id CRESON";
                //dgvDatos.Columns["apellidop"].DataPropertyName = "Apellido Paterno";
                //dgvDatos.Columns["apellidom"].DataPropertyName = "Apellido Materno";
                //dgvDatos.Columns["nombre"].DataPropertyName = "Nombre";
                //dgvDatos.Columns["matricula"].DataPropertyName = "Matricula";
                //dgvDatos.Columns["curp"].DataPropertyName = "CURP";
                //dgvDatos.Columns["referencia"].DataPropertyName = "Referencia de pagos";
                //dgvDatos.Columns["programa"].DataPropertyName = "Programa";
                //dgvDatos.Columns["grupo"].DataPropertyName = "grupo";
                //dgvDatos.Columns["generacion"].DataPropertyName = "Generacion";
                //dgvDatos.Columns["fechaNacimiento"].DataPropertyName = "Fecha de nacimiento";
                //dgvDatos.Columns["edonac"].DataPropertyName = "Edo de Nacimiento";
                //dgvDatos.Columns["nss"].DataPropertyName = "NSS";
                //dgvDatos.Columns["sangre"].DataPropertyName = "Tipo Sangre";
                //dgvDatos.Columns["telefonoCelular"].DataPropertyName = "Celular";
                //dgvDatos.Columns["telefonoCasa"].DataPropertyName = "Telefono";
                //dgvDatos.Columns["correo"].DataPropertyName = "Correo";
                //dgvDatos.Columns["bachillerato"].DataPropertyName = "Bachillerato";
                //dgvDatos.Columns["prombachillerato"].DataPropertyName = "Promedio";
                //dgvDatos.Columns["direccion"].DataPropertyName = "Direccion";
                //dgvDatos.Columns["comentario"].DataPropertyName = "Comentario";

            }
            else
                MessageBox.Show("No existe alumno registrado");
        }

        private bool TraerPorId(int id)
        {
            try
            {
                _docente = _docenteBol.TraerPorId(id);

                if (_docente != null)
                {
                    //txtId.Text = Convert.ToString(_docente.id);
                    //txtNombre.Text = _docente.nombre;
                    //txtApellidoP.Text = _docente.apellidop;
                    //txtApellidoM.Text = _docente.apellidom;                    
                    //txtRFC.Text = _docente.rfc;
                    //txtCURP.Text = _docente.curp;
                    //txtCorreo.Text = _docente.correo;
                    //txtCelular.Text = _docente.telefono;
                    //txtSexo.Text = _docente.sexo;
                    //txtPrograma.Text = _docente.programa;
                    //txtGrupo.Text = _docente.grupo;
                    //txtMatricula.Text = _docente.matricula;
                    //txtIdCreson.Text = _docente.idcreson;
                    //txtReferencia.Text = _docente.referencia;
                    //txtSangre.Text = _docente.sangre;
                    //txtFechaNac.Text = Convert.ToString(_docente.fechaNacimiento);
                    //txtNSS.Text = _docente.nss;
                    //txtTelefono.Text = _docente.telefonoCasa;
                    //txtEdoNac.Text = _docente.edonac;
                    //txtGeneracion.Text = _docente.generacion;
                    //txtBachillerato.Text = _docente.bachillerato;
                    //txtPromBachillerato.Text = _docente.prombachillerato;
                    //txtComentario.Text = _docente.comentario;
                    //txtDireccion.Text = _docente.direccion;
                    return true;
                }
                else
                    MessageBox.Show("El docente solicitado no existe");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado2");
                return false;
            }
        }

        private void Eliminar(int id)
        {
            try
            {
                _docenteBol.Eliminar(id);

                MessageBox.Show("Expediente eliminado satisfactoriamente");

                TraerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado3");
            }
        }

        //
        //
        //Usamos nuestros metodos y funciones generales, observe como no hemos repetido codigo en ningun lado
        //haciendo con esto que nuestras tareas de actualizacion sean mas sencillas para nosotros o para
        //al asignado en realizarlas...
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                Guardar();
               
                //Nuevo();
            }
        }

        
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                //if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    if (TraerPorId(index) == true) 
                        { 
                        txtId.Text = index.ToString();
                        }                    
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    Eliminar(Convert.ToInt32(txtId.Text));
                    Nuevo();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscar.PerformClick();
                txtId.SelectAll();
            }
        }

        private void txtSexo_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) Application.UseWaitCursor = true;

            }
            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                Application.UseWaitCursor = false;
            }
        }

        private Image originalImage;
        private void FrmAlumno_Load(object sender, EventArgs e)
        {
            //TraerTodos();            
        }

        String Ubicacion = "";
        bool subimg = false;
        byte[] img;

        public Image CargarImagen()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT foto FROM docente WHERE id=" + txtId.Text + ";";
                    try
                    {
                        byte[] imgArr = (byte[])cmd.ExecuteScalar();
                        using (var stream = new MemoryStream(imgArr))
                        {
                            Image img = Image.FromStream(stream);
                            return img;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
               
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtNSS_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength == 0)
                {
                txtId.Text = "1"; 
                index = 1;
            }
            index = Convert.ToInt32(txtId.Text);
            if (index >= 2)
            {
                //txtId.Text = (index - 1).ToString();
                index = index - 1;
            }
            btnBuscar.PerformClick();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength == 0)
            {
                txtId.Text = "1";
                index = 1;
            }
            index = Convert.ToInt32(txtId.Text);
            if (index <= 499)
                //txtId.Text = (b + 1).ToString();
                index = index + 1;
            btnBuscar.PerformClick();
        }
    }
}