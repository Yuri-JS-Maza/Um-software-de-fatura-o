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
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Marca_Negocio marca = new Cs_Marca_Negocio();
                marca.Nome = txtNome.Text;
                marca.Cadastrar();
                MessageBox.Show("Cadastro efectuado com sucesso","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cadastro não efectuado " + ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        void Limpar()
        {
            txtId.Clear();
            txtNome.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Marca_Negocio marca = new Cs_Marca_Negocio();
                marca.Nome = txtNome.Text;

                if (!string.IsNullOrEmpty(txtId.Text))
                    marca.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                marca.Alterar();
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
                Cs_Marca_Negocio marca = new Cs_Marca_Negocio();

                if (!string.IsNullOrEmpty(txtId.Text))
                    marca.Id = short.Parse(txtId.Text);
                else
                    throw new Exception("O Campo código não pode estar vázio.");

                marca.Eliminar();
                MessageBox.Show("Eliminado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminação não efectuada " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
