using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;
using System.Data;

namespace Camada_Negocio
{
    public class Cs_Gestor_Negocio : Cs_Pessoa_Negocio
    {
        short idGestor;
        bool status;
        DateTime dataAdmissao;
        string numCredencial;

        Cs_Gestor_Dados gestorDados;

        public bool Status
        {
            get { return status; }
            set {status = value; }
        }

        public DateTime DataAdmissao
        {
            get { return dataAdmissao; }
            set
            {
                if (!DateTime.TryParse(value.ToString(), out dataAdmissao))
                    throw new Exception("Data de Admissão do gestor Inválido");
                else
                    dataAdmissao = value;
            }
        }

        public short IdGestor
        {
            get { return idGestor; }
            set
            {
                if (short.TryParse(value.ToString(), out idGestor))
                    idGestor = value;
                else
                    throw new Exception("Código do Gestor Inválido");
            }
        }

        public string NumCredencial
        {
            get { return numCredencial; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value.Length > 15)
                    throw new Exception("Nº do credencial inválido");
                else
                    numCredencial = value;
            }
        }

        public object Cadastrar()
        {
            object retorno = null;

            try
            {
                gestorDados = new Cs_Gestor_Dados();
                retorno = gestorDados.Cadastrar(Nome,Sobrenome,Genero,BI,DataNascimento,DataAdmissao,NumCredencial,Status,Endereco.Provincia, Endereco.Municipio, Endereco.Bairro, Endereco.Rua, Endereco.Casa, Contacto.Telefone, Contacto.Email);

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
                gestorDados = new Cs_Gestor_Dados();
                retorno = gestorDados.Alterar(IdPessoa,Nome, Sobrenome, Genero, BI, DataNascimento,IdGestor, DataAdmissao, NumCredencial, Status,Endereco.IdEndereco, Endereco.Provincia, Endereco.Municipio, Endereco.Bairro, Endereco.Rua, Endereco.Casa,Contacto.IdContacto ,Contacto.Telefone, Contacto.Email);

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
                gestorDados = new Cs_Gestor_Dados();
                retorno = gestorDados.Eliminar(IdPessoa, Endereco.IdEndereco, Contacto.IdContacto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetGestoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                gestorDados = new Cs_Gestor_Dados();
                tabela = gestorDados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
    }
}
