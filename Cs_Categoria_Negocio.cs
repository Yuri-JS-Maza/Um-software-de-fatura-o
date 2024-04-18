using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Categoria_Negocio
    {
        short id;
        string nome;
        Cs_Categoria_Dados Categoria_Dados;

        public short Id
        {
            get { return id; }
            set {
                if (short.TryParse(value.ToString(), out id))
                    id = value;
                else
                    throw new Exception("Código da Categoria Inválido");
            }
        }

        public string Nome 
        {
            get { return nome; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da categoria Inválido");
                else
                nome = value; 
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                Categoria_Dados = new Cs_Categoria_Dados();
                retorno = Categoria_Dados.Cadastrar(this.Nome);
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
                Categoria_Dados = new Cs_Categoria_Dados();
                retorno = Categoria_Dados.Alterar(this.Id, this.Nome);
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
                Categoria_Dados = new Cs_Categoria_Dados();
                retorno = Categoria_Dados.Eliminar(this.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetCategoriasAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                Categoria_Dados = new Cs_Categoria_Dados();
                tabela = Categoria_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }

        //public object GetCategorias(string descricao)
        //{

        //}



        //public object ConsultarPorId(short id)
        //{

        //}      
    }
}
