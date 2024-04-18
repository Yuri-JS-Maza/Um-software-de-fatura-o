using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Cliente_Negocio
    {
        uint idCliente;
        string nome;
        string nif_bi;
        public Cs_Endereco_Negocio EnderecoCliente { get; set; }
        public Cs_Contacto_Negocio ContactoCliente { get; set; }
        short id_TipoCliente;

        Cs_Cliente_Dados  clienteDados;

        public uint IdCliente
        {
            get { return idCliente; }

            set
            {
                if (!uint.TryParse(value.ToString(), out idCliente))
                    throw new Exception("Código do Cliente inválido");
                else
                    idCliente = value;
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome do cliente Inválido");
                else
                    nome = value;
            }
        }

        public string Nif_Bi
        {
            get { return nif_bi; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("NIF ou B.I do cliente Inválido");
                else
                    nif_bi = value;
            }
        }

        public short Id_Tipo_Cliente
        {
            get { return id_TipoCliente; }

            set
            {
                if (!short.TryParse(value.ToString(), out id_TipoCliente))
                    throw new Exception("Código do Tipo de Cliente inválido");
                else
                    id_TipoCliente = value;
            }
        }

        public object Cadastrar()
        {
            clienteDados = new Cs_Cliente_Dados();
            return clienteDados.Cadastrar(Nome, Nif_Bi, Id_Tipo_Cliente, EnderecoCliente.Provincia, EnderecoCliente.Municipio, EnderecoCliente.Bairro, EnderecoCliente.Rua, EnderecoCliente.Casa, ContactoCliente.Telefone, ContactoCliente.Email);
            
        }

        //public object Alterar()
        //{

        //}

        //public object Eliminar()
        //{

        //}

        //public DataTable Cadastrar()
        //{

        //}
    }
}
