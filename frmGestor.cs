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
    public partial class frmGestor : Form
    {
        Cs_Gestor_Negocio gestorNegocio;
        public uint IdPessoa { get; set; }
        public short IdGestor { get; set; }
        public uint IdEndereco { get; set; }
        public uint IdContacto { get; set; }

        public frmGestor()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                gestorNegocio = new Cs_Gestor_Negocio();
                gestorNegocio.Nome = txtNome.Text;
                gestorNegocio.Sobrenome = txtSobrenome.Text;

                if (string.IsNullOrEmpty(cboGenero.Text.Trim()))
                {
                    throw new Exception("O campo Gênero não pode estar vazio");
                }
                else
                {
                    if (cboGenero.Text.Trim().ToUpper() != "M" && cboGenero.Text.Trim().ToUpper() != "F")
                        throw new Exception("Gênero Inválido");
                    else
                        gestorNegocio.Genero = char.Parse(cboGenero.Text);
                }
                gestorNegocio.BI = txtNumBI.Text;
                gestorNegocio.DataNascimento = DateTime.Parse(dtpNascimento.Text);
                gestorNegocio.DataAdmissao = DateTime.Parse(dTPAdmissao.Text);
                gestorNegocio.NumCredencial = txtCredencial.Text;
                gestorNegocio.Status = cbStatus.Checked;
                
                gestorNegocio.Endereco = new Cs_Endereco_Negocio()
                {
                    Provincia = txtProvincia.Text,
                    Municipio = txtMunicipio.Text,
                    Bairro = txtBairro.Text,
                    Rua = txtRua.Text,
                    Casa = txtCasa.Text
                };

                gestorNegocio.Contacto = new Cs_Contacto_Negocio()
                {
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text
                };

                MessageBox.Show(gestorNegocio.Cadastrar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                gestorNegocio = new Cs_Gestor_Negocio();
                gestorNegocio.IdPessoa = IdPessoa;
                gestorNegocio.IdGestor = IdGestor;
                gestorNegocio.Nome = txtNome.Text;
                gestorNegocio.Sobrenome = txtSobrenome.Text;

                if (string.IsNullOrEmpty(cboGenero.Text.Trim()))
                {
                    throw new Exception("O campo Gênero não pode estar vazio");
                }
                else
                {
                    if (cboGenero.Text.Trim().ToUpper() != "M" && cboGenero.Text.Trim().ToUpper() != "F")
                        throw new Exception("Gênero Inválido");
                    else
                        gestorNegocio.Genero = char.Parse(cboGenero.Text);
                }
                gestorNegocio.BI = txtNumBI.Text;
                gestorNegocio.DataNascimento = DateTime.Parse(dtpNascimento.Text);
                gestorNegocio.DataAdmissao = DateTime.Parse(dTPAdmissao.Text);
                gestorNegocio.NumCredencial = txtCredencial.Text;
                gestorNegocio.Status = cbStatus.Checked;

                gestorNegocio.Endereco = new Cs_Endereco_Negocio()
                {
                    IdEndereco = IdEndereco,
                    Provincia = txtProvincia.Text,
                    Municipio = txtMunicipio.Text,
                    Bairro = txtBairro.Text,
                    Rua = txtRua.Text,
                    Casa = txtCasa.Text
                };

                gestorNegocio.Contacto = new Cs_Contacto_Negocio()
                {
                    IdContacto = IdContacto,
                    Telefone = txtTelefone.Text,
                    Email = txtEmail.Text
                };

                MessageBox.Show(gestorNegocio.Alterar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                gestorNegocio = new Cs_Gestor_Negocio();
                gestorNegocio.IdPessoa = IdPessoa;
                gestorNegocio.IdGestor = IdGestor;

                gestorNegocio.Endereco = new Cs_Endereco_Negocio()
                {
                    IdEndereco = IdEndereco
                };

                gestorNegocio.Contacto = new Cs_Contacto_Negocio()
                {
                    IdContacto = IdContacto
                };

                MessageBox.Show(gestorNegocio.Alterar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
