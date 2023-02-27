using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.LogicaNegocio;
using Sistema.Entidades;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
namespace Sistema.Presentacion.Forms
{
    public partial class FrmLibro : Form
    {
        //
        //
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private ELibro _libro;
        private readonly LibroBol _libroBol = new LibroBol();
        //private string parametroBusqueda;
        public int id=0;

        public FrmLibro()
        {
            InitializeComponent();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    TraerPorId(Convert.ToInt32(txtId.Text));
                }
            }
        }

        private void TraerPorId(int id)
        {
            try
            {
                _libro = _libroBol.TraerPorId(id);

                if (_libro != null)
                {
                    //txtId.Text = Convert.ToString(_libro.id);
                    txtId.Text = Convert.ToString(_libro.id);
                    txtTitulo.Text = _libro.titulo;
                    txtAutor.Text = _libro.autor;
                    txtClasificacion.Text = _libro.clasificacion;
                    nuExistencias.Text = _libro.existencias;
                    txtISBN.Text = _libro.isbn;

                }
                else
                    MessageBox.Show("El libro solicitado no existe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado2");
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                Guardar();
                limpiar();
            }
        }

        private void Guardar()
        {
            try
            {
                if (_libro == null) _libro = new ELibro();


                _libro.id = Convert.ToInt32(txtId.Text);
                _libro.titulo = txtTitulo.Text;
                _libro.autor = txtAutor.Text;
                _libro.clasificacion = txtClasificacion.Text;
                _libro.existencias = (nuExistencias.Value).ToString();
                _libro.isbn = txtISBN.Text;
                
                

                _libroBol.Registrar(_libro);

                if (_libroBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_libroBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("registrado/actualizado con éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtId.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtClasificacion.Clear();
            nuExistencias.ResetText();
            txtISBN.Clear();
        }

        private void FrmLibro_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                using (new CursorWait())
                {
                    TraerPorId(Convert.ToInt32(id));
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
