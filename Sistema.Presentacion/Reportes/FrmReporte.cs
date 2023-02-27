using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Reportes
{
    public partial class FrmReporte : Form
    {
        public static string titulo, ruta;
        private void Anexo31_InitReport(object sender, EventArgs e)
        {

        }

        public FrmReporte()
        {
            InitializeComponent();
        }
        public void cargarreporte()
        {
            //ParameterField param, param2, param3, param4;
            //ParameterDiscreteValue discreteValue, discreteValue2, discreteValue3, discreteValue4;
            //ParameterDiscreteValue parameterDiscreteValue, parameterDiscreteValue2, parameterDiscreteValue3, parameterDiscreteValue4;
            //ParameterFields parameterFields;
            //ParameterFields paramFiels = new ParameterFields();
            switch (ruta)
            {
                case "Credenciales.rpt":

                    //
                    // Asigno la coleccion de parametros al Crystal Viewer
                    //

                    Reportes.Credenciales crys = new Reportes.Credenciales();
                    crys.Load(@"Reportes\\" + ruta);
                    crystalReportViewer1.ReportSource = crys;
                    crys.Refresh();

                    // ParameterField param = new ParameterField();
                    //case "registro.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "idsocio";

                    //    discreteValue = new ParameterDiscreteValue();
                    //    discreteValue.Value = numsocio;
                    //    param.CurrentValues.Add(discreteValue);
                    //    param2 = new ParameterField();
                    //    param2.ParameterFieldName = "propia";
                    //    param3 = new ParameterField();
                    //    param3.ParameterFieldName = "rentada";
                    //    param4 = new ParameterField();
                    //    param4.ParameterFieldName = "estado";
                    //    //
                    //    // Asigno la coleccion de parametros al Crystal Viewer
                    //    //
                    //    discreteValue2 = new ParameterDiscreteValue();
                    //    discreteValue2.Value = propio;
                    //    param2.CurrentValues.Add(discreteValue2);
                    //    discreteValue3 = new ParameterDiscreteValue();
                    //    discreteValue3.Value = rentada;
                    //    param3.CurrentValues.Add(discreteValue3);
                    //    discreteValue4 = new ParameterDiscreteValue();
                    //    discreteValue4.Value = estado;
                    //    param4.CurrentValues.Add(discreteValue4);
                    //    //
                    //    paramFiels = new ParameterFields();
                    //    paramFiels.Add(param);
                    //    paramFiels.Add(param2);
                    //    paramFiels.Add(param3);
                    //    paramFiels.Add(param4);
                    //    crystalReportViewer1.ParameterFieldInfo = paramFiels;
                    //    Reportes.registro crys = new Reportes.registro();
                    //    crys.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crys;
                    //    crys.Refresh();
                    //    break;

                    //case "Anexo3.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "idsocio";

                    //    //
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = numsocio;
                    //    param.CurrentValues.Add(parameterDiscreteValue);

                    //    //
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    Reportes.Anexo3 crysanexo3 = new Reportes.Anexo3();
                    //    crysanexo3.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crysanexo3;
                    //    crysanexo3.Refresh();
                    //    break;

                    //case "Anexo15.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "inicio";
                    //    param2 = new ParameterField();
                    //    param2.ParameterFieldName = "final";
                    //    //###################################################
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = inicio;
                    //    param.CurrentValues.Add(parameterDiscreteValue);
                    //    parameterDiscreteValue2 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue2.Value = final;
                    //    param2.CurrentValues.Add(parameterDiscreteValue2);
                    //    //###################################################
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    parameterFields.Add(param2);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    //###################################################
                    //    Reportes.Anexo15 crys15 = new Reportes.Anexo15();
                    //    crys15.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crys15;
                    //    crys15.Refresh();
                    //    break;
                    //case "Anexo4.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "idretiro";
                    //    param2 = new ParameterField();
                    //    param2.ParameterFieldName = "parcial";
                    //    param3 = new ParameterField();
                    //    param3.ParameterFieldName = "total";
                    //    param4 = new ParameterField();
                    //    param4.ParameterFieldName = "cantidadletra";
                    //    //###################################################
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = idretiro;
                    //    param.CurrentValues.Add(parameterDiscreteValue);
                    //    parameterDiscreteValue2 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue2.Value = parcial;
                    //    param2.CurrentValues.Add(parameterDiscreteValue2);
                    //    parameterDiscreteValue3 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue3.Value = total;
                    //    param3.CurrentValues.Add(parameterDiscreteValue3);
                    //    parameterDiscreteValue4 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue4.Value = cantidadletra;
                    //    param4.CurrentValues.Add(parameterDiscreteValue4);
                    //    //###################################################
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    parameterFields.Add(param2);
                    //    parameterFields.Add(param3);
                    //    parameterFields.Add(param4);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    //###################################################
                    //    Reportes.Anexo4 retiro = new Reportes.Anexo4();
                    //    retiro.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = retiro;
                    //    retiro.Refresh();
                    //    break;
                    //case "Anexo7.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "cantidadletra";
                    //    param2 = new ParameterField();
                    //    param2.ParameterFieldName = "idprestamo";
                    //    //###################################################
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = cantidadletra;
                    //    param.CurrentValues.Add(parameterDiscreteValue);
                    //    parameterDiscreteValue2 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue2.Value = idprestamo;
                    //    param2.CurrentValues.Add(parameterDiscreteValue2);
                    //    //###################################################
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    parameterFields.Add(param2);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    //###################################################
                    //    Reportes.Anexo7 crys7 = new Reportes.Anexo7();
                    //    crys7.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crys7;
                    //    crys7.Refresh();
                    //    break;

                    //case "Anexo11.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "idsocio";

                    //    //###################################################
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = numsocio;
                    //    param.CurrentValues.Add(parameterDiscreteValue);
                    //    //###################################################
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    //###################################################
                    //    Reportes.Anexo11 crys11 = new Reportes.Anexo11();
                    //    crys11.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crys11;
                    //    crys11.Refresh();
                    //    break;

                    //case "Anexo2.rpt":
                    //    //
                    //    // creo el valor que se asignara al parametro
                    //    //
                    //    param = new ParameterField();
                    //    param.ParameterFieldName = "cantidadletra";
                    //    param2 = new ParameterField();
                    //    param2.ParameterFieldName = "iddeposito";
                    //    //###################################################
                    //    parameterDiscreteValue = new ParameterDiscreteValue();
                    //    parameterDiscreteValue.Value = cantidadletra;
                    //    param.CurrentValues.Add(parameterDiscreteValue);
                    //    parameterDiscreteValue2 = new ParameterDiscreteValue();
                    //    parameterDiscreteValue2.Value = iddeposito;
                    //    param2.CurrentValues.Add(parameterDiscreteValue2);
                    //    //###################################################
                    //    parameterFields = new ParameterFields();
                    //    parameterFields.Add(param);
                    //    parameterFields.Add(param2);
                    //    crystalReportViewer1.ParameterFieldInfo = parameterFields;
                    //    //###################################################
                    //    Reportes.Anexo2 crys2 = new Reportes.Anexo2();
                    //    crys2.Load(@"Reportes\\" + ruta);
                    //    crystalReportViewer1.ReportSource = crys2;
                    //    crys2.Refresh();
                    break;
            }
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            this.Text = titulo;
            cargarreporte();
        }

    }

}
