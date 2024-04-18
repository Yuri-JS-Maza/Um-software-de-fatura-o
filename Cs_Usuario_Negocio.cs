using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_Usuario_Negocio
    {
        short idUsuario;
        string usuario;
        string senha;

        public short IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (short.TryParse(value.ToString(), out idUsuario))
                    idUsuario = value;
                else
                    throw new Exception("Código do Usuário Inválido");
            }
        }

        public string Usuario
        {
            get { return usuario; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Usuário Inválido");
                else
                    usuario = value;
            }
        }

        public string Senha
        {
            get { return senha; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Senha Inválida");
                else
                    senha = value;
            }
        }
    }
}
