using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Forma_Pagamento_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_forma_pagamento(nome_Forma_Pagamento) Values(@nome)";
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
                cmd.CommandText = "UPDATE tbl_forma_pagamento SET nome_Forma_Pagamento = @nome WHERE id_Forma_Pagamento = @codigo";
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
                cmd.CommandText = "DELETE FROM tbl_forma_pagamento WHRE id_Forma_Pagamento = @codigo";
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select *from tbl_forma_pagamento ORDER BY nome_Forma_Pagamento", Conexao);
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
                //MySqlCommand cmd = new MySqlCommand("Select *from tbl_forma_pagamento WHERE nome_Forma_Pagamento LIKE %@descicao% OR id_Forma_Pagamento LIKE %@descricao%", Conexao);
                MySqlCommand cmd = new MySqlCommand("Select *from tbl_forma_pagamento", Conexao);
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
