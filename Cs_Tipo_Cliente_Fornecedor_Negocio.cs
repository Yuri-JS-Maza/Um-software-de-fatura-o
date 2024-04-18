using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Tipo_Cliente_Fornecedor_Negocio
    {
        public DataTable GetTipoClienteFornecedorAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Cs_Tipo_Cliente_Fornecedor_Dados tipoCli_Forn = new Cs_Tipo_Cliente_Fornecedor_Dados();
                tabela = tipoCli_Forn.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
    }
}
