using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Dados
{
    public class Cs_Produto_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome,string descricao,string codigoDeBarras,double preco,float quantidade, float quantidadeMinima, DateTime validade, short idCategoria, short idMarca,short idModelo, short idUnidade)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_produto(nome, descricao, codigo_Barras, preco, quantidade, quantidadeMinima, validade, id_Categoria, id_Marca, id_Modelo, id_Unidade) VALUES (@nome, @descricao, @codigo_Barras, @preco, @quantidade, @quantidadeMinima, @validade, @id_Categoria, @id_Marca, @id_Modelo, @id_Unidade)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@codigo_Barras", codigoDeBarras);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@quantidadeMinima", quantidadeMinima);
                cmd.Parameters.AddWithValue("@validade", validade);
                cmd.Parameters.AddWithValue("@id_Categoria", (idCategoria == 0) ? null : idCategoria.ToString());
                cmd.Parameters.AddWithValue("@id_Marca", (idMarca == 0) ? null : idMarca.ToString());
                cmd.Parameters.AddWithValue("@id_Modelo", (idModelo == 0) ? null : idModelo.ToString());
                cmd.Parameters.AddWithValue("@id_Unidade", (idUnidade == 0) ? null : idUnidade.ToString());

                Conectar();

                retorno = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return retorno;
        }


        public object Alterar(uint idProduto,string nome, string descricao, string codigoDeBarras, double preco, float quantidade, float quantidadeMinima, DateTime validade, short idCategoria, short idMarca, short idModelo, short idUnidade)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "UPDATE tbl_produto SET nome=@nome,descricao=@descricao,codigo_Barras=@codigo_Barras,preco=@preco,quantidade=@quantidade,quantidadeMinima=@quantidadeMinima,validade=@validade,id_Categoria=@id_Categoria,id_Marca=@id_Marca,id_Modelo=@id_Modelo,id_Unidade=@id_Unidade WHERE id_Produto=@id_Produto";
                cmd.Parameters.AddWithValue("@id_Produto", idProduto);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@codigo_Barras", codigoDeBarras);
                cmd.Parameters.AddWithValue("@preco", preco);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.Parameters.AddWithValue("@quantidadeMinima", quantidadeMinima);
                cmd.Parameters.AddWithValue("@validade", validade);
                cmd.Parameters.AddWithValue("@id_Categoria", (idCategoria == 0) ? null : idCategoria.ToString());
                cmd.Parameters.AddWithValue("@id_Marca", (idMarca == 0) ? null : idMarca.ToString());
                cmd.Parameters.AddWithValue("@id_Modelo", (idModelo == 0) ? null : idModelo.ToString());
                cmd.Parameters.AddWithValue("@id_Unidade", (idUnidade == 0) ? null : idUnidade.ToString());

                Conectar();

                retorno = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return retorno;
        }

        public object Eliminar(uint idProduto)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "DELETE FROM tbl_produto WHERE id_Produto = @id_Produto";
                cmd.Parameters.AddWithValue("@id_Produto", idProduto);

                Conectar();

                retorno = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return retorno;
        }
        public DataTable CarregarTodos()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM vwproduto ORDER BY Nome", Conexao);
                Conectar();
                adapter.Fill(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return tabela;
        }

        public DataTable CarregarPorCodigoDeBarras(string codigoDeBarras)
        {
            DataTable tabela = new DataTable();
            try
            {
                cmd = new MySqlCommand("SELECT *FROM vwproduto p WHERE p.`Código de Barras` = @codigoDeBarras LIMIT 1", Conexao);
                cmd.Parameters.AddWithValue("@codigoDeBarras", codigoDeBarras);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                Conectar();
                adapter.Fill(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return tabela;
        }

        public DataTable CarregarPorCodigo(string codigo)
        {
            DataTable tabela = new DataTable();
            try
            {
                cmd = new MySqlCommand("SELECT *FROM vwproduto p WHERE p.`Código` = @codigo LIMIT 1", Conexao);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                Conectar();
                adapter.Fill(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return tabela;
        }

        public DataTable GetInventario()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT *FROM vwInventario", Conexao);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                Conectar();
                adapter.Fill(tabela);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return tabela;
        }
    }
}
