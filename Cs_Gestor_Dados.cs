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
    public class Cs_Gestor_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(string nome, string sobrenome,char genero,string bi,DateTime nascimento,DateTime datAdmissao,string numCredencial,bool status,string provincia,string municipio, string bairro, string rua, string casa,string telefone,string email)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object retorno = null;

            try
            {
                cmd.CommandText = "INSERT INTO tbl_endereco(provincia,municipio,bairro,rua,casa) VALUES (@provincia,@municipio,@bairro,@rua,@casa)";
                cmd.Parameters.AddWithValue("@provincia", provincia);
                cmd.Parameters.AddWithValue("@municipio", municipio);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@rua", rua);
                cmd.Parameters.AddWithValue("@casa", casa);
                cmd.ExecuteNonQuery();
                object idEndereco = cmd.LastInsertedId;

                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO tbl_contacto(telefone, email) VALUES (@telefone, @email)";
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                object idContacto = cmd.LastInsertedId;                 

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO `tbl_pessoa`(nome, sobrenome, genero, bi, data_nascimento, id_Contacto, id_Endereco) VALUES (@nome, @sobrenome, @genero, @bi, @data_nascimento, @id_Contacto, @id_Endereco)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@bi", bi);
                cmd.Parameters.AddWithValue("@data_nascimento", nascimento);
                cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                cmd.ExecuteNonQuery();
                object idPessoa = cmd.LastInsertedId;

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO `tbl_gestor`(id_Pessoa, dataAdmissao, num_Credencial, status) VALUES (@id_Pessoa, @dataAdmissao, @num_Credencial, @status)";
                cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
                cmd.Parameters.AddWithValue("@dataAdmissao", datAdmissao);
                cmd.Parameters.AddWithValue("@num_Credencial", numCredencial);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                object idVendedor = cmd.LastInsertedId;
                retorno = idVendedor;

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

        public object Alterar(uint idPessoa,string nome, string sobrenome, char genero, string bi, DateTime nascimento,short id_Gestor, DateTime datAdmissao, string numCredencial, bool status, uint idEndereco,string provincia, string municipio, string bairro, string rua, string casa,uint idContacto, string telefone, string email)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object retorno = null;

            try
            {
                cmd.CommandText = "UPDATE tbl_endereco SET provincia= @provincia,`municipio`= @municipio,`bairro`= @bairro,`rua`= @rua,`casa`= @casa WHERE `id_Endereco`= @id_Endereco";
                cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                cmd.Parameters.AddWithValue("@provincia", provincia);
                cmd.Parameters.AddWithValue("@municipio", municipio);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@rua", rua);
                cmd.Parameters.AddWithValue("@casa", casa);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE `tbl_contacto` SET `telefone`= @telefone,`email`= @email WHERE id_Contacto=@id_Contacto";
                cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE `tbl_pessoa` SET `nome`= @nome,`sobrenome`= @sobrenome,`genero`= @genero,`bi`= @bi,`data_nascimento`= @data_nascimento,`id_Contacto`= @id_Contacto,`id_Endereco`= @id_Endereco WHERE  `id_Pessoa`= @id_Pessoa";
                cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@bi", bi);
                cmd.Parameters.AddWithValue("@data_nascimento", nascimento);
                cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE `tbl_gestor` SET `id_Pessoa`= @id_Pessoa,`dataAdmissao`= @dataAdmissao,`num_Credencial`= @num_Credencial,`status`= @status WHERE `id_Gestor`= @id_Gestor";
                cmd.Parameters.AddWithValue("@id_Gestor", id_Gestor);
                cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
                cmd.Parameters.AddWithValue("@dataAdmissao", datAdmissao);
                cmd.Parameters.AddWithValue("@num_Credencial", numCredencial);
                cmd.Parameters.AddWithValue("@status", status);
                retorno= cmd.ExecuteNonQuery();

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

        public object Eliminar(uint idPessoa,uint idEndereco,uint idContacto)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;
            object retorno = null;

            try
            {
                cmd.CommandText = "DELETE FROM tbl_endereco WHERE id_Endereco= @id_Endereco";
                cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM tbl_contacto WHERE @id_Contacto";
                cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM tbl_pessoa WHERE id_Pessoa= @id_Pessoa";
                cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM vwgestor", Conexao);
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
