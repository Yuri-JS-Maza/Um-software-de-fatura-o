using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camada_Apresentacao
{
    public partial class frmImprimir : Form
    {
        public frmImprimir()
        {
            InitializeComponent();
        }

        public frmImprimir(DataTable dataTable, string empresa,string funcionario)
        {
            InitializeComponent();

            reportViewer1.Reset();
           
            ReportDataSource ds = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Add(ds); 
            reportViewer1.LocalReport.ReportEmbeddedResource = "Camada_Apresentacao.rtpVendas.rdlc";
            //reportViewer1.LocalReport.ReportEmbeddedResource = @".\Relatorio\rtpVendas.rdlc";
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[3];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("empresa", empresa);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("funcionario", funcionario);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("data_impresao", DateTime.Now.ToString());


            reportViewer1.LocalReport.SetParameters(p);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();

        }

        private void frmImprimir_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
