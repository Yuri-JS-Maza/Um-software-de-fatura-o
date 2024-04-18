using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Venda_Dados : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(short idVendedor, double total, double desconto, double valorPago, double troco, short idFPagamento, string nomeCliente, string nif_bi, short id_tipo_Cliente, string provincia, string municipio, string bairro, string rua, string casa, string telefone, string email, List<object[]> ItensProduto)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;

            try
            {
                Cs_Cliente_Dados clienteDados = new Cs_Cliente_Dados();
                object idCliente = clienteDados.Cadastrar(nomeCliente, nif_bi, id_tipo_Cliente, provincia, municipio, bairro, rua, casa, telefone, email, ref cmd);

                cmd.CommandText = "INSERT INTO `tbl_venda`(id_Vendedor, id_Cliente, total, desconto, valor_Pago, troco, id_Forma_Pagamento) VALUES (@id_Vendedor, @id_Cliente, @total, @desconto, @valor_Pago, @troco, @id_Forma_Pagamento)";
                cmd.Parameters.AddWithValue("@id_Vendedor", idVendedor);
                cmd.Parameters.AddWithValue("@id_Cliente", idCliente);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@valor_Pago", valorPago);
                cmd.Parameters.AddWithValue("@troco", troco);
                cmd.Parameters.AddWithValue("@id_Forma_Pagamento", idFPagamento);
                cmd.ExecuteNonQuery();
                object idVenda = cmd.LastInsertedId;

                foreach (object[] item in ItensProduto)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO `tbl_itens_venda`(id_Venda, id_Produto, preco, quantidade, desconto) VALUES (@id_Venda, @id_Produto, @preco, @quantidade, @desconto)";
                    cmd.Parameters.AddWithValue("@id_Venda", idVenda);
                    cmd.Parameters.AddWithValue("@id_Produto", item[0]);
                    cmd.Parameters.AddWithValue("@preco", item[1]);
                    cmd.Parameters.AddWithValue("@quantidade", item[2]);
                    cmd.Parameters.AddWithValue("@desconto", item[3]);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE tbl_produto SET quantidade = quantidade - @quantidade WHERE id_Produto = @id_Produto";
                    cmd.Parameters.AddWithValue("@id_Produto", item[0]);
                    cmd.Parameters.AddWithValue("@quantidade", item[2]);
                    cmd.ExecuteNonQuery();
                }

                transacao.Commit();
                return idVenda;
                //return idCliente;
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
        public object Cadastrar(short idVendedor, double total, double desconto, double valorPago, double troco, short idFPagamento, string nomeCliente, short id_tipo_Cliente,List<object[]> ItensProduto)
        {
            Conectar();
            MySqlTransaction transacao = Conexao.BeginTransaction();
            cmd = new MySqlCommand();
            cmd.Transaction = transacao;
            cmd.Connection = transacao.Connection;

            try
            {
                Cs_Cliente_Dados clienteDados = new Cs_Cliente_Dados();
                object idCliente = clienteDados.Cadastrar(nomeCliente, id_tipo_Cliente, ref cmd);

                cmd.CommandText = "INSERT INTO `tbl_venda`(id_Vendedor, id_Cliente, total, desconto, valor_Pago, troco, id_Forma_Pagamento) VALUES (@id_Vendedor, @id_Cliente, @total, @desconto, @valor_Pago, @troco, @id_Forma_Pagamento)";
                cmd.Parameters.AddWithValue("@id_Vendedor", idVendedor);
                cmd.Parameters.AddWithValue("@id_Cliente", idCliente);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@desconto", desconto);
                cmd.Parameters.AddWithValue("@valor_Pago", valorPago);
                cmd.Parameters.AddWithValue("@troco", troco);
                cmd.Parameters.AddWithValue("@id_Forma_Pagamento", idFPagamento);
                cmd.ExecuteNonQuery();
                object idVenda = cmd.LastInsertedId;

                foreach (object[] item in ItensProduto)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO `tbl_itens_venda`(id_Venda, id_Produto, preco, quantidade, desconto) VALUES (@id_Venda, @id_Produto, @preco, @quantidade, @desconto)";
                    cmd.Parameters.AddWithValue("@id_Venda", idVenda);
                    cmd.Parameters.AddWithValue("@id_Produto", item[0]);
                    cmd.Parameters.AddWithValue("@preco", item[1]);
                    cmd.Parameters.AddWithValue("@quantidade", item[2]);
                    cmd.Parameters.AddWithValue("@desconto", item[3]);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE tbl_produto SET quantidade = quantidade - @quantidade WHERE id_Produto = @id_Produto";
                    cmd.Parameters.AddWithValue("@id_Produto", item[0]);
                    cmd.Parameters.AddWithValue("@quantidade", item[2]);
                    cmd.ExecuteNonQuery();
                }

                transacao.Commit();
                return idVenda;
                //return idCliente;
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

        //public object Alterar(uint idPessoa, string nome, string sobrenome, char genero, string bi, DateTime nascimento, short idVendedor, DateTime datAdmissao, string numCredencial, bool status, uint idEndereco, string provincia, string municipio, string bairro, string rua, string casa, uint idContacto, string telefone, string email)
        //{
        //    Conectar();
        //    MySqlTransaction transacao = Conexao.BeginTransaction();
        //    cmd = new MySqlCommand();
        //    cmd.Transaction = transacao;
        //    cmd.Connection = transacao.Connection;
        //    object retorno = null;

        //    try
        //    {
        //        cmd.CommandText = "UPDATE tbl_endereco SET provincia= @provincia,`municipio`= @municipio,`bairro`= @bairro,`rua`= @rua,`casa`= @casa WHERE `id_Endereco`= @id_Endereco";
        //        cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //        cmd.Parameters.AddWithValue("@provincia", provincia);
        //        cmd.Parameters.AddWithValue("@municipio", municipio);
        //        cmd.Parameters.AddWithValue("@bairro", bairro);
        //        cmd.Parameters.AddWithValue("@rua", rua);
        //        cmd.Parameters.AddWithValue("@casa", casa);
        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "UPDATE `tbl_contacto` SET `telefone`= @telefone,`email`= @email WHERE id_Contacto = @id_Contacto";
        //        cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //        cmd.Parameters.AddWithValue("@telefone", telefone);
        //        cmd.Parameters.AddWithValue("@email", email);
        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "UPDATE `tbl_pessoa` SET `nome`= @nome,`sobrenome`= @sobrenome,`genero`= @genero,`bi`= @bi,`data_nascimento`= @data_nascimento,`id_Contacto`= @id_Contacto,`id_Endereco`= @id_Endereco WHERE  `id_Pessoa`= @id_Pessoa";
        //        cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
        //        cmd.Parameters.AddWithValue("@nome", nome);
        //        cmd.Parameters.AddWithValue("@sobrenome", sobrenome);
        //        cmd.Parameters.AddWithValue("@genero", genero);
        //        cmd.Parameters.AddWithValue("@bi", bi);
        //        cmd.Parameters.AddWithValue("@data_nascimento", nascimento);
        //        cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //        cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "UPDATE `tbl_vendedor` SET `id_Pessoa`= @id_Pessoa,`dataAdmissao`= @dataAdmissao,`num_Credencial`= @num_Credencial,`status`= @status WHERE `id_Vendedor`= @id_Vendedor";
        //        cmd.Parameters.AddWithValue("@id_Vendedor", idVendedor);
        //        cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
        //        cmd.Parameters.AddWithValue("@dataAdmissao", datAdmissao);
        //        cmd.Parameters.AddWithValue("@num_Credencial", numCredencial);
        //        cmd.Parameters.AddWithValue("@status", status);
        //        retorno = cmd.ExecuteNonQuery();

        //        transacao.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        transacao.Rollback();
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }
        //    return retorno;
        //}

        //public object Eliminar(uint idPessoa, uint idEndereco, uint idContacto)
        //{
        //    Conectar();
        //    MySqlTransaction transacao = Conexao.BeginTransaction();
        //    cmd = new MySqlCommand();
        //    cmd.Transaction = transacao;
        //    cmd.Connection = transacao.Connection;
        //    object retorno = null;

        //    try
        //    {
        //        cmd.CommandText = "DELETE FROM tbl_endereco WHERE id_Endereco= @id_Endereco";
        //        cmd.Parameters.AddWithValue("@id_Endereco", idEndereco);
        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "DELETE FROM tbl_contacto WHERE @id_Contacto";
        //        cmd.Parameters.AddWithValue("@id_Contacto", idContacto);
        //        cmd.ExecuteNonQuery();

        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "DELETE FROM tbl_pessoa WHERE id_Pessoa= @id_Pessoa";
        //        cmd.Parameters.AddWithValue("@id_Pessoa", idPessoa);
        //        cmd.ExecuteNonQuery();

        //        transacao.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        transacao.Rollback();
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }
        //    return retorno;
        //}

        public DataTable CarregarTodos()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM vwVendas ", Conexao);
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

        public DataTable ConsultarVenda(uint codigoVenda)
        {
            DataTable tabela = new DataTable();
            try
            {                
                MySqlCommand cmd = new MySqlCommand("SELECT *FROM vwVendas WHERE codigo = @codigo", Conexao);
                cmd.Parameters.AddWithValue("@codigo", codigoVenda);
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

        public DataTable ConsultarItens(uint codigoVenda)
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select *from vwItensVenda WHERE Codigo_Venda = @codigo", Conexao);
                cmd.Parameters.AddWithValue("@codigo", codigoVenda);
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
