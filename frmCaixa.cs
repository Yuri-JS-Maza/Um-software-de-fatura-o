using System;
using System.Data;
using System.Windows.Forms;
using Camada_Negocio;
using System.Collections.Generic;

namespace Camada_Apresentacao
{
    public partial class frmCaixa : Form
    {
        public frmCaixa()
        {
            InitializeComponent();
            cbAdicionarAuto.Checked = Status.statusAddAutoProduto;
            //btnCancelar.Enabled = false;
        }

        Cs_Produto_Negocio produtoNegocio;
        Cs_Cliente_Negocio clienteNegocio =new Cs_Cliente_Negocio();
        Cs_Venda_Negocio vendaNegocio;
        bool clienteIdentificado = false;

        DataTable produto;
        DataRow LinhaProduto;

        double total = 0;
        double subTotal = 0;
        double totalDesconto = 0;
        double valorPago = 0;
        double troco = 0;

        private void frmCaixa_Load(object sender, EventArgs e)
        {
            txtCod_Barrras.Focus();
        }
        
        public void Adicionar()
        {
            try
            {
                bool estado = false;
                double desconto__ = 0;
                double preco__ = 0;
                float qtd__ = 0;

                if (!double.TryParse(txtPreco.Text, out preco__))
                    throw new Exception("Preço inválido");

                if (DGV_Caixa.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in DGV_Caixa.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == LinhaProduto["Código"].ToString() && row.Cells[1].Value.ToString() == txtDescricao.Text)
                        {
                            if (cbAdicionarAuto.Checked == true)
                            {
                                float novaQtd =  float.Parse(row.Cells[2].Value.ToString()) + 1;
                                if (float.Parse(txtStock.Text) >= novaQtd)
                                {
                                    row.Cells[2].Value = novaQtd;
                                    row.Cells[5].Value = (double.Parse(row.Cells[3].Value.ToString()) * novaQtd).ToString("N");

                                    if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                    {
                                        if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                            throw new Exception("Desconto inválido");
                                    }

                                    double descontoGrid = 0;
                                    if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                                        descontoGrid = double.Parse(row.Cells[4].Value.ToString());

                                    if ((descontoGrid + desconto__) < 0)
                                        throw new Exception("O valor do desconto não pode ser menor que Zero");

                                    row.Cells[4].Value = descontoGrid + desconto__;

                                    Remover_Produto();
                                    Calcular();
                                }
                                else
                                {
                                    MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }                           
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(txtQuantidade.Text.Trim()))
                                {
                                    float qtd_ = 0;
                                    if (float.TryParse(txtQuantidade.Text, out qtd_))
                                    {
                                        if (float.Parse(txtStock.Text) >= qtd_)
                                        {
                                            float novaQtd = float.Parse(row.Cells[2].Value.ToString()) + qtd_;
                                            row.Cells[2].Value = novaQtd;
                                            row.Cells[5].Value = (double.Parse(row.Cells[3].Value.ToString()) * novaQtd).ToString("N");

                                            if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                            {
                                                if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                                    throw new Exception("Desconto inválido");
                                            }

                                            double descontoGrid = 0;
                                            if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                                                descontoGrid = double.Parse(row.Cells[4].Value.ToString());
                                         
                                            if ((descontoGrid + desconto__) < 0)
                                                throw new Exception("O valor do desconto não pode ser menor que Zero");

                                            row.Cells[4].Value = descontoGrid + desconto__;

                                            Remover_Produto();
                                            Calcular();
                                        }
                                        else
                                        {
                                            MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            txtQuantidade.Focus();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("A quantidade é inválida", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtQuantidade.Focus();
                                    }
                                }
                            }
                            estado = true;
                        }
                    }
                    if (!estado && !string.IsNullOrEmpty(txtDescricao.Text))
                    {                      
                        if (cbAdicionarAuto.Checked == true)
                        {
                            if (float.Parse(txtStock.Text) >= 1)
                            {
                                qtd__ = 1;
                                if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                {
                                    if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                        throw new Exception("Desconto inválido");
                                }
                        
                                DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, qtd__.ToString("N"), txtPreco.Text, desconto__.ToString(), (preco__* qtd__).ToString("N"));

                                Remover_Produto();
                                Calcular();
                            }
                            else
                            {
                                MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(txtQuantidade.Text.Trim()))
                            {
                                if (float.TryParse(txtQuantidade.Text, out qtd__))
                                {
                                    if (float.Parse(txtStock.Text) >= qtd__)
                                    {
                                        if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                        {
                                            if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                                throw new Exception("Desconto inválido");
                                        }

                                        if (!float.TryParse(txtQuantidade.Text, out qtd__))
                                            throw new Exception("Quantidade inválida");

                                        DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, qtd__.ToString("N"), txtPreco.Text, desconto__.ToString(), (preco__ * qtd__).ToString("N"));

                                        Remover_Produto();
                                        Calcular();
                                    }
                                    else
                                    {
                                        MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtQuantidade.Focus();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("A quantidade é inválida", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtQuantidade.Focus();
                                }
                            }
                        }
                    }
                }else if (!string.IsNullOrEmpty(txtDescricao.Text.Trim()))
                {
                    if (cbAdicionarAuto.Checked == true)
                    {
                        if (float.Parse(txtStock.Text) >= 1)
                        {
                             if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                             {
                                 if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                     throw new Exception("Desconto inválido");
                             }
                            qtd__ = 1;
                            DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, qtd__.ToString("N"), txtPreco.Text, desconto__.ToString(), (preco__ * qtd__).ToString("N"));
                            Remover_Produto();
                            Calcular();
                        }
                        else
                        {
                            MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtQuantidade.Text.Trim()))
                        {
                            float qtd_ = 0;
                            if (float.TryParse(txtQuantidade.Text, out qtd_))
                            {
                                if (float.Parse(txtStock.Text) >= qtd_)
                                {
                                    if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                    {
                                        if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                            throw new Exception("Desconto inválido");
                                    }

                                    if (!float.TryParse(txtQuantidade.Text, out qtd__))
                                        throw new Exception("Quantidade inválida");

                                    DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, qtd__.ToString("N"), txtPreco.Text, desconto__.ToString(), (preco__ * qtd__).ToString("N"));

                                    Remover_Produto();
                                    Calcular();
                                }
                                else
                                {
                                    MessageBox.Show("A quantidade em estock é menor que a que desejas efectuar", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtQuantidade.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("A quantidade é inválida", "Atensão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtQuantidade.Focus();
                            }
                        }
                    }
                }
                Limpar();
                txtCod_Barrras.Focus();
                //btnCancelar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void Calcular()
        {
            try
            {
                subTotal = 0;
                totalDesconto = 0;

                if (DGV_Caixa.RowCount > 0)
                {
                    foreach (DataGridViewRow row in DGV_Caixa.Rows)
                    {
                        subTotal += double.Parse(row.Cells[5].Value.ToString());
                       
                        if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString().Trim()))
                            totalDesconto += double.Parse(row.Cells[4].Value.ToString());
                    }

                    total = subTotal - totalDesconto;
                    txtDescontoTotal.Text = totalDesconto.ToString("N");
                    txtTotal.Text = total.ToString("C");
                    txtSubTotal.Text = subTotal.ToString("C");

                    if (!string.IsNullOrEmpty(txtValorPago.Text.Trim()))
                    {
                        if (double.TryParse(txtValorPago.Text, out valorPago))
                        {
                            if (valorPago < total)
                            {
                                btnFinalizar.Enabled = false;
                                txtTroco.Text = string.Empty;
                            }
                            else
                            {
                                btnFinalizar.Enabled = true;
                                txtTroco.Text = troco.ToString("C");
                            }
                        }
                        else
                        {
                            throw new Exception("Valor pago inválido");
                        }
                    }
                }
                else
                {
                    total = subTotal - totalDesconto;
                    txtTotal.Text = total.ToString("C");
                    txtSubTotal.Text = subTotal.ToString("C");

                    troco = valorPago - total;
                    txtDescontoTotal.Text = totalDesconto.ToString("N");
                    txtTroco.Text = troco.ToString("C");

                    if (!string.IsNullOrEmpty(txtValorPago.Text.Trim()))
                    {
                        if (double.TryParse(txtValorPago.Text, out valorPago))
                        {
                            if (valorPago < total)
                            {
                                btnFinalizar.Enabled = false;
                                txtTroco.Text = string.Empty;
                            }
                            else
                            {
                                btnFinalizar.Enabled = true;
                                txtTroco.Text = troco.ToString("C");
                            }
                        }
                        else
                        {
                            throw new Exception("Valor pago inválido");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover_Produto()
        {
            if (DGV_Caixa.Rows.Count > 0)
            {
                for (int i = 0; i < DGV_Caixa.Rows.Count; i++)
                {
                    if (DGV_Caixa.Rows[i].Cells[0].Value.ToString() == LinhaProduto["Código"].ToString() && txtDescricao.Text == DGV_Caixa.Rows[i].Cells[1].Value.ToString())
                    {
                        float novaQtd = 0;

                        if (cbAdicionarAuto.Checked == true)
                            novaQtd = float.Parse(DGV_Caixa.Rows[i].Cells[2].Value.ToString()) + 1;
                        else
                            novaQtd = float.Parse(DGV_Caixa.Rows[i].Cells[2].Value.ToString()) + float.Parse(txtQuantidade.Text);

                        if (novaQtd <= 0)
                        {
                            DGV_Caixa.Rows.Remove(DGV_Caixa.Rows[i]);
                        }
                        else if (Convert.ToDouble(DGV_Caixa.Rows[i].Cells[2].Value.ToString()) > novaQtd)
                        {
                            DGV_Caixa.Rows[i].Cells[2].Value = novaQtd;
                            DGV_Caixa.Rows[i].Cells[5].Value = (double.Parse(DGV_Caixa.Rows[i].Cells[3].Value.ToString()) * novaQtd).ToString("N");
                        }
                    }
                }
                Calcular();
            }
        }

        void iniciarNovaVenda()
        {
             
        }

        void FinalizarVenda()
        {
            Limpar();
            iniciarNovaVenda();
        }

        void cancelarVenda()
        {

        }

        void Limpar()
        {
            txtCod_Barrras.Clear();
            txtDescricao.Clear();
            txtCategoria.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtUnidade.Clear();
            txtPreco.Clear();
            txtStock.Clear();
            txtQuantidade.Clear();
            txtDesconto_.Clear();
        }

        void LimparTudo()
        {
            DGV_Caixa.Rows.Clear();
            Limpar();
            txtSubTotal.Clear();
            txtTotal.Clear();
            txtValorPago.Clear();
            txtDescontoTotal.Clear();
            txtTroco.Clear();
            txtCliente.Text = "Consumidor Final";
            clienteNegocio = new Cs_Cliente_Negocio();
            total = 0;
            subTotal = 0;
            totalDesconto = 0;
            valorPago = 0;
            troco = 0;
            txtCod_Barrras.Focus();
        }

        private void txtCod_Barrras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                if (!string.IsNullOrEmpty(txtCod_Barrras.Text.Trim()) || !string.IsNullOrWhiteSpace(txtCod_Barrras.Text))
                {
                    produtoNegocio = new Cs_Produto_Negocio();
                    produto = produtoNegocio.CarregarPorCodigoDeBarras(txtCod_Barrras.Text);
                    if (produto.Rows.Count > 0)
                    {
                        LinhaProduto = produto.Rows[0];
                        txtDescricao.Text = LinhaProduto["Descrição"].ToString();
                        txtCategoria.Text = LinhaProduto["Categoria"].ToString();
                        txtMarca.Text = LinhaProduto["Marca"].ToString();
                        txtModelo.Text = LinhaProduto["Modelo"].ToString();
                        txtUnidade.Text = LinhaProduto["Unidade"].ToString();
                        txtStock.Text = LinhaProduto["Qtd"].ToString();
                        txtPreco.Text = LinhaProduto["Preço"].ToString();

                        if (cbAdicionarAuto.Checked == true)
                        {
                            Adicionar();
                        }
                        else
                        {
                            gbDadosAdicionar.Enabled = true;
                            txtQuantidade.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Digíte o código de barras","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                Adicionar();
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message,"Atenção",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float qtd_ = 0;
                if (!string.IsNullOrEmpty(txtQuantidade.Text.Trim()))
                {
                    if (float.TryParse(txtQuantidade.Text, out qtd_))
                    {
                        txtDesconto_.Focus();
                    }
                }
            }
        }

        private void txtDesconto__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float qtd_ = 0;
                if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                {
                    if (float.TryParse(txtDesconto_.Text, out qtd_))
                    {
                        btnAdicionarProduto.Focus();
                    }
                }
                else
                {
                    txtDesconto_.Text = "0";
                    btnAdicionarProduto.Focus();
                }
            }
        }

        private void btnAdicionarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Adicionar();
            }
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValorPago.Text.Trim()))
                {
                    if (double.TryParse(txtValorPago.Text, out valorPago))
                    {
                        troco = valorPago - total;

                        txtValorPago.Text = valorPago.ToString();

                        if (valorPago < total)
                        {
                            btnFinalizar.Enabled = false;
                            txtTroco.Text = string.Empty;
                        }
                        else
                        {
                            btnFinalizar.Enabled = true;
                            txtTroco.Text = troco.ToString("C");
                        }
                    }
                    else
                    {
                        throw new Exception("Valor pago inválido");
                    }
                }
                else
                {

                    valorPago = 0;
                    troco = valorPago;

                    txtTroco.Text = string.Empty;
                    txtValorPago.Text = string.Empty;
                    btnFinalizar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbAdicionarAuto_CheckedChanged(object sender, EventArgs e)
        {
            Status.statusAddAutoProduto = cbAdicionarAuto.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DGV_Caixa.RowCount > 0)
            {
                LimparTudo();
                //btnCancelar.Enabled = false;
            }
            else
            {
                if (MessageBox.Show("Tens certeza que desejas sair?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Close();
            }
        }
        public int a { get; set; }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                frmFinalizarVenda finalizarPagamento = new frmFinalizarVenda();
                uint idVenda = 0;
                finalizarPagamento.ShowDialog();

                if (finalizarPagamento.DialogResult == DialogResult.Yes)
                {
                    vendaNegocio = new Cs_Venda_Negocio();
                    vendaNegocio.IdVendedor = Status.id;
                    vendaNegocio.SubTotal = subTotal;
                    vendaNegocio.Total = total;
                    vendaNegocio.Desconto = totalDesconto;
                    vendaNegocio.ValorPago = valorPago;
                    vendaNegocio.Troco = troco;
                    vendaNegocio.IdFPagamento = short.Parse(finalizarPagamento.cboFormaPagamento.SelectedValue.ToString());
                    List<Cs_Itens_Venda_Negocio> itens = new List<Cs_Itens_Venda_Negocio>();
                    foreach (DataGridViewRow linha in DGV_Caixa.Rows)
                    {
                        Cs_Itens_Venda_Negocio item = new Cs_Itens_Venda_Negocio()
                        {
                            IdProduto = uint.Parse(linha.Cells[0].Value.ToString()),
                            Preco = double.Parse(linha.Cells[3].Value.ToString()),
                            Quantidade = float.Parse(linha.Cells[2].Value.ToString()),
                            Desconto = double.Parse(linha.Cells[4].Value.ToString() ?? "0")
                        };
                        itens.Add(item);
                    }

                    vendaNegocio.Produtos = itens;

                    if (!clienteIdentificado)
                    {
                        vendaNegocio.Cliente = new Cs_Cliente_Negocio()
                        {
                            Nome = txtCliente.Text,
                            Id_Tipo_Cliente = 1,
                            EnderecoCliente = new Cs_Endereco_Negocio(),
                            ContactoCliente = new Cs_Contacto_Negocio()
                        };

                        idVenda = uint.Parse(vendaNegocio.Cadastrar(false).ToString());
                        LimparTudo();
                    }
                    else
                    {
                        vendaNegocio.Cliente = clienteNegocio;
                        idVenda = uint.Parse(vendaNegocio.Cadastrar(true).ToString());
                        LimparTudo();
                    }

                    Cs_Venda_Negocio venda_Negocio = new Cs_Venda_Negocio();
                    DataTable tableVenda = new DataTable();
                    DataTable tableItens = new DataTable();
                    List<Itens> listItens = new List<Itens>();
                    tableVenda = venda_Negocio.ConsultarVenda(idVenda);
                    tableItens = venda_Negocio.ConsultarItens(idVenda);

                    DataRow dados_Venda = tableVenda.Rows[0];

                    foreach (DataRow row in tableItens.Rows)
                    {
                        float desconto = 0;
                        if (!string.IsNullOrEmpty(row["Desconto"].ToString()))
                            desconto = float.Parse(row["Desconto"].ToString());

                        listItens.Add(
                            new Itens()
                            {
                                IdProduto = uint.Parse(row["Codigo_Produto"].ToString()),
                                Produto = row["Produto"].ToString(),
                                Preco = float.Parse(row["Preco"].ToString()),
                                Qtd = float.Parse(row["Qtd"].ToString()),
                                Desconto = desconto,
                                Total = float.Parse(row["Total"].ToString())
                            });
                    }

                    Factura factura = new Factura(
                        new Sistema()
                        {
                            Titulo = "Tecno Excelencia",
                            Telefone = "925376413",
                            Endereco = "Zango 0 junto ao campo polivalente",
                            Nif = "363733737"
                        },
                        new Venda()
                        {
                            Codigo = idVenda,
                            Cliente = new Cliente()
                            {
                                Codigo = uint.Parse(dados_Venda["Codigo_Cliente"].ToString()),
                                Nome = dados_Venda["Cliente"].ToString(),
                                Nif_bi = dados_Venda["NIF_BI_Cliente"].ToString()
                            },
                            Vendedor = new Vendedor()
                            {
                                Codigo = uint.Parse(dados_Venda["Codigo_Vendedor"].ToString()),
                                Nome = dados_Venda["Vendedor"].ToString(),
                            },
                            Itens = listItens,
                            Total = float.Parse(dados_Venda["Total"].ToString()),
                            Desconto = float.Parse(dados_Venda["Desconto"].ToString()),
                            ValorPago = float.Parse(dados_Venda["Valor_Pago"].ToString()),
                            Troco = float.Parse(dados_Venda["Troco"].ToString()),
                            FormaPagemento = new FormaPagemento()
                            {
                                Codigo = uint.Parse(dados_Venda["Codigo_FPagamento"].ToString()),
                                Nome = dados_Venda["FPagamento"].ToString()
                            }
                        });

                    factura.Imprimir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIdentificarCliente_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.btnIdentificar.Visible= true;
            frmCliente.btnCadastrar.Visible = false;
            frmCliente.btnEliminar.Visible = false;
            frmCliente.btnAlterar.Visible = false;
            frmCliente.ShowDialog();
            if (frmCliente.DialogResult == DialogResult.Yes)
            {
                clienteNegocio = frmCliente.clienteNegocio;
                clienteIdentificado = true;
                txtCliente.Text = clienteNegocio.Nome;
            }

        }
    }
}
