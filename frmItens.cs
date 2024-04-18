using Camada_Apresentacao.UserControls;
using Camada_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camada_Apresentacao
{
    public partial class frmItens : Form
    {
        public uint Id { get; set; }
        public bool Status { get; set; }

        public frmItens()
        {
            InitializeComponent();
        }

        public frmItens(uint id,bool status)
        {
            InitializeComponent();
            Id = id;
            Status = status;
        }

        async Task<DataTable> GetItensVenda(uint id)
        {
            picItens.Visible = true;
            return await Task.Factory.StartNew(() =>
            {
                DataTable dt = new DataTable();
                Cs_Venda_Negocio venda_Negocio = new Cs_Venda_Negocio();
                dt = venda_Negocio.ConsultarItens(id);
                picItens.Invoke((MethodInvoker)(() => picItens.Visible = false));
                return dt;
            });
        }

        private async void frmItens_Load(object sender, EventArgs e)
        {
            dgvItens.DataSource = await GetItensVenda(Id);
            
            if (dgvItens.RowCount <= 0)
                btnImprimir.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvItens.RowCount > 0)
            {
                Cs_Venda_Negocio venda_Negocio = new Cs_Venda_Negocio();
                DataTable tableVenda = new DataTable();
                DataTable tableItens = new DataTable();
                List<Itens> listItens = new List<Itens>();
                tableVenda = venda_Negocio.ConsultarVenda(Id);
                tableItens = venda_Negocio.ConsultarItens(Id);

                DataRow dataRow = tableVenda.Rows[0];

                foreach (DataRow row in tableItens.Rows)
                {
                    float desconto = 0;
                    if (!string.IsNullOrEmpty(row["Desconto"].ToString()))
                        desconto = float.Parse(row["Desconto"].ToString());

                    listItens.Add(
                        new Itens() { 
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
                        Codigo = Id,
                        Cliente = new Cliente()
                        {
                            Codigo = uint.Parse(dataRow["Codigo_Cliente"].ToString()),
                            Nome = dataRow["Cliente"].ToString(),
                            Nif_bi = dataRow["NIF_BI_Cliente"].ToString()
                        },
                        Vendedor = new Vendedor()
                        {
                            Codigo = uint.Parse(dataRow["Codigo_Vendedor"].ToString()),
                            Nome = dataRow["Vendedor"].ToString(),
                        },
                        Itens = listItens,
                        Total = float.Parse(dataRow["Total"].ToString()),
                        Desconto = float.Parse(dataRow["Desconto"].ToString()),
                        ValorPago = float.Parse(dataRow["Valor_Pago"].ToString()),
                        Troco = float.Parse(dataRow["Troco"].ToString()),
                        FormaPagemento = new FormaPagemento()
                        {
                            Codigo = uint.Parse(dataRow["Codigo_FPagamento"].ToString()),
                            Nome = dataRow["FPagamento"].ToString()
                        }
                    });

                factura.Imprimir();
            }
        }
    }
}
