using System;
using System.Data;
using System.Windows.Forms;
using Camada_Negocio;

namespace Camada_Apresentacao
{
    public partial class frmEntrada : Form
    {
        public frmEntrada()
        {
            InitializeComponent();
        }

        Cs_Produto_Negocio produtoNegocio;
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

                                    double desconto__ = 0;
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

                                            double desconto__ = 0;
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
                                double desconto__ = 0;
                                if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                {
                                    if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                        throw new Exception("Desconto inválido");
                                }
                                DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, 1, txtPreco.Text, desconto__.ToString(), txtPreco.Text);

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
                                        double desconto__ = 0;
                                        if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                        {
                                            if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                                throw new Exception("Desconto inválido");
                                        }

                                        DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, txtQuantidade.Text, txtPreco.Text, desconto__.ToString(), txtPreco.Text);
                                                                 
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
                             double desconto__ = 0;
                             if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                             {
                                 if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                     throw new Exception("Desconto inválido");
                             }

                            DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, 1, txtPreco.Text,desconto__, txtPreco.Text);
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
                                    double desconto__ = 0;
                                    if (!string.IsNullOrEmpty(txtDesconto_.Text.Trim()))
                                    {
                                        if (!double.TryParse(txtDesconto_.Text, out desconto__))
                                            throw new Exception("Desconto inválido");
                                    }

                                    DGV_Caixa.Rows.Add(LinhaProduto["Código"], txtDescricao.Text, txtQuantidade.Text, txtPreco.Text, desconto__.ToString(), txtPreco.Text);
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
                if (DGV_Caixa.RowCount > 0)
                {
                    foreach (DataGridViewRow row in DGV_Caixa.Rows)
                    {
                        subTotal += double.Parse(row.Cells[5].Value.ToString());
                        if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                            totalDesconto += double.Parse(row.Cells[4].Value.ToString());
                        else
                            totalDesconto += 0;

                    }
                    total = subTotal - totalDesconto;
                    txtDescontoTotal.Text = totalDesconto.ToString("N");
                    txtTotal.Text = total.ToString("C");
                    txtValorPago.Text = valorPago.ToString();
                    txtSubTotal.Text = subTotal.ToString("C");
                }
                else
                {
                    total = subTotal - totalDesconto;
                    txtTotal.Text = total.ToString("C");
                    txtSubTotal.Text = subTotal.ToString("C");

                    troco = valorPago - total;
                    txtDescontoTotal.Text = totalDesconto.ToString("N");
                    txtTroco.Text = troco.ToString("C");
                    txtValorPago.Text = valorPago.ToString();
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
            }
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
                        txtTroco.Text = troco.ToString("C");
                        txtValorPago.Text = valorPago.ToString();
                    }
                    else
                    {
                        throw new Exception("Valor pago inválido");
                    }
                }
                else
                {
                    valorPago = 0;
                    troco = valorPago - total;
                    txtTroco.Text = troco.ToString("C");
                    txtValorPago.Text = valorPago.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
