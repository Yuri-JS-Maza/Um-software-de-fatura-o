using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Negocio
{
    public class Cs_Contacto_Negocio
    {
        uint idContacto;
        string telefone;
        string email;
        
        public uint IdContacto
        {
            get { return idContacto; }
            set
            {
                if (uint.TryParse(value.ToString(), out idContacto))
                    idContacto = value;
                else
                    throw new Exception("Código do Contacto Inválido");
            }
        }

        public string Telefone
        {
            get { return telefone; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()) || value.Length > 15)
                    throw new Exception("Nº do telefone inválido");
                else
                    telefone = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Email inválido");
                else
                    email = value;
            }
        }
    }
}
