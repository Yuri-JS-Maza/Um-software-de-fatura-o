using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace Camada_Apresentacao
{
    public class Cliente
    {
        public uint Codigo { get; set; }
        public string Nome { get; set; }
        public string Nif_bi { get; set; }

        public Cliente() { }
        public Cliente(uint codigo, string nome, string nif_bi)
        {
            Codigo = codigo;
            Nome = nome;
            Nif_bi = nif_bi;
        }
    }

    public class Vendedor
    {
        public uint Codigo { get; set; }
        public string Nome { get; set; }

        public Vendedor() { }
        public Vendedor(uint codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
    }

    public class FormaPagemento
    {
        public uint Codigo { get; set; }
        public string Nome { get; set; }

        public FormaPagemento() { }
        public FormaPagemento(uint codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
    }

    public class Sistema
    {
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Titulo { get; set; }
        public string Nif { get; set; }
        public Sistema() { }

        public Sistema(string endereco, string telefone, string titulo,string nif)
        {
            Endereco = endereco;
            Telefone = telefone;
            Nif = nif;
        }
    }

    public class Itens
    {
        public uint IdProduto { get; set; }
        public string Produto { get; set; }
        public float Preco { get; set; }
        public float Qtd { get; set; }
        public float Desconto { get; set; }
        public float Total { get; set; }

        public Itens() { }
        public Itens(uint idProduto, string produto, float preco, float qtd, float desconto, float total)
        {
            IdProduto = idProduto;
            Produto = produto;
            Preco = preco;
            Qtd = qtd;
            Desconto = desconto;
            Total = total;
        }
    }

    public class Venda
    {
        public uint Codigo { get; set; }
        public Vendedor Vendedor { get; set; }
        public Cliente Cliente { get; set; }
        public FormaPagemento FormaPagemento { get; set; }
        public List<Itens> Itens { get; set; } = new List<Itens>();
        public float Total { get; set; }
        public float Desconto { get; set; }
        public float ValorPago { get; set; }
        public float Troco { get; set; }

        public Venda() { }
        public Venda(uint codigo, Vendedor vendedor, Cliente cliente, FormaPagemento formaPagemento, List<Itens> itens, float total, float desconto, float valorPago, float troco)
        {
            Codigo = codigo;
            Vendedor = vendedor;
            Cliente = cliente;
            FormaPagemento = formaPagemento;
            Itens = itens;
            Total = total;
            Desconto = desconto;
            ValorPago = valorPago;
            Troco = troco;
        }
    }

    public class Factura
    {
        Sistema Sistema { get; set; } = new Sistema();
        Venda Venda { get; set; } = new Venda();

        public Factura(Sistema sistema, Venda venda)
        {
            Sistema = sistema;
            Venda = venda;
        }

        public void PrintPageFicha(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Font TituloTopo = new Font("Consolas", 13f, FontStyle.Bold);
                Font titleFont = new Font("Consolas", 9f, FontStyle.Bold);
                Font selo = new Font("Consolas", 8f, FontStyle.Regular);
                Font pdvFont = new Font("Consolas", 9f, FontStyle.Regular);
                Font obsFont = new Font("Consolas", 8f, FontStyle.Bold);

                SizeF size = new SizeF();
                float currentUsedHeight = 10f;
                
                ev.Graphics.DrawString(Sistema.Titulo, TituloTopo, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Sistema.Titulo, TituloTopo);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Local:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Local:", titleFont);

                ev.Graphics.DrawString(Sistema.Endereco, pdvFont, Brushes.Black, 50, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Sistema.Endereco, pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Tel:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Tel:", titleFont);

                ev.Graphics.DrawString(Sistema.Telefone, pdvFont, Brushes.Black, 40, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Sistema.Telefone, pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Contribuente:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Contribuente:", titleFont);

                ev.Graphics.DrawString(Sistema.Nif, pdvFont, Brushes.Black, 100, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Sistema.Nif, pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Venda nº:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Venda nº:", titleFont);

                ev.Graphics.DrawString(Venda.Codigo.ToString().PadLeft(5,'0'), pdvFont, Brushes.Black, 70, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Codigo.ToString(), pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Cliente:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Cliente:", titleFont);

                ev.Graphics.DrawString(Venda.Cliente.Nome, pdvFont, Brushes.Black, 70, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Cliente.Nome, pdvFont);

                if (Venda.Cliente.Nome == "")
                    currentUsedHeight += size.Height + 20;
                else
                    currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Data-Hora:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Data-Hora:", titleFont);

                ev.Graphics.DrawString(DateTime.Now.ToString(), pdvFont, Brushes.Black, 100, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(DateTime.Now.ToString(), pdvFont);
                currentUsedHeight += size.Height + 7;

                ev.Graphics.DrawString("Qtd.", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Quant", titleFont);

                ev.Graphics.DrawString("P Unit.%Desc", titleFont, Brushes.Black, 70, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("P Unit.%Desc", titleFont);

                ev.Graphics.DrawString("Valor", titleFont, Brushes.Black, 210, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Valor", titleFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("=======================================", pdvFont, Brushes.Black, 2, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("=======================================", pdvFont);
                currentUsedHeight += size.Height;

                foreach (Itens produto in Venda.Itens)
                {
                    ev.Graphics.DrawString(produto.Qtd.ToString("N"), pdvFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString(produto.Qtd.ToString("N"), pdvFont);

                    ev.Graphics.DrawString(produto.Preco.ToString("N"), pdvFont, Brushes.Black, 65, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString(produto.Preco.ToString("N"), pdvFont);

                    ev.Graphics.DrawString(produto.Total.ToString("N"), pdvFont, Brushes.Black, 190, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString(produto.Total.ToString("N"), pdvFont);
                    currentUsedHeight += size.Height - 3;

                    ev.Graphics.DrawString(produto.Produto, pdvFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                    size = ev.Graphics.MeasureString(produto.Produto, pdvFont);
                    currentUsedHeight += size.Height + 7;
                }

                ev.Graphics.DrawString("=======================================", pdvFont, Brushes.Black, 2, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("=======================================", pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Total Geral: ", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Total Geral: ", titleFont);

                ev.Graphics.DrawString(Venda.Total.ToString("N"), pdvFont, Brushes.Black, 190, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Total.ToString("N"), pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Entrega:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Entrega:", titleFont);

                ev.Graphics.DrawString(Venda.ValorPago.ToString("N"), pdvFont, Brushes.Black, 190, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.ValorPago.ToString("N"), pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Desconto:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Desconto:", titleFont);

                ev.Graphics.DrawString(Venda.Desconto.ToString("N"), pdvFont, Brushes.Black, 190, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Desconto.ToString("N"), pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Troco:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Troco:", titleFont);

                ev.Graphics.DrawString(Venda.Troco.ToString("N"), pdvFont, Brushes.Black, 190, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Troco.ToString("N"), pdvFont);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("F.Pagamento:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("F.Pagamento:", titleFont);

                ev.Graphics.DrawString(Venda.FormaPagemento.Nome.ToString(), pdvFont, Brushes.Black, 100, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.FormaPagemento.Nome.ToString(), pdvFont);
                currentUsedHeight += size.Height + 5;

                ev.Graphics.DrawString("-----------------------------------------", selo, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("-----------------------------------------", selo);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("| SELO PAGO POR GUIA- DECRETO Nº 18/92 |\n| D.R.I-Serie Nr.19/92 DE 15 MAIO 1992 |", selo, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("| SELO PAGO POR GUIA- DECRETO Nº 18/92 |\n| D.R.I-Serie Nr.19/92 DE 15 MAIO 1992 |", selo);
                currentUsedHeight += size.Height;
                ev.Graphics.DrawString("-----------------------------------------", selo, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("-----------------------------------------", selo);
                currentUsedHeight += size.Height;

                ev.Graphics.DrawString("Operador:", titleFont, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("Operador:", titleFont);
                ev.Graphics.DrawString(Venda.Vendedor.Nome.ToString(), pdvFont, Brushes.Black, 75, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString(Venda.Vendedor.Nome.ToString(), pdvFont);
                currentUsedHeight += size.Height + 10;
                ev.Graphics.DrawString("-----------------------------------------", selo, Brushes.Black, 5, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("-----------------------------------------", selo);

                currentUsedHeight += size.Height + 10;
                ev.Graphics.DrawString("OBRIGADO VOLTE SEMPRE...", obsFont, Brushes.Black, 55, currentUsedHeight, new StringFormat());
                size = ev.Graphics.MeasureString("OBRIGADO VOLTE SEMPRE...", obsFont);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Imprimir()
        {
            PrintDocument printDoc = new PrintDocument();
            try
            {
                //printDoc.PrinterSettings.PrinterName = "Kimuanga";
                printDoc.DocumentName = "Factura - "+ Venda.Codigo +"-"+ Venda.Cliente.Nome + DateTime.Now.ToString();

                if (!printDoc.PrinterSettings.IsValid) 
                   throw new Exception("Não foi possível localizar a impressora");
                
              
                printDoc.PrintPage += new PrintPageEventHandler(PrintPageFicha);
                printDoc.Print();
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
