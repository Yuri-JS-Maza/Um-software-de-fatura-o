using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Negocio
{
    public class Cs_Pessoa_Negocio
    {
        uint idPessoa;
        string nome;
        string sobrenome;
        char genero;
        string bi;
        DateTime dataNascimento;
        public Cs_Endereco_Negocio Endereco { get; set; }
        public Cs_Contacto_Negocio Contacto { get; set; }

        public uint IdPessoa
        {
            get { return idPessoa; }
            set
            {
                if (uint.TryParse(value.ToString(), out idPessoa))
                    idPessoa = value;
                else
                    throw new Exception("Código da Pessoa Inválido");
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Nome da pessoa Inválido");
                else
                    nome = value;
            }
        }

        public string Sobrenome
        {
            get { return sobrenome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Sobrenome da pessoa Inválido");
                else
                    sobrenome = value;
            }
        }

        public string BI
        {
            get { return bi; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("B.I da pessoa Inválido");
                else
                    bi = value;
            }
        }

        public char Genero
        {
            get { return genero; }
            set
            {
                if (char.IsNumber(value) || char.IsWhiteSpace(value) || string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Gênero da pessoa Inválido");
                else
                    genero = value;
            }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set
            {
                if (!DateTime.TryParse(value.ToString(), out dataNascimento))
                    throw new Exception("Data de Nascimento da pessoa Inválido");
                else
                    dataNascimento = value;
            }
        }

        //public uint IdEndereco
        //{
        //    get { return idEndereco; }
        //    set
        //    {
        //        if (uint.TryParse(value.ToString(), out idEndereco))
        //            idEndereco = value;
        //        else
        //            throw new Exception("Código do Endereço Pessoa Inválido");
        //    }
        //}

        //public uint Idcontacto
        //{
        //    get { return idContacto; }
        //    set
        //    {
        //        if (uint.TryParse(value.ToString(), out idContacto))
        //            idContacto = value;
        //        else
        //            throw new Exception("Código do Contacto Pessoa Inválido");
        //    }
        //}
    }
}
