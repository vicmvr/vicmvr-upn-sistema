using Sistema.Entidades;
using Sistema.LogicaNegocio;
using Sistema.Presentacion.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Biblioteca
{
    public partial class FrmInventarioBiblioteca : Form
    {
        //
        //
        //Creamos las instancias de la clase
        //private ELibro _libro;
        private readonly LibroBol _libroBol = new LibroBol();

        public int idenviar { get; private set; }

        public FrmInventarioBiblioteca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
        private void FrmInventarioBiblioteca_Load(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                    //TraerTodos();
            }
        }


        private void TraerTodos()
        {
            List<ELibro> libros = _libroBol.Todos();

            if (libros.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = libros;
                dgvDatos.Columns["id"].HeaderText = "Id";
                dgvDatos.Columns["titulo"].HeaderText = "Titulo";
                dgvDatos.Columns["titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDatos.Columns["autor"].HeaderText = "Autor";
                dgvDatos.Columns["autor"].Width = 250;
                dgvDatos.Columns["clasificacion"].HeaderText = "Clasificacion";
                dgvDatos.Columns["existencias"].HeaderText = "Existencias";
                dgvDatos.Columns["isbn"].HeaderText = "ISBN";
                
                
                
                
                //dgvDatos.Columns["matricula"].HeaderText = "Matricula";
                
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

        private void dgvDatos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgv1.SelectedRows.Count > 0)
            //        {
            //            idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
            //            limcred = Convert.ToDouble(dgv1.SelectedRows[0].Cells[2].Value);
            //        }

        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.CurrentCell != null)
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    //Variable.idCredito = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    idenviar = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells[0].Value);
                    abrirdatosdelibro();

                    using (new CursorWait())
                    {
                        TraerTodos();
                    }
                }
            }
            catch (ConstraintException)
            {
                return;
            }


        }
        private void abrirdatosdelibro()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmLibro")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmLibro formulario = new FrmLibro();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.id = idenviar;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnNuevoLibro_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmLibro")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmLibro formulario = new FrmLibro();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
            using (new CursorWait())
            {
                TraerTodos();
            }
        }
    }
}
