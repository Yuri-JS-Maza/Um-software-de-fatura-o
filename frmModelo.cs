using System;
using System.Windows.Forms;
using Camada_Negocio;

namespace Camada_Apresentacao
{
    public partial class frmModelo : Form
    {
        public frmModelo()
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
                Cs_Modelo_Negocio modelo = new Cs_Modelo_Negocio();
                modelo.Nome = txtNome.Text;
                modelo.Cadastrar();
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
                Cs_Modelo_Negocio modelo = new Cs_Modelo_Negocio();
                modelo.Nome = txtNome.Text;

                if (!string.IsNullOrEmpty(txtId.Text))
                    modelo.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                modelo.Alterar();
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
                Cs_Modelo_Negocio modelo = new Cs_Modelo_Negocio();

                if (!string.IsNullOrEmpty(txtId.Text))
                    modelo.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                modelo.Eliminar();
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

        private void frmModelo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
