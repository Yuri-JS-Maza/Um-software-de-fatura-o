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
using Camada_Negocio;

namespace Camada_Apresentacao
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        public Cs_Cliente_Negocio clienteNegocio = new Cs_Cliente_Negocio();
        public bool status { get; set; }
        async Task<DataTable> CarregarDadosTipoCliente()
        {
            //picModelo.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();

                Cs_Tipo_Cliente_Fornecedor_Negocio tipoCli_Forn = new Cs_Tipo_Cliente_Fornecedor_Negocio();
                dt = tipoCli_Forn.GetTipoClienteFornecedorAll();
                //picModelo.Invoke((MethodInvoker)(() => picModelo.Visible = false));
                return dt;
            });
        }

        private async void frmCliente_Load(object sender, EventArgs e)
        {
            cboTipoCliente.DataSource = await CarregarDadosTipoCliente();            

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cboTipoCliente.SelectedValue != null || !string.IsNullOrEmpty(cboTipoCliente.SelectedValue.ToString().Trim()))
            {
                clienteNegocio = new Cs_Cliente_Negocio()
                {
                    Nome = txtNome.Text,
                    Nif_Bi = txtNif_BI.Text,
                    Id_Tipo_Cliente = short.Parse(cboTipoCliente.SelectedValue.ToString()),
                    EnderecoCliente = new Cs_Endereco_Negocio()
                    {
                        Provincia = txtProvincia.Text,
                        Municipio = txtMunicipio.Text,
                        Bairro = txtBairro.Text,
                        Rua = txtRua.Text,
                        Casa = txtCasa.Text
                    },
                    ContactoCliente = new Cs_Contacto_Negocio()
                    {
                        Telefone = txtTelefone.Text,
                        Email = txtEmail.Text
                    }
                };
                clienteNegocio.Cadastrar();
                MessageBox.Show("Sucesso!");
            }
            else
            {
                throw new Exception("Selecione o tipo de cliente");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            clienteNegocio = new Cs_Cliente_Negocio();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clienteNegocio = new Cs_Cliente_Negocio();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

        }

        private void btnIdentificar_Click(object sender, EventArgs e)
        {
            try
            {
                clienteNegocio = new Cs_Cliente_Negocio()
                {
                    Nome = txtNome.Text,
                    Nif_Bi = txtNif_BI.Text,
                    Id_Tipo_Cliente = short.Parse(cboTipoCliente.SelectedValue.ToString()),
                    EnderecoCliente = new Cs_Endereco_Negocio()
                    {
                        Provincia = txtProvincia.Text,
                        Municipio = txtMunicipio.Text,
                        Bairro = txtBairro.Text,
                        Rua = txtRua.Text,
                        Casa = txtCasa.Text
                    },
                    ContactoCliente = new Cs_Contacto_Negocio()
                    {
                        Telefone = txtTelefone.Text,
                        Email = txtEmail.Text
                    }
                };
                DialogResult = DialogResult.Yes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro",ex.Message,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            

        }
    }
}