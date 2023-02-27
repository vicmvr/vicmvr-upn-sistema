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
    public partial class FrmBiblioteca : Form
    {
        public FrmBiblioteca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmInventarioBiblioteca")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmInventarioBiblioteca formulario = new FrmInventarioBiblioteca();
            formulario.WindowState = FormWindowState.Maximized;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }
    }
}
