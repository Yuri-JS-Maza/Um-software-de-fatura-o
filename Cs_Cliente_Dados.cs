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
    public class Cs_Cliente_Dados : Cs_Conexao
    {
        public object Cadastrar(string nomeCliente, string nif_bi, short id_tipo_Cliente, string provincia, string municipio, string bairro, string rua, string casa, string telefone, string email)
        {
            object idCliente_ = VerificarExistencia(nif_bi);
            if (idCliente_.ToString() == "0")
            {
                Conectar();
                MySqlTransaction transacao = Conexao.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Transaction = transacao;
                try
                {
                    cmd.CommandText = "INSERT INTO tbl_endereco(provincia,municipio,bairro,rua,casa) VALUES (@provincia,@municipio,@bairro,@rua,@casa)";
                    cmd.Connection = transacao.Connection;
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
                    cmd.CommandText = "INSERT INTO `tbl_cliente`(nome, nif_bi, id_Contacto, id_Endereco, id_Tipo_Cliente) VALUES (@nome, @nif_bi, @id_Contacto, @id_Endereco, @id_Tipo_Cliente)";
                    cmd.Parameters.AddWithValue("@nome", nomeCliente);
                    cmd.Parameters.AddWithValue("@nif_bi", nif_bi);
                    cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                    cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                    cmd.Parameters.AddWithValue("@id_Tipo_Cliente", (id_tipo_Cliente == 0) ? null : id_tipo_Cliente.ToString());

                    cmd.ExecuteNonQuery();

                    transacao.Commit();
                    return cmd.LastInsertedId;
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
            }
            else
            {
                return idCliente_;
            }
        }

        public object Cadastrar(string nomeCliente, string nif_bi, short id_tipo_Cliente, string provincia, string municipio, string bairro, string rua, string casa, string telefone, string email, ref MySqlCommand cmd)
        {
            object idCliente_ = VerificarExistencia(nif_bi);
            if (idCliente_.ToString() == "0")
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
                cmd.CommandText = "INSERT INTO `tbl_cliente`(nome, nif_bi, id_Contacto, id_Endereco, id_Tipo_Cliente) VALUES (@nome, @nif_bi, @id_Contacto, @id_Endereco, @id_Tipo_Cliente)";
                cmd.Parameters.AddWithValue("@nome", nomeCliente);
                cmd.Parameters.AddWithValue("@nif_bi", nif_bi);
                cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
                cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
                cmd.Parameters.AddWithValue("@id_Tipo_Cliente", (id_tipo_Cliente == 0) ? null : id_tipo_Cliente.ToString());

                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            else
            {
                return idCliente_;
            }
        }

        public object Cadastrar(string nomeCliente, short id_tipo_Cliente, ref MySqlCommand cmd)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd.Transaction = transacao;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO `tbl_cliente`(nome, nif_bi, id_Contacto, id_Endereco, id_Tipo_Cliente) VALUES (@nome, @nif_bi, @id_Contacto, @id_Endereco, @id_Tipo_Cliente)";
                cmd.Parameters.AddWithValue("@nome", nomeCliente);
                cmd.Parameters.AddWithValue("@nif_bi", null);
                cmd.Parameters.AddWithValue("@id_Contacto", null);
                cmd.Parameters.AddWithValue("@id_Endereco", null);
                cmd.Parameters.AddWithValue("@id_Tipo_Cliente", (id_tipo_Cliente == 0) ? null : id_tipo_Cliente.ToString());

                cmd.ExecuteNonQuery();

                transacao.Commit();
                return cmd.LastInsertedId;
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
        }

        //public object Alterar(uint id_Cliente, string nomeCliente, string nif_bi, short id_tipo_Cliente, uint idEndereco, string provincia, string municipio, string bairro, string rua, string casa, uint idContacto, string telefone, string email, ref MySqlCommand cmd)
        //{
        //    cmd.CommandText = "UPDATE `tbl_endereco` SET provincia`= @provincia,`municipio`= @municipio,`bairro`= @bairro,`rua`= @rua,`casa`= @casa WHERE `id_Endereco`= @id_Endereco";
        //    cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //    cmd.Parameters.AddWithValue("@provincia", provincia);
        //    cmd.Parameters.AddWithValue("@municipio", municipio);
        //    cmd.Parameters.AddWithValue("@bairro", bairro);
        //    cmd.Parameters.AddWithValue("@rua", rua);
        //    cmd.Parameters.AddWithValue("@casa", casa);
        //    cmd.ExecuteNonQuery();

        //    cmd.Parameters.Clear();
        //    cmd.CommandText = "UPDATE `tbl_contacto` SET `telefone`= @telefone,`email`= @email WHERE @id_Contacto";
        //    cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //    cmd.Parameters.AddWithValue("@telefone", telefone);
        //    cmd.Parameters.AddWithValue("@email", email);
        //    cmd.ExecuteNonQuery();

        //    cmd.Parameters.Clear();
        //    cmd.CommandText = "UPDATE `tbl_cliente` SET nome = @nome,nif_bi = @nif_bi,id_Contacto = @id_Contacto,id_Endereco = @id_Endereco,id_Tipo_Cliente = @id_Tipo_Cliente WHERE id_Cliente = @id_Cliente";
        //    cmd.Parameters.AddWithValue("@id_Cliente", id_Cliente);
        //    cmd.Parameters.AddWithValue("@nome", nomeCliente);
        //    cmd.Parameters.AddWithValue("@nif_bi", nif_bi);
        //    cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //    cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //    cmd.Parameters.AddWithValue("@id_Tipo_Cliente", (id_tipo_Cliente == 0) ? null : id_tipo_Cliente.ToString());
        //    cmd.ExecuteNonQuery();

        //    return id_Cliente;
        //}

        //public object Eliminar(uint id_Cliente, uint idEndereco, uint idContacto, MySqlCommand cmd)
        //{
        //    cmd.CommandText = "DELETE FROM tbl_endereco WHERE id_Endereco= @id_Endereco";
        //    cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //    cmd.ExecuteNonQuery();

        //    cmd.Parameters.Clear();
        //    cmd.CommandText = "DELETE FROM tbl_contacto WHERE @id_Contacto";
        //    cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //    cmd.ExecuteNonQuery();

        //    cmd.Parameters.Clear();
        //    cmd.CommandText = "DELETE FROM tbl_cliente WHERE id_Cliente= @id_Cliente";
        //    cmd.Parameters.AddWithValue("@id_Cliente", id_Cliente);
        //    cmd.ExecuteNonQuery();

        //    return id_Cliente;
        //}

        public object VerificarExistencia(string Nif_Bi)
        {
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand("SELECT id_Cliente FROM tbl_cliente  where nif_bi != null AND nif_bi='' LIMIT 1", Conexao);
                MySqlDataReader rd = cmd.ExecuteReader();
                
                if (rd.Read())
                    return rd[0];
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public DataTable CarregarTodos()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM vwcliente", Conexao);
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
