using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Modelo_Negocio
    {
        short id;
        string nome;
        Cs_Modelo_Dados Modelo_Dados;

        public short Id
        {
            get { return id; }
            set
            {
                if (short.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código da Modelo Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da Modelo Inválido");
                else
                    nome = value;
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                Modelo_Dados = new Cs_Modelo_Dados();
                retorno = Modelo_Dados.Cadastrar(this.Nome);
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
                Modelo_Dados = new Cs_Modelo_Dados();
                retorno = Modelo_Dados.Alterar(this.Id, this.Nome);
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
                Modelo_Dados = new Cs_Modelo_Dados();
                retorno = Modelo_Dados.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetModeloAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Modelo_Dados = new Cs_Modelo_Dados();
                tabela = Modelo_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        //public object GetModelo(string descricao)
        //{

        //}



        //public object ConsultarPorId(short id)
        //{

        //}
    }
}
