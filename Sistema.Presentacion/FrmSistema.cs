using DevExpress.XtraReports.UI;
using Sistema.Presentacion.Biblioteca;
using Sistema.Presentacion.Forms;
using Sistema.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmSistema : System.Windows.Forms.Form
    {
        public FrmSistema()
        {
            InitializeComponent();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new FrmAlumno();
            about.ShowDialog();
        }


        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButtonAlumnos_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmAlumno")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmAlumno formulario = new FrmAlumno();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void toolStripButtonUsuarios_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmUsuario")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmUsuario formulario = new FrmUsuario();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporte reporte = new FrmReporte();
            FrmReporte.titulo = "Credenciales";
            FrmReporte.ruta = "Credenciales.rpt";
            reporte.TopMost = true;
            reporte.Show();
        }

        private void toolStripButtonBiblioteca_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmBiblioteca")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmBiblioteca formulario = new FrmBiblioteca();
            formulario.WindowState = FormWindowState.Maximized;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void FrmSistema_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRecibos_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmRecibos")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmRecibos formulario = new FrmRecibos();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmConexion")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmConexion formulario = new FrmConexion();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmConexion")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmConexion formulario = new FrmConexion();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void toolStripButtonDocentes_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmDocente")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmDocente formulario = new FrmDocente();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.ShowDialog();
            formulario.Show();
            formulario.TopMost = true;
        }

        private void toolStripButtonGrupos_Click(object sender, EventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmGrupo")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmGrupo formulario = new FrmGrupo();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.ShowDialog();
            formulario.Show();
            formulario.TopMost = true;
        }

        private void toolStripButtonCarga_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCarga")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCarga formulario = new FrmCarga();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.ShowDialog();
            formulario.Show();
            formulario.TopMost = true;
        }

        private void toolStripButtonAsignaturas_Click(object sender, EventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmAsignatura")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmAsignatura formulario = new FrmAsignatura();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.ShowDialog();
            formulario.Show();
            formulario.TopMost = true;
        }

        private void toolStripButtonReporte_Click(object sender, EventArgs e)
        {


            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (frm.Name == "FrmReporte")
            //    {
            //        frm.Activate();
            //        return;
            //    }
            //}
            //Reportes.FrmReporte formulario = new Reportes.FrmReporte();
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.StartPosition = FormStartPosition.CenterParent;
            ////formulario.ShowDialog();
            //formulario.Show();
            //formulario.TopMost = true;



            //int vi = cbDeptos.SelectedIndex;
            //int vi2 = cbSucursal.SelectedIndex;

            XtraReportBoletos report = new XtraReportBoletos();
            //Parameter param1 = new Parameter();
            //Parameter param2 = new Parameter();
            //param1.Name = "Sucursal";
            //param2.Name = "Departamento";
            //param1.Type = typeof(System.Int32);
            //param1.Value = tablaSuc.Rows[vi2][0];
            //param1.Description = "SUCURSAL: ";
            //param1.Visible = true;

            //param2.Type = typeof(System.Int32);
            //param2.Value = tablacat.Rows[vi][0];
            //param2.Description = "DEPARTAMENTO: ";
            //param2.Visible = true;

            //report.Parameters.Add(param1);
            //report.Parameters.Add(param2);
            //report.FilterString = "[ID_Sucursal] = [Parameters.Sucursal] AND [idDepartamento] = [Parameters.Departamento]";
            //report.RequestParameters = false;

            ReportPrintTool pt = new ReportPrintTool(report);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreviewDialog();

        }
    }
}
