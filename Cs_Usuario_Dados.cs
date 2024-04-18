using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Camada_Dados;

namespace Camada_Dados
{
    public class Cs_Usuario_Dados : Cs_Conexao
    {       
        public object CadastrarUsuario(string usuario, string senha, ref MySqlCommand cmd)
        {

            cmd.CommandText = "INSERT INTO `tbl_usuario`(usuario, senha) VALUES (@usuario,MD5(@senha))";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public object AlterarUsuario(short idUsuario, string usuario, string senha,ref MySqlCommand cmd)
        {

            cmd.Parameters.Clear();
            //cmd.CommandText = "UPDATE `tbl_usuario` SET `usuario`= @usuario,`senha`= @senha WHERE `id_Usuario` = @id_Usuario";
            cmd.CommandText = "UPDATE `tbl_usuario` SET `usuario`= @usuario,`senha`= @senha WHERE `id_Usuario` = @id_Usuario";
            cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            //cmd.Parameters.AddWithValue("@senha", senha);
            return cmd.ExecuteNonQuery();
          
        }

        public void EliminarUsuario(short idUsuario,ref MySqlCommand cmd)
        {
            cmd.CommandText = "DELETE FROM tbl_usuario WHERE id_Usuario= @id_Usuario";
            cmd.Parameters.AddWithValue("@id_Usuario", idUsuario);
            cmd.ExecuteNonQuery();
        }
    }
}
