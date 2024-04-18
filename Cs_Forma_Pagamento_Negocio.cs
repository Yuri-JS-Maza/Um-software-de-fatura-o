using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Forma_Pagamento_Negocio
    {
        short id;
        string nome;
        Cs_Forma_Pagamento_Dados Forma_Pagamento;

        public short Id
        {
            get { return id; }
            set
            {
                if (short.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código da Forma de Pagamento Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da Forma de Pagamento Inválido");
                else
                    nome = value;
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                Forma_Pagamento = new Cs_Forma_Pagamento_Dados();
                retorno = Forma_Pagamento.Cadastrar(this.Nome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public object Alterar()
        {
            object retorno = null;

            try
            {
                Forma_Pagamento = new Cs_Forma_Pagamento_Dados();
                retorno = Forma_Pagamento.Alterar(this.Id, this.Nome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public object Eliminar()
        {
            object retorno = null;

            try
            {
                Forma_Pagamento = new Cs_Forma_Pagamento_Dados();
                retorno = Forma_Pagamento.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetFormaDePagamentoAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Forma_Pagamento = new Cs_Forma_Pagamento_Dados();
                tabela = Forma_Pagamento.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        //public object GetFormaDePagamento(string descricao)
        //{

        //}



        //public object ConsultarPorId(short id)
        //{

        //}
    }
}
