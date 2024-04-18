using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;
using System.Data;

namespace Camada_Negocio
{
    public class Cs_Produto_Negocio_Temp
    {
        uint id;
        uint idProduto;
        float quantidade;

        Cs_Produto_Dados_Temp produtoDados_Temp;

        public uint Id
        {
            get { return id; }
            set
            {
                if (uint.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código Inválido");
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

        public float Quantidade
        {
            get { return quantidade; }
            set
            {
                if (float.TryParse(value.ToString(), out quantidade))
                    quantidade = value;
                else
                    throw new Exception("Quantidade Inválida");
            }
        }
        
        public object Cadastrar()
        {
            try
            {
                produtoDados_Temp = new Cs_Produto_Dados_Temp();
                return produtoDados_Temp.Cadastrar(this.IdProduto, this.Quantidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object EliminarTodos()
        {
            try
            {
                produtoDados_Temp = new Cs_Produto_Dados_Temp();
                return produtoDados_Temp.EliminarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object CountProdutoTemp(uint idProduto)
        {
            try
            {
                produtoDados_Temp = new Cs_Produto_Dados_Temp();
                return produtoDados_Temp.CountProduto_Temp(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
