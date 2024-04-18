using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;
using System.Data;

namespace Camada_Negocio
{
    public class Cs_Produto_Negocio
    {
        uint id;
        string nome;
        string descricao;
        string codigoDeBarras;
        double preco;
        float quantidade;
        float quantidadeMinima;
        DateTime validade;
        short idCategoria;
        short idUnidade;
        short idModelo;
        short idMarca;

        Cs_Produto_Dados produtoDados;
        public uint Id
        {
            get { return id; }
            set
            {
                if (uint.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código do Produto Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da Produto Inválido");
                else
                    nome = value;
            }
        }
        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Descrição do Produto Inválido");
                else
                    descricao = value;
            }
        }

        public string CodigoDeBarras
        {
            get { return codigoDeBarras; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Código de Barras do Produto Inválido");
                else
                    codigoDeBarras = value;
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
                    throw new Exception("Quantidade Inválida");
            }
        }

        public float QuantidadeMinima
        {
            get { return quantidadeMinima; }
            set
            {
                if (float.TryParse(value.ToString(), out quantidadeMinima))
                    quantidadeMinima = value;
                else
                    throw new Exception("Quantidade Mínima Inválido");
            }
        }

        public DateTime Validade
        {
            get { return validade; }
            set
            {
                if (DateTime.TryParse(value.ToString(), out validade))
                    validade = value;
                else
                    throw new Exception("Data de validade Inválida");
            }
        }

        public short IdCategoria
        {
            get { return idCategoria; }
            set
            {
                if (short.TryParse(value.ToString(), out idCategoria))
                    idCategoria = value;
                else
                    throw new Exception("Código da Categoria Inválido");
            }
        }

        public short IdUnidade
        {
            get { return idUnidade; }
            set
            {
                if (short.TryParse(value.ToString(), out idUnidade))
                    idUnidade = value;
                else
                    throw new Exception("Código da Unidade Inválido");
            }
        }

        public short IdModelo
        {
            get { return idModelo; }
            set
            {
                if (short.TryParse(value.ToString(), out idModelo))
                    idModelo = value;
                else
                    throw new Exception("Código do Modelo Inválido");
            }
        }

        public short IdMarca
        {
            get { return idMarca; }
            set
            {
                if (short.TryParse(value.ToString(), out idMarca))
                    idMarca = value;
                else
                    throw new Exception("Código da Marca Inválido");
            }
        }



        public object Cadastrar()
        {
            try
            {
                produtoDados = new Cs_Produto_Dados();
                return produtoDados.Cadastrar(this.Nome, this.Descricao, this.CodigoDeBarras, this.Preco, this.Quantidade, this.QuantidadeMinima, this.Validade, IdCategoria, IdMarca, IdModelo, IdUnidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object Alterar()
        {
            try
            {
                produtoDados = new Cs_Produto_Dados();
                return produtoDados.Alterar(this.Id,this.Nome, this.Descricao, this.CodigoDeBarras, this.Preco, this.Quantidade, this.QuantidadeMinima, this.Validade, IdCategoria, IdMarca, IdModelo, IdUnidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object Eliminar()
        {
            try
            {
                produtoDados = new Cs_Produto_Dados();
                return produtoDados.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetProdutoAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                produtoDados = new Cs_Produto_Dados();

                tabela = produtoDados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        public DataTable CarregarPorCodigoDeBarras(string codigoDeBarras)
        {
            DataTable tabela = new DataTable();
            try
            {
                produtoDados = new Cs_Produto_Dados();

                tabela = produtoDados.CarregarPorCodigoDeBarras(codigoDeBarras);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        public DataTable CarregarPorCodigo(string codigo)
        {
            DataTable tabela = new DataTable();
            try
            {
                produtoDados = new Cs_Produto_Dados();

                tabela = produtoDados.CarregarPorCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
        public DataTable GetInventario()
        {
            DataTable tabela = new DataTable();
            try
            {
                produtoDados = new Cs_Produto_Dados();

                tabela = produtoDados.GetInventario();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
    }
}
