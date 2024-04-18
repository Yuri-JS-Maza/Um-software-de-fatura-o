using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Tipo_Cliente_Fornecedor_Dados : Cs_Conexao
    {
        public DataTable CarregarTodos()
        {
            DataTable tabela = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *FROM tbl_tipo_cliente_fornecedor", Conexao);
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
