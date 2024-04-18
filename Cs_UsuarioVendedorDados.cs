using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_UsuarioVendedorDados : Cs_Usuario_Dados
    {
        MySqlCommand cmd;

        public object Cadastrar(short id_Vendedor, string usuario, string senha)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object row;
            try
            {
                object idUsuario = CadastrarUsuario(usuario, senha, ref cmd);
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO `tbl_usuario_vendedor`(`id_Vendedor`, `id_Usuario`) VALUES (@id_Vendedor,@id_Usuario)";
                cmd.Parameters.AddWithValue("@id_Vendedor", id_Vendedor);
                cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);
                row = cmd.ExecuteNonQuery();

                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return row;
        }
        public object Alterar(short idUsuario, string usuario, string senha)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object row;
            try
            {
                row = AlterarUsuario(idUsuario, usuario, senha, ref cmd);
                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
            return row;
        }

        public object Eliminar(short idUsuario)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object retorno = null;

            try
            {
                EliminarUsuario(idUsuario, ref cmd);
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM `tbl_usuario_vendedor` WHERE id_Usuario= @id_Usuario";
                cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);
                cmd.ExecuteNonQuery();

                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `vwusuariovendedor`", Conexao);
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

        public DataTable ListarVendedores()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT v.id_Vendedor AS 'Id',concat(v.nome,v.sobrenome) AS 'Nome' FROM vwvendedor v WHERE NOT EXISTS(SELECT *FROM tbl_usuario_vendedor uv WHERE uv.id_Vendedor= v.id_Vendedor)", Conexao);
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

        public DataTable Logar(string usuario, string senha)
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `vwusuariovendedor` WHERE `Usuário` = @usuario and Senha = MD5(@senha) LIMIT 1", Conexao);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
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
