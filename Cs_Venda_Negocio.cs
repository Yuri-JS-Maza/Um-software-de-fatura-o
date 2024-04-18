using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Venda_Negocio
    {
        uint idVenda;
        short idVendedor;
        double subTotal;
        double total;
        double desconto;
        double valorPago;
        double troco;
        short idFPagamento;
        public Cs_Cliente_Negocio Cliente { get; set; }
        public List<Cs_Itens_Venda_Negocio> Produtos { get; set; }

        Cs_Venda_Dados Venda_Dados;

        public uint IdVenda
        {
            get { return idVenda; }
            set
            {
                if (uint.TryParse(value.ToString(), out idVenda))
                    idVenda = value;
                else
                    throw new Exception("Código da Venda Inválido");
            }
        }

        public short IdVendedor
        {
            get { return idVendedor; }

            set
            {
                if (!short.TryParse(value.ToString(), out idVendedor))
                    throw new Exception("Código do Vendedor inválido");
                else
                    idVendedor = value;
            }
        }
        
        public double Total
        {
            get { return total; }
            set
            {
                if (double.TryParse(value.ToString(), out total))
                    total = value;
                else
                    throw new Exception("Valor Total Inválido");
            }
        }

        public double SubTotal
        {
            get { return subTotal; }
            set
            {
                if (double.TryParse(value.ToString(), out subTotal))
                    subTotal = value;
                else
                    throw new Exception("Subtotal Inválido");
            }
        }

        public double ValorPago
        {
            get { return valorPago; }
            set
            {
                if (double.TryParse(value.ToString(), out valorPago))
                    valorPago = value;
                else
                    throw new Exception("Valor Pago Inválido");
            }
        }

        public double Desconto
        {
            get { return desconto; }
            set
            {
                if (double.TryParse(value.ToString(), out desconto))
                    desconto = value;
                else
                    throw new Exception("Valor do Desconto Inválido");
            }
        }

        public double Troco
        {
            get { return troco; }
            set
            {
                if (double.TryParse(value.ToString(), out troco))
                    troco = value;
                else
                    throw new Exception("Preço Inválido");
            }
        }

        public short IdFPagamento
        {
            get { return idFPagamento; }

            set
            {
                if (!short.TryParse(value.ToString(), out idFPagamento))
                    throw new Exception("Código da Forma de Pagamento inválido");
                else
                    idFPagamento = value;
            }
        }

        //True-Completo
        //False-Abstrato
        public object Cadastrar(bool tipoDeCadastro)
        {
            try
            {
                Venda_Dados = new Cs_Venda_Dados();

                List<object[]> ItensProduto = new List<object[]>();
                foreach (Cs_Itens_Venda_Negocio itensVenda in Produtos)
                {
                    object[] item = new object[4];
                    item[0] = itensVenda.IdProduto;
                    item[1] = itensVenda.Preco;
                    item[2] = itensVenda.Quantidade;
                    item[3] = itensVenda.Desconto;
                    ItensProduto.Add(item);
                }

                if (tipoDeCadastro)
                    return Venda_Dados.Cadastrar(IdVendedor, Total, Desconto, ValorPago, Troco, IdFPagamento, Cliente.Nome, Cliente.Nif_Bi, Cliente.Id_Tipo_Cliente, Cliente.EnderecoCliente.Provincia, Cliente.EnderecoCliente.Municipio, Cliente.EnderecoCliente.Bairro, Cliente.EnderecoCliente.Rua, Cliente.EnderecoCliente.Casa, Cliente.ContactoCliente.Telefone, Cliente.ContactoCliente.Email, ItensProduto);
                else
                    return Venda_Dados.Cadastrar(IdVendedor, Total, Desconto, ValorPago, Troco, IdFPagamento, Cliente.Nome, Cliente.Id_Tipo_Cliente, ItensProduto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable CarregarDados()
        {
            DataTable tabela = new DataTable();
            try
            {
                Venda_Dados = new Cs_Venda_Dados();
                tabela = Venda_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        public DataTable ConsultarVenda(uint codigoVenda)
        {
            DataTable tabela = new DataTable();
            try
            {
                Venda_Dados = new Cs_Venda_Dados();
                tabela = Venda_Dados.ConsultarVenda(codigoVenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        public DataTable ConsultarItens(uint codigoVenda)
        {
            DataTable tabela = new DataTable();
            try
            {
                Venda_Dados = new Cs_Venda_Dados();
                tabela = Venda_Dados.ConsultarItens(codigoVenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
    }
}
