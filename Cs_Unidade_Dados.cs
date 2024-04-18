using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Unidade_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_unidade(nome_Unidade) Values(@nome)";
                cmd.Parameters.AddWithValue("@nome", nome);

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


        public object Alterar(short codigo, string nome)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "UPDATE tbl_unidade SET nome_Unidade = @nome WHERE id_Unidade = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nome", nome);

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

        public object Eliminar(short codigo)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "DELETE FROM tbl_unidade WHRE id_Unidade = @codigo";
                cmd.Parameters.AddWithValue("@codigo", codigo);

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
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select *from tbl_unidade ORDER BY nome_Unidade", Conexao);
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
        public DataTable Carregar(string descricao)
        {
            DataTable tabela = new DataTable();
            try
            {
                //MySqlCommand cmd = new MySqlCommand("Select *from tbl_unidade WHERE nome_Unidade LIKE %@descicao% OR id_Unidade LIKE %@descricao%", Conexao);
                MySqlCommand cmd = new MySqlCommand("Select *from tbl_unidade", Conexao);
                cmd.Parameters.AddWithValue("@descicao", descricao);
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
