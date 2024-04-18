using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Dados
{
    public class Cs_Produto_Dados_Temp : Cs_Conexao
    {
        MySqlCommand cmd;

        public object Cadastrar(uint idProduto,float qtd)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "INSERT INTO tbl_temp_produto(id_Produto, quantidade) VALUES (@id_Produto, @quantidade)";
                cmd.Parameters.AddWithValue("@id_Produto", idProduto);
                cmd.Parameters.AddWithValue("@quantidade", qtd);
                            
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

        public object Eliminar(uint Id_Produto_Temp, ref MySqlCommand cmd_)
        {
            cmd_.Connection = Conexao;
            cmd_.CommandText = "DELETE FROM tbl_temp_produto WHERE Id_Produto_Temp = @Id_Produto_Temp";
            cmd_.Parameters.AddWithValue("@Id_Produto_Temp", Id_Produto_Temp);

            Conectar();

            return cmd_.ExecuteNonQuery();
        }

        public object EliminarTodos()
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "DELETE FROM tbl_temp_produto";

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

        public object Update_Produto_Temp(uint Id_Produto_Temp, float quantidade)
        {
            cmd = new MySqlCommand();
            object retorno = null;

            try
            {
                cmd.Connection = Conexao;
                cmd.CommandText = "UPDATE tbl_temp_produto SET quantidade=quantidade + @quantidade WHERE Id_Produto_Temp = @Id_Produto_Temp";
                cmd.Parameters.AddWithValue("@Id_Produto_Temp", Id_Produto_Temp);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
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

        public object CountProduto_Temp(uint Id_Produto)
        {
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand("select sum(quantidade) as total from tbl_temp_produto  WHERE id_Produto = @id_Produto  LIMIT 1", Conexao);
                cmd.Parameters.AddWithValue("@id_Produto", Id_Produto);
                MySqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    if (rd[0] == DBNull.Value)
                        return 0;
                    else
                        return rd[0];
                }
                else
                {
                    throw new Exception("Falha ao solicitar Produto");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
