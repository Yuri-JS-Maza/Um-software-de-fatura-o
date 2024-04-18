using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Marca_Negocio
    {
        short id;
        string nome;
        Cs_Marca_Dados Marca_Dados;

        public short Id
        {
            get { return id; }
            set
            {
                if (short.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código da Marca Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("Nome da Marca Inválido");
                else
                    nome = value;
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                Marca_Dados = new Cs_Marca_Dados();
                retorno = Marca_Dados.Cadastrar(this.Nome);
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
                Marca_Dados = new Cs_Marca_Dados();
                retorno = Marca_Dados.Alterar(this.Id,this.Nome);
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
                Marca_Dados = new Cs_Marca_Dados();
                retorno = Marca_Dados.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetMarcaAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Marca_Dados = new Cs_Marca_Dados();
                tabela = Marca_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        public object GetMarca(string descricao)
        {
            DataTable tabela = new DataTable();
            try
            {
                Marca_Dados = new Cs_Marca_Dados();
               tabela = Marca_Dados.Carregar(descricao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }



        //public object ConsultarPorId(short id)
        //{

        //}
    }
}
