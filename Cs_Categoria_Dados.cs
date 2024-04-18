using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Camada_Dados;

namespace Camada_Dados
{
    public class Cs_Categoria_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_categoria(nome_Categoria) Values(@nome)";
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
                cmd.CommandText = "UPDATE tbl_categoria SET nome_Categoria = @nome WHERE id_Categoria = @codigo";
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
                cmd.CommandText = "DELETE FROM tbl_categoria WHRE id_Categoria = @codigo";
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select *from tbl_categoria ORDER BY nome_Categoria", Conexao);
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
                //MySqlCommand cmd = new MySqlCommand("Select *from tbl_categoria WHERE nome_Categoria LIKE %@descicao% OR id_Categoria LIKE %@descricao%", Conexao);
                MySqlCommand cmd = new MySqlCommand("Select *from tbl_categoria", Conexao);
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
