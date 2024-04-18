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
    public partial class frmFormaPagamento : Form
    {
        public frmFormaPagamento()
        {
            InitializeComponent();
        }

        void Limpar()
        {
            txtId.Clear();
            txtNome.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Forma_Pagamento_Negocio formaDePagamento = new Cs_Forma_Pagamento_Negocio();
                formaDePagamento.Nome = txtNome.Text;
                formaDePagamento.Cadastrar();
                MessageBox.Show("Cadastro com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cadastro não efectuado " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Forma_Pagamento_Negocio formaDePagamento = new Cs_Forma_Pagamento_Negocio();
                formaDePagamento.Nome = txtNome.Text;

                if (!string.IsNullOrEmpty(txtId.Text))
                    formaDePagamento.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                formaDePagamento.Alterar();
                MessageBox.Show("Alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alteração não efectuada " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Forma_Pagamento_Negocio formaDePagamento = new Cs_Forma_Pagamento_Negocio();

                if (!string.IsNullOrEmpty(txtId.Text))
                    formaDePagamento.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                formaDePagamento.Eliminar();
                MessageBox.Show("Eliminado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminação não efectuada " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmFormaPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
