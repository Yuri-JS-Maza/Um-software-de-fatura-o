using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camada_Negocio;

namespace Camada_Apresentacao
{
    public partial class frmFinalizarVenda : Form
    {
        public frmFinalizarVenda()
        {
            InitializeComponent();
        }

        async Task<DataTable> CarregarTodasFormasPagamento()
        {
            //picMarca.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Forma_Pagamento_Negocio formaPagamentoNegocio = new Cs_Forma_Pagamento_Negocio();
                dt = formaPagamentoNegocio.GetFormaDePagamentoAll();
                DataRow linha = dt.NewRow();
                linha[1] = "";
                dt.Rows.InsertAt(linha, 0);
                //picMarca.Invoke((MethodInvoker)(() => picMarca.Visible = false));
                return dt;
            });
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboFormaPagamento.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Erro","Forma de pagamento inválido",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.Yes;
            }
        }

        private async void frmFinalizarVenda_Load(object sender, EventArgs e)
        {
            cboFormaPagamento.DataSource = await CarregarTodasFormasPagamento();
            cboFormaPagamento.DisplayMember = "nome_Forma_Pagamento";
            cboFormaPagamento.ValueMember = "id_Forma_Pagamento";

        }
    }
}
