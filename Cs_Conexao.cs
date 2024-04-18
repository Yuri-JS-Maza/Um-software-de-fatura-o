using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Camada_Dados
{
    public class Cs_Conexao
    {
        public MySqlConnection Conexao = new MySqlConnection(@"server=localhost;database=db_banco;uid=root");

        public void Conectar()
        {
            try
            {
                if (Conexao.State == ConnectionState.Closed)
                    Conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Desconectar()
        {
            try
            {
                if (Conexao.State == ConnectionState.Open)
                    Conexao.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
