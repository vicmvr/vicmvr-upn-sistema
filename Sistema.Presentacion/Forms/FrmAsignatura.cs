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
    public partial class FrmAsignatura : Form
    {
        //Creamos las instancias de la clase EAsignatura y AsignaturaBol
        private EAsignatura _asignatura;
        private readonly AsignaturaBol _asignaturaBol = new AsignaturaBol();
        int index = 0;

        //Creamos las instancias de la clase ECarrera y CarreraBol
        private ECarrera _carrera;
        private readonly CarreraBol _carreraBol = new CarreraBol();

        //Creamos las instancias de la clase ESemestre y SemestreBol
        private ESemestre _semestre;
        private readonly SemestreBol _semestreBol = new SemestreBol();

        public FrmAsignatura()
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
                if (_asignatura == null) _asignatura = new EAsignatura();


                _asignatura.nombre = txtNombre.Text;
                _asignatura.idasignatura = Convert.ToInt32(txtAsignatura.Text);
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

        _asignaturaBol.Registrar(_asignatura);

                if (_asignaturaBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_asignaturaBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Asignatura registrado/actualizado con éxito");

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
            List<EAsignatura> asignaturas = _asignaturaBol.Todos();

            if (asignaturas.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = asignaturas;
                dgvDatos.Columns["idasignatura"].HeaderText = "Id Asignatura";
                dgvDatos.Columns["nombre"].HeaderText = "Nombre";
                dgvDatos.Columns["nombre"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                dgvDatos.Columns["idcarrera"].HeaderText = "Id Carrera";
                dgvDatos.Columns["idsemestre"].HeaderText = "Id Semestre";
                /////////////////////////////////////////////////////

            }
            //else
            //    MessageBox.Show("No existe alumno registrado");
        }
        private void TraerTodosFiltrado()
        {
            List<EAsignatura> asignaturas = _asignaturaBol.TodosFiltrado(Convert.ToInt32(comboBoxCarrera.SelectedValue), Convert.ToInt32(comboBoxSemestre.SelectedValue));

            if (asignaturas.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = asignaturas;
                dgvDatos.Columns["idasignatura"].HeaderText = "Id Asignatura";
                dgvDatos.Columns["nombre"].HeaderText = "Nombre";
                dgvDatos.Columns["nombre"].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                dgvDatos.Columns["idcarrera"].HeaderText = "Id Carrera";
                dgvDatos.Columns["idsemestre"].HeaderText = "Id Semestre";
                /////////////////////////////////////////////////////

            }
            //else
            //    MessageBox.Show("No existe alumno registrado");
        }
        private void TraerCarreras()
        {
            List<ECarrera> carreras = _carreraBol.Todos();
            comboBoxCarrera.DisplayMember = "nombre";
            comboBoxCarrera.ValueMember = "idcarrera";
            comboBoxCarrera.DataSource = carreras;
        }
        private void TraerSemestres()
        {
            List<ESemestre> semestres = _semestreBol.Todos();
            comboBoxSemestre.DisplayMember = "semestre";
            comboBoxSemestre.ValueMember = "idsemestre";
            comboBoxSemestre.DataSource = semestres;
        }
        private bool TraerPorId(int id)
        {
            try
            {
                _asignatura = _asignaturaBol.TraerPorId(id);

                if (_asignatura != null)
                {
                    //txtId.Text = Convert.ToString(_docente.id);
                    txtAsignatura.Text = _asignatura.idasignatura.ToString();
                    txtNombre.Text = _asignatura.nombre;
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
                    MessageBox.Show("Asignatura solicitada no existe");
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
                _asignaturaBol.Eliminar(id);

                MessageBox.Show("Asignatura eliminada con éxito");

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

        private void FrmAlumno_Load(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                TraerSemestres();
                TraerCarreras();
                //TraerTodos();
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

        private void comboBoxCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxCarrera_SelectedValueChanged(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                TraerTodosFiltrado();
                //if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    //if (TraerTodosFiltrado(Convert.ToInt32(comboBoxCarrera.ValueMember)),Convert.ToInt32(comboBoxSemestre.ValueMember)) == true)
                    {
                        //txtId.Text = index.ToString();

                    }
                }
            }
        }
    }
}