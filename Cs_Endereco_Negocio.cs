using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Negocio
{
    public class Cs_Endereco_Negocio
    {
        uint idEndereco;
        string provincia;
        string municipio;
        string bairro;
        string rua;
        string casa;

        public uint IdEndereco
        {
            get { return idEndereco; }
            set
            {
                if (uint.TryParse(value.ToString(), out idEndereco))
                    idEndereco = value;
                else
                    throw new Exception("Código do Endereco Inválido");
            }
        }

        public string Provincia
        {
            get { return provincia; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Nome da Província inválida");
                else
                    provincia = value;
            }
        }

        public string Municipio
        {
            get { return municipio; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Nome do Município inválido");
                else
                    municipio = value;
            }
        }
        public string Bairro
        {
            get { return bairro; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Nome do Bairro inválido");
                else
                    bairro = value;
            }
        }

        public string Rua
        {
            get { return rua; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Nome da Rua inválido");
                else
                    rua = value;
            }
        }
        public string Casa
        {
            get { return casa; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Nº da Casa inválido");
                else
                    casa = value;
            }
        }
        
    }
}
