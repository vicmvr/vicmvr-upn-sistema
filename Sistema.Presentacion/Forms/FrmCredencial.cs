using MySql.Data.MySqlClient;
using Sistema.Entidades;
using Sistema.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Forms
{
    public partial class FrmCredencial : Form
    {
        //Creamos las instancias de la clase EAlumno y AlumnoBol
        private EAlumno _alumno;
        private readonly AlumnoBol _alumnoBol = new AlumnoBol();

        public FrmCredencial()
        {
            InitializeComponent();
        }
        private void CapturaFormulario()
        {
            Size sz = groupBox1.Size;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppPArgb);//.Format32bppRgb);
            
            //bmp.SetResolution(200, 200);            
            Graphics memoryGraphics = Graphics.FromImage(bmp);

            memoryGraphics.CopyFromScreen(this.Location.X+22, this.Location.Y+44, 0, 0, sz,
                                          CopyPixelOperation.SourceCopy);

            // bmp.Save("prueba.bmp", ImageFormat.Bmp);
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.Filter = "Imagen jpg|*.jpg";
            guarda.FileName = lblApellidos.Text + " " + lblNombre.Text;
            guarda.ShowDialog();
            if (guarda.FileName != "")
            {
                //FileStream flujo = new FileStream(guarda.FileName, FileMode.Create, FileAccess.Write);
                //bmp.Save(flujo, System.Drawing.Imaging.ImageFormat.Bmp);
                //flujo.Close();
                //bmp.Dispose();
                string filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "image.png");

                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(this.Location.X + 22, this.Location.Y + 44, 0, 0, sz,
                                          CopyPixelOperation.SourceCopy);

                Bitmap b2 = new Bitmap(sz.Width*30, sz.Height*30);
                g = Graphics.FromImage(b2);
                g.DrawImage(bmp, new RectangleF(0, 0, b2.Width, b2.Height));

                b2.Save(guarda.FileName, ImageFormat.Jpeg);
                System.Diagnostics.Process.Start(guarda.FileName);  
            }
            //Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CapturaFormulario();
            //using (Graphics gfx = form.CreateGraphics())
            //{
            //    using (Bitmap bmp = new Bitmap(form.Width, form.Height, gfx))
            //    {
            //        form.DrawToBitmap(bmp, new Rectangle(0, 0, form.Width, form.Height));
            //        bmp.Save(fileName);
            //    }
            //}
            //SaveFileDialog guarda = new SaveFileDialog();
            //guarda.Filter = "Imagen jpg|*.jpg";
            //guarda.ShowDialog();
            //if (guarda.FileName != "")
            //{
            //    Bitmap bm = new Bitmap(groupBox1.Width,groupBox1.Height);
            //    groupBox1.DrawToBitmap(bm, new Rectangle(0, 0, groupBox1.Width, groupBox1.Height));
            //    FileStream flujo = new FileStream(guarda.FileName,FileMode.Create,FileAccess.Write);
            //    bm.Save(flujo, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    flujo.Close();
            //    bm.Dispose();

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
                    //pictureBoxFoto.Image = originalImage;
                    if (CargarImagen() != null)
                    {
                        pictureBoxFoto.Image = CargarImagen();
                    }
                }
            }
        }

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
        private void TraerPorId(int id)
        {
            try
            {
                _alumno = _alumnoBol.TraerPorId(id);

                if (_alumno != null)
                {
                    lblNombre.Text = _alumno.nombre;
                    lblApellidos.Text = _alumno.apellidop + " " + _alumno.apellidom;
                    lblPrograma.Text = _alumno.programa;
                    lblMatricula.Text = _alumno.matricula;
                    lblCURP.Text = _alumno.curp;
                    lblTipoSangre.Text = _alumno.sangre;
                    
                    
                    //txtId.Text = Convert.ToString(_alumno.id);

                    //txtApellidoP.Text = _alumno.apellidop;
                    //txtApellidoM.Text = _alumno.apellidom;
                    //txtNombre.Text = _alumno.nombre;
                    //txtSexo.Text = _alumno.sexo;

                    //txtPrograma.Text = _alumno.programa;
                    //txtGrupo.Text = _alumno.grupo;
                    //txtMatricula.Text = _alumno.matricula;
                    //txtCURP.Text = _alumno.curp;
                    //txtIdCreson.Text = _alumno.idcreson;
                    //txtReferencia.Text = _alumno.referencia;
                    //txtSangre.Text = _alumno.sangre;
                    //txtFechaNac.Text = Convert.ToString(_alumno.fechaNacimiento);
                    //txtNSS.Text = _alumno.nss;
                    //txtCelular.Text = _alumno.telefonoCelular;
                    //txtTelefono.Text = _alumno.telefonoCasa;
                    //txtEdoNac.Text = _alumno.edonac;
                    //txtGeneracion.Text = _alumno.generacion;
                    //txtCorreo.Text = _alumno.correo;
                    //txtBachillerato.Text = _alumno.bachillerato;
                    //txtPromBachillerato.Text = _alumno.prombachillerato;
                    //txtComentario.Text = _alumno.comentario;
                    //txtDireccion.Text = _alumno.direccion;
                }
                else
                    MessageBox.Show("El alumno solicitado no existe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado2");
            }
        }
    }
    
    }

