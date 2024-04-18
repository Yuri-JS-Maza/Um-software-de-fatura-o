using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camada_Negocio;

namespace Camada_Apresentacao
{
    public partial class frm_Login : Form
    {
        Cs_UsuarioVendedorNegocio usuarioVendedor;
        Cs_UsuarioGestorNegocio usuarioGestor;

        public frm_Login()
        {
            InitializeComponent();
        }

        private async void btnLogar_Click(object sender, EventArgs e)
        {
            if (await Logar())
            {
                new frmMenu().Show();
                Hide();
            }
        }

        Task<bool> Logar()
        {
            string tipoUsuario = cboTipoUsuario.Text.Trim().ToUpper();
            bool status = false;
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    btnLogar.Invoke((MethodInvoker)(() => btnLogar.Enabled = false));
                    picLogar.Invoke((MethodInvoker)(() => picLogar.Visible = true));

                    if (tipoUsuario == "GESTOR")
                    {
                        usuarioGestor = new Cs_UsuarioGestorNegocio();
                        usuarioGestor.Usuario = txtUsuario.Text;
                        usuarioGestor.Senha = txtSenha.Text;
                        DataTable dt = usuarioGestor.Logar();
                        if (dt.Rows.Count > 0)
                        {
                            DataRow linha = dt.Rows[0];
                            Status.id = (short)linha["id_Gestor"];
                            Status.is_Gestor = true;
                            Status.nome = linha["Nome"].ToString();
                            Status.usuario = linha["Usuário"].ToString();

                            status = true;
                        }
                        else
                        {
                            throw new Exception("Senha ou Usuário inválido");
                        }
                    }
                    else if (tipoUsuario == "VENDEDOR")
                    {
                        usuarioVendedor = new Cs_UsuarioVendedorNegocio();
                        usuarioVendedor.Usuario = txtUsuario.Text;
                        usuarioVendedor.Senha = txtSenha.Text;
                        DataTable dt = usuarioVendedor.Logar();
                        if (dt.Rows.Count > 0)
                        {
                            DataRow linha = dt.Rows[0];
                            Status.id = (short)linha["id_Vendedor"];
                            Status.is_Gestor = false;
                            Status.nome = linha["Nome"].ToString();
                            Status.usuario = linha["Usuário"].ToString();

                            status = true;
                        }
                        else
                        {
                            throw new Exception("Senha ou Usuário inválido");
                        }
                    }
                    else
                    {
                        throw new Exception("Tipo de usuário inválido");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnLogar.Invoke((MethodInvoker)(() => btnLogar.Enabled = true));
                    picLogar.Invoke((MethodInvoker)(() => picLogar.Visible = false));
                    txtUsuario.Invoke((MethodInvoker)(() => txtUsuario.Focus()));
                }
                return status;
            });
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            if (cboTipoUsuario.Items.Count > 0)
                cboTipoUsuario.SelectedIndex = 0;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tens certeza que desejas fechar? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();           
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtSenha.Focus();
        }

        private async void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (await Logar())
                {
                    new frmMenu().Show();
                    Hide();
                }
            }
        }
    }
}
