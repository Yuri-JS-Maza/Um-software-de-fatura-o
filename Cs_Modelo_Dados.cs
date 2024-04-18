using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Modelo_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_modelo(nome_Modelo) Values(@nome)";
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
                cmd.CommandText = "UPDATE tbl_modelo SET nome_Modelo = @nome WHERE id_Modelo = @codigo";
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
                cmd.CommandText = "DELETE FROM tbl_modelo WHRE id_Modelo = @codigo";
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select *from tbl_modelo ORDER BY nome_Modelo", Conexao);
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
                //MySqlCommand cmd = new MySqlCommand("Select *from tbl_modelo WHERE nome_Modelo LIKE %@descicao% OR id_Modelo LIKE %@descricao%", Conexao);
                MySqlCommand cmd = new MySqlCommand("Select *from tbl_modelo", Conexao);
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
