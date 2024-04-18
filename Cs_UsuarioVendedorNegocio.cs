using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Dados;
using System.Data;

namespace Camada_Negocio
{
    public class Cs_UsuarioVendedorNegocio : Cs_Usuario_Negocio
    {
        short idVendedor;
        Cs_UsuarioVendedorDados usuarioVendedorDados;

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
            
        public object Cadastrar()
        {
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.Cadastrar(IdVendedor, Usuario, Senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object Alterar()
        {
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.Alterar(IdUsuario, Usuario, Senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public object Eliminar()
        {
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.Eliminar(IdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetUsuariosVendedoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.CarregarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Logar()
        {
            DataTable tabela = new DataTable();
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.Logar(Usuario,Senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetListarVendedoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                usuarioVendedorDados = new Cs_UsuarioVendedorDados();
                return usuarioVendedorDados.ListarVendedores();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
