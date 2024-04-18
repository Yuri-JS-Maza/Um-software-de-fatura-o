using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Itens_Venda_Negocio
    {
        uint idVenda;
        uint idProduto;
        double preco;
        float quantidade;
        double desconto;
        
        public uint IdVenda
        {
            get { return idVenda; }
            set
            {
                if (uint.TryParse(value.ToString(), out idVenda))
                    idVenda = value;
                else
                    throw new Exception("Código do Produto Inválido");
            }
        }

        public uint IdProduto
        {
            get { return idProduto; }
            set
            {
                if (uint.TryParse(value.ToString(), out idProduto))
                    idProduto = value;
                else
                    throw new Exception("Código do Produto Inválido");
            }
        }

        public double Preco
        {
            get { return preco; }
            set
            {
                if (double.TryParse(value.ToString(), out preco))
                    preco = value;
                else
                    throw new Exception("Preço Inválido");
            }
        }

        public float Quantidade
        {
            get { return quantidade; }
            set
            {
                if (float.TryParse(value.ToString(), out quantidade))
                    quantidade = value;
                else
                    throw new Exception("Quantidade Inválido");
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
                    throw new Exception("Desconto Inválido");
            }
        }
    }
}
