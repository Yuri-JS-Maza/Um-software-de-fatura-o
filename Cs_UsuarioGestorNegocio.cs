using System;
using System.Data;
using Camada_Dados;

namespace Camada_Negocio
{
    public class Cs_UsuarioGestorNegocio : Cs_Usuario_Negocio
    {
        Cs_UsuarioGestorDados usuarioGestorDados;
        short idGestor;
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

        public object Cadastrar()
        {
            try
            {
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.Cadastrar(IdGestor, Usuario, Senha);
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
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.Alterar(IdUsuario, Usuario, Senha);
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
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.Eliminar(IdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetUsuariosGestoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.CarregarTodos();
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
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.Logar(Usuario,Senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable GetListarGestoresAll()
        {
            DataTable tabela = new DataTable();
            try
            {
                usuarioGestorDados = new Cs_UsuarioGestorDados();
                return usuarioGestorDados.ListarGestores();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
