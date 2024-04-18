using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Unidade_Negocio
    {
        short id;
        string nome;
        Cs_Unidade_Dados Unidade_Dados;

        public short Id
        {
            get { return id; }
            set
            {
                if (short.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código da Unidade Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da Unidade Inválido");
                else
                    nome = value;
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                Unidade_Dados = new Cs_Unidade_Dados();
                retorno = Unidade_Dados.Cadastrar(this.Nome);
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
                Unidade_Dados = new Cs_Unidade_Dados();
                retorno = Unidade_Dados.Alterar(this.Id, this.Nome);
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
                Unidade_Dados = new Cs_Unidade_Dados();
                retorno = Unidade_Dados.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetUnidadesAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Unidade_Dados = new Cs_Unidade_Dados();
                tabela = Unidade_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        //public object GetUnidades(string descricao)
        //{

        //}



        //public object ConsultarPorId(short id)
        //{

        //}
    }
}
