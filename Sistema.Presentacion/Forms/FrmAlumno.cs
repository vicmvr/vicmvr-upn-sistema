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
    public partial class FrmAlumno : Form
    {
        //
        //
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private EAlumno _alumno;
        private readonly AlumnoBol _alumnoBol = new AlumnoBol();

        public FrmAlumno()
        {
            InitializeComponent();
        }
        //
        //Limpiamos los controles
        //
        private void Nuevo()
        {
            txtId.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtNombre.Clear();
            txtSexo.Clear();
            txtPrograma.Clear();
            txtGrupo.Clear();
            txtMatricula.Clear();
            txtCURP.Clear();
            txtIdCreson.Clear();
            txtReferencia.Clear();
            txtSangre.Clear();
            txtFechaNac.Clear();
            txtNSS.Clear();
            txtCelular.Clear();
            txtTelefono.Clear();
            txtEdoNac.Clear();
            txtGeneracion.Clear();
            txtCorreo.Clear();
            txtBachillerato.Clear();
            txtPromBachillerato.Clear();
            txtComentario.Clear();
            txtDireccion.Clear();
            pictureBoxFoto.Image = originalImage;
            txtId.Focus();
        }
        //
        //Creamos los métodos generales llenando y leyendo objetos
        //
        private void Guardar()
        {
            try
            {
                if (_alumno == null) _alumno = new EAlumno();


                _alumno.apellidop = txtApellidoP.Text;
                _alumno.apellidom = txtApellidoM.Text;
                _alumno.nombre = txtNombre.Text;
                _alumno.matricula = txtMatricula.Text;
                _alumno.curp = txtCURP.Text;
                _alumno.referencia = txtReferencia.Text;
                _alumno.programa = txtPrograma.Text;
                _alumno.grupo = txtGrupo.Text;
                _alumno.generacion = txtGeneracion.Text;
                _alumno.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                _alumno.edonac = txtEdoNac.Text;
                _alumno.sexo = txtSexo.Text;
                _alumno.nss = txtNSS.Text;
                _alumno.sangre = txtSangre.Text;
                _alumno.telefonoCelular = txtCelular.Text;
                _alumno.telefonoCasa = txtTelefono.Text;
                _alumno.correo = txtCorreo.Text;
                _alumno.bachillerato = txtBachillerato.Text;
                _alumno.prombachillerato = txtPromBachillerato.Text;
                _alumno.direccion = txtDireccion.Text;
                _alumno.comentario = txtComentario.Text;
                
        _alumnoBol.Registrar(_alumno);

                if (_alumnoBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_alumnoBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Alumno registrado/actualizado con éxito");

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
            List<EAlumno> alumnos = _alumnoBol.Todos();

            if (alumnos.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.DataSource = alumnos;
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

        private void TraerPorId(int id)
        {
            try
            {
                _alumno = _alumnoBol.TraerPorId(id);

                if (_alumno != null)
                {
                    //txtId.Text = Convert.ToString(_alumno.id);
                    txtApellidoP.Text = _alumno.apellidop;
                    txtApellidoM.Text = _alumno.apellidom;
                    txtNombre.Text = _alumno.nombre;
                    txtSexo.Text = _alumno.sexo;

                    txtPrograma.Text = _alumno.programa;
                    txtGrupo.Text = _alumno.grupo;
                    txtMatricula.Text = _alumno.matricula;
                    txtCURP.Text = _alumno.curp;
                    txtIdCreson.Text = _alumno.idcreson;
                    txtReferencia.Text = _alumno.referencia;
                    txtSangre.Text = _alumno.sangre;
                    txtFechaNac.Text = Convert.ToString(_alumno.fechaNacimiento);
                    txtNSS.Text = _alumno.nss;
                    txtCelular.Text = _alumno.telefonoCelular;
                    txtTelefono.Text = _alumno.telefonoCasa;
                    txtEdoNac.Text = _alumno.edonac;
                    txtGeneracion.Text = _alumno.generacion;
                    txtCorreo.Text = _alumno.correo;
                    txtBachillerato.Text = _alumno.bachillerato;
                    txtPromBachillerato.Text = _alumno.prombachillerato;
                    txtComentario.Text = _alumno.comentario;
                    txtDireccion.Text = _alumno.direccion;
                }
                else
                    MessageBox.Show("El alumno solicitado no existe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado2");
            }
        }

        private void Eliminar(int id)
        {
            try
            {
                _alumnoBol.Eliminar(id);

                MessageBox.Show("Producto eliminado satisfactoriamente");

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

                if (subimg == true)
                {
                    //////////////PARA GUARDAR IMAGEN EN ZISE ORIGINAL/////////////////
                    img = ImgABytes(Ubicacion);
                    GuardarImagen(BytesAImg(img));
                    /////////////////////////////////////////////////////////////////
                    /////GUARDA REDIMENSIONADA 135,85 CON LA FUNCION Redimensionar()
                    //Redimensionar(pictureBox1.Image, "imgNombre");
                    img = ImgABytes(Redimensionar(pictureBoxFoto.Image, "imgNombre"));
                    GuardarImagen(BytesAImg(img));
                    /////////////////////////////////////////////////////////////////
                }
                //Nuevo();
            }
        }

        public void GuardarImagen(Image imagen)
        {
            img = ImgABytes(Ubicacion);
            pictureBoxFoto.Image = BytesAImg(img);

            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, ImageFormat.Png);
                byte[] imgArr = ms.ToArray();
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["Sistema.Properties.Settings.ConnectionString"].ConnectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@imgArr", imgArr);
                        cmd.CommandText = "UPDATE alumno SET foto = (@imgArr) WHERE id=" + txtId.Text + ";";
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
        }
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (new CursorWait())
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    TraerPorId(Convert.ToInt32(txtId.Text));
                    pictureBoxFoto.Image = originalImage;
                    if (CargarImagen() != null)
                    {
                        pictureBoxFoto.Image = CargarImagen();
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
            originalImage = pictureBoxFoto.Image;
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
                    cmd.CommandText = "SELECT foto FROM alumno WHERE id=" + txtId.Text + ";";
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
        //METODO PARA REDIMENSIONAR LA IMAGEN
        public String Redimensionar(Image Imagen_Original, string nombre)
        {

            //RUTA DEL DIRECTORIO TEMPORAL
            String DirTemp = Path.GetTempPath() + @"\" + nombre + ".jpg";

            //IMAGEN ORIGINAL A REDIMENSIONAR
            Bitmap imagen = new Bitmap(Imagen_Original);

            //CREAMOS UN MAPA DE BIT CON LAS DIMENSIONES QUE QUEREMOS PARA LA NUEVA IMAGEN
            //Bitmap nuevaImagen = new Bitmap(Imagen_Original.Width, Imagen_Original.Height);
            Bitmap nuevaImagen = new Bitmap(135, 85);

            //CREAMOS UN NUEVO GRAFICO
            Graphics gr = Graphics.FromImage(nuevaImagen);

            //DIBUJAMOS LA NUEVA IMAGEN
            gr.DrawImage(imagen, 0, 0, nuevaImagen.Width, nuevaImagen.Height);

            //LIBERAMOS RECURSOS
            gr.Dispose();

            //GUARDAMOS LA NUEVA IMAGEN ESPECIFICAMOS LA RUTA Y EL FORMATO
            nuevaImagen.Save(DirTemp, System.Drawing.Imaging.ImageFormat.Jpeg);

            //LIBERAMOS RECURSOS
            nuevaImagen.Dispose();

            imagen.Dispose();

            return DirTemp;

        }
        //IMG A BYTES
        //IMG A BYTES
        public Byte[] ImgABytes(String ruta)
        {
            FileStream img = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Byte[] arreglo = new Byte[img.Length];
            BinaryReader reader = new BinaryReader(img);
            arreglo = reader.ReadBytes(Convert.ToInt32(img.Length));
            img.Close();
            return arreglo;
        }
        //BYTES A IMG
        public Image BytesAImg(Byte[] ImgBytes)
        {
            Bitmap img = null;
            Byte[] bytes = (Byte[])(ImgBytes);
            MemoryStream ms = new MemoryStream(bytes);
            img = new Bitmap(ms);
            return img;
        }
        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //DIRECTORIO POR DEFECTO DONDE SE BUSCARA LA IMAGEN
            openFileDialog1.InitialDirectory = "c:\\fotos";
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    txtImagen.Text = openFileDialog1.FileName;
                    Ubicacion = openFileDialog1.FileName;
                    img = ImgABytes(Ubicacion);
                    pictureBoxFoto.Image = BytesAImg(img);
                    subimg = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se pudo encontrar el archivo: " + ex);
                }
            }
            else
            {
                subimg = false;
            }
            using (new CursorWait())
            {
                if (subimg == true)
                {
                    img = ImgABytes(Ubicacion);
                    GuardarImagen(BytesAImg(img));
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
            int b = Convert.ToInt32(txtId.Text);
            if(b>=2)
                txtId.Text = (b - 1).ToString();
            btnBuscar.PerformClick();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int b = Convert.ToInt32(txtId.Text);
            if (b <= 499)
                txtId.Text = (b + 1).ToString();
            btnBuscar.PerformClick();
        }
    }
}