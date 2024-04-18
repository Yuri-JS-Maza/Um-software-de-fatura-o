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
    public class Cs_UsuarioGestorDados : Cs_Usuario_Dados
    {
        MySqlCommand cmd;

        public object Cadastrar(short idGestor, string usuario, string senha)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object row;
            try
            {
                object idUsuario = CadastrarUsuario(usuario, senha,ref cmd);
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO `tbl_usuario_gestor`(`id_Gestor`, `id_Usuario`) VALUES (@id_Gestor,@id_Usuario)";
                cmd.Parameters.AddWithValue("@id_Gestor", idGestor);
                cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);
                row=cmd.ExecuteNonQuery();

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
                row = AlterarUsuario(idUsuario,usuario, senha, ref cmd);                
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
                cmd.CommandText = "DELETE FROM `tbl_usuario_gestor` WHERE id_Usuario= @id_Usuario";
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `vwusuariogestor`", Conexao);
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

        public DataTable ListarGestores()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT g.id_Gestor AS 'Id',concat(g.nome,' ',g.sobrenome) as Nome FROM vwgestor g WHERE NOT EXISTS(SELECT *FROM tbl_usuario_gestor ug WHERE ug.id_Gestor=g.id_Gestor)", Conexao);
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

        public DataTable Logar(string usuario,string senha)
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `vwusuariogestor` WHERE `Usuário` = @usuario and Senha = MD5(@senha) LIMIT 1", Conexao);
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
