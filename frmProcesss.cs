using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camada_Apresentacao
{
    public partial class frmProcesss : Form
    {
        int totalImagem = 10;
        int imagemAutal = 0;

        public frmProcesss()
        {
            InitializeComponent();

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = imagemAutal; i <= totalImagem; i++)
                {
                    pictureBox1.Image = Image.FromFile(@".\img\" + i.ToString() + ".jpg");

                    backgroundWorker1.ReportProgress((i * 100) / totalImagem);
                    Thread.Sleep(650);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            new frm_Login().Show();
            this.Hide();

        }
    }
}
