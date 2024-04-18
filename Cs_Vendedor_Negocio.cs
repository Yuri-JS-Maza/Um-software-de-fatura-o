using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;
using System.Data;

namespace Camada_Negocio
{
    public class Cs_Vendedor_Negocio : Cs_Pessoa_Negocio
    {
        short idVendedor;
        bool status;
        DateTime dataAdmissao;
        string numCredencial;

        Cs_Vendedor_Dados vendedor_Dados;

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
                    throw new Exception("Data de Admissão do vendedor Inválido");
                else
                    dataAdmissao = value;
            }
        }

        public short IdVendedor
        {
            get { return idVendedor; }
            set
            {
                if (short.TryParse(value.ToString(), out idVendedor))
                    idVendedor = value;
                else
                    throw new Exception("Código do Vendedor Inválido");
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
                vendedor_Dados = new Cs_Vendedor_Dados();
                retorno = vendedor_Dados.Cadastrar(Nome,Sobrenome,Genero,BI,DataNascimento,DataAdmissao,NumCredencial,Status,Endereco.Provincia, Endereco.Municipio, Endereco.Bairro, Endereco.Rua, Endereco.Casa, Contacto.Telefone, Contacto.Email);

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
                vendedor_Dados = new Cs_Vendedor_Dados();
                retorno = vendedor_Dados.Alterar(IdPessoa,Nome, Sobrenome, Genero, BI, DataNascimento,IdVendedor, DataAdmissao, NumCredencial, Status,Endereco.IdEndereco, Endereco.Provincia, Endereco.Municipio, Endereco.Bairro, Endereco.Rua, Endereco.Casa,Contacto.IdContacto ,Contacto.Telefone, Contacto.Email);

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
                vendedor_Dados = new Cs_Vendedor_Dados();
                retorno = vendedor_Dados.Eliminar(IdPessoa, Endereco.IdEndereco, Contacto.IdContacto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retorno;
        }

        public DataTable GetVendedoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                vendedor_Dados = new Cs_Vendedor_Dados();
                tabela = vendedor_Dados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabela;
        }
    }
}
