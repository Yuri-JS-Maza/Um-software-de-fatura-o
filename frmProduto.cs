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
    public partial class frmProduto : Form
    {
        public object IdCategoria { get; set; }
        public object IdMarca { get; set; }
        public object IdModelo { get; set; }
        public object IdUnidade { get; set; }
        public bool Status { get; set; }

        public frmProduto(bool status)
        {
            InitializeComponent();            
            Status = status;

            if (Status)
                btnCadastrar.Enabled = false;
        }

        async Task<DataTable> CarregarTodasCategorias()
        {
            picCategoria.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Categoria_Negocio categoriaModelo = new Cs_Categoria_Negocio();
                dt = categoriaModelo.GetCategoriasAll();
                DataRow linha = dt.NewRow();
                linha[1] = "";
                dt.Rows.InsertAt(linha, 0);
                picCategoria.Invoke((MethodInvoker)(() => picCategoria.Visible = false));
                return dt;
            });
        }

        async Task<DataTable> CarregarTodasMarcas()
        {
            picMarca.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Marca_Negocio marcaNegocio = new Cs_Marca_Negocio();
                dt = marcaNegocio.GetMarcaAll();
                DataRow linha = dt.NewRow();
                linha[1] = "";
                dt.Rows.InsertAt(linha, 0);
                picMarca.Invoke((MethodInvoker)(() => picMarca.Visible = false));
                return dt;
            });
        }

        async Task<DataTable> CarregarTodasModelos()
        {
            picModelo.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Modelo_Negocio modeloNegocio = new Cs_Modelo_Negocio();
                dt = modeloNegocio.GetModeloAll();
                DataRow linha = dt.NewRow();
                linha[1] = "";
                dt.Rows.InsertAt(linha, 0);
                picModelo.Invoke((MethodInvoker)(() => picModelo.Visible = false));
                return dt;
            });
        }

        async Task<DataTable> CarregarTodasUnidades()
        {
            picUnidade.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Unidade_Negocio unidadeNegocio = new Cs_Unidade_Negocio();
                dt = unidadeNegocio.GetUnidadesAll();
                DataRow linha = dt.NewRow();
                linha[1] = "";
                dt.Rows.InsertAt(linha, 0);
                picUnidade.Invoke((MethodInvoker)(() => picUnidade.Visible = false));
                return dt;
            });
        }

        async void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtQtdMin.Clear();
            txtQuantidade.Clear();
            txtCodigoBarras.Clear();
            dTPValidade.Value = DateTime.Now.Date;
            cboCategoria.DataSource = await CarregarTodasCategorias();
            cboMarca.DataSource = await CarregarTodasMarcas();
            cboModelo.DataSource = await CarregarTodasModelos();
            cboUnidade.DataSource = await CarregarTodasUnidades();
        }

        private async void frmProduto_Load(object sender, EventArgs e)
        {
            try
            {
                cboCategoria.DataSource = await CarregarTodasCategorias();
                cboMarca.DataSource = await CarregarTodasMarcas();
                cboModelo.DataSource = await CarregarTodasModelos();
                cboUnidade.DataSource = await CarregarTodasUnidades();

                if (Status)
                {
                    if(IdCategoria != DBNull.Value)
                        cboCategoria.SelectedValue = IdCategoria;
                    else
                        cboCategoria.SelectedIndex = 0;

                    if (IdMarca != DBNull.Value)
                        cboMarca.SelectedValue = IdMarca;
                    else
                        cboMarca.SelectedIndex = 0;

                    if (IdModelo != DBNull.Value)
                        cboModelo.SelectedValue = IdModelo;
                    else
                        cboModelo.SelectedIndex = 0;

                    if (IdUnidade != DBNull.Value)
                        cboUnidade.SelectedValue = IdUnidade;
                    else
                        cboUnidade.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Produto_Negocio produtoNegocio = new Cs_Produto_Negocio();
                produtoNegocio.Nome = txtNome.Text;
                produtoNegocio.Descricao = txtDescricao.Text;
                produtoNegocio.CodigoDeBarras = txtCodigoBarras.Text;
                produtoNegocio.Validade = DateTime.Parse(dTPValidade.Text);
                double preco = 0;
                float qtd = 0;
                float qtdMin = 0;

                if (double.TryParse(txtPreco.Text, out preco))
                    produtoNegocio.Preco = preco;
                else
                    throw new Exception("Código do Produto Inválido");

                if (float.TryParse(txtQuantidade.Text, out qtd))
                    produtoNegocio.Quantidade = qtd;
                else
                    throw new Exception("Quantidade Inválida");

                if (float.TryParse(txtQtdMin.Text, out qtdMin))
                    produtoNegocio.QuantidadeMinima = qtdMin;
                else
                    throw new Exception("Quantidade Mínima Inválida");

                if (!(cboCategoria.SelectedValue == null || cboCategoria.SelectedValue == DBNull.Value))
                    produtoNegocio.IdCategoria = (short)cboCategoria.SelectedValue;

                if (!(cboMarca.SelectedValue == null || cboMarca.SelectedValue == DBNull.Value))
                    produtoNegocio.IdMarca = (short)cboMarca.SelectedValue;

                if (!(cboModelo.SelectedValue == null || cboModelo.SelectedValue == DBNull.Value))
                    produtoNegocio.IdModelo = (short)cboModelo.SelectedValue;

                if (!(cboUnidade.SelectedValue == null || cboUnidade.SelectedValue == DBNull.Value))
                    produtoNegocio.IdUnidade = (short)cboUnidade.SelectedValue;

                produtoNegocio.Cadastrar();
                MessageBox.Show("Cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Produto_Negocio produtoNegocio = new Cs_Produto_Negocio();
                produtoNegocio.Nome = txtNome.Text;
                produtoNegocio.Descricao = txtDescricao.Text;
                produtoNegocio.CodigoDeBarras = txtCodigoBarras.Text;
                produtoNegocio.Validade = DateTime.Parse(dTPValidade.Text);
                double preco = 0;
                float qtd = 0;
                float qtdMin = 0;
                uint id = 0;

                if (uint.TryParse(txtId.Text, out id))
                    produtoNegocio.Id = id;
                else
                    throw new Exception("Código do Produto Inválido");

                if (double.TryParse(txtPreco.Text, out preco))
                    produtoNegocio.Preco = preco;
                else
                    throw new Exception("Preço Inválido");

                if (float.TryParse(txtQuantidade.Text, out qtd))
                    produtoNegocio.Quantidade = qtd;
                else
                    throw new Exception("Quantidade Inválida");

                if (float.TryParse(txtQtdMin.Text, out qtdMin))
                    produtoNegocio.QuantidadeMinima = qtdMin;
                else
                    throw new Exception("Quantidade Mínima Inválida");

                if (!(cboCategoria.SelectedValue == null || cboCategoria.SelectedValue == DBNull.Value))
                    produtoNegocio.IdCategoria = (short)cboCategoria.SelectedValue;

                if (!(cboMarca.SelectedValue == null || cboMarca.SelectedValue == DBNull.Value))
                    produtoNegocio.IdMarca = (short)cboMarca.SelectedValue;

                if (!(cboModelo.SelectedValue == null || cboModelo.SelectedValue == DBNull.Value))
                    produtoNegocio.IdModelo = (short)cboModelo.SelectedValue;

                if (!(cboUnidade.SelectedValue == null || cboUnidade.SelectedValue == DBNull.Value))
                    produtoNegocio.IdUnidade = (short)cboUnidade.SelectedValue;

                produtoNegocio.Alterar();
                MessageBox.Show("Alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cs_Produto_Negocio produtoNegocio = new Cs_Produto_Negocio();
                uint id = 0;

                if (uint.TryParse(txtId.Text, out id))
                    produtoNegocio.Id = id;
                else
                    throw new Exception("Código do Produto Inválido");

                produtoNegocio.Eliminar();
                MessageBox.Show("Eliminado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
