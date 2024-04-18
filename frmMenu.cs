using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camada_Apresentacao.UserControls;

namespace Camada_Apresentacao
{
    public partial class frmMenu : Form
    {
        UcDashboard dash;
        UcProdutos prod;
        UcEntrada entrada;
        UcSaida saida;
        UcInventario inve;
        UcGestores gest;
        UcVendedores vend;
        UcUsuarios usu;
        UcFornecedores forn;
        UcClientes cli;
        UcMais mais;
        
        public frmMenu()
        {
            InitializeComponent();
            tslVersao.Text = "Versão: " + Application.ProductVersion;
            panelActive.Location = new Point(btnDashboard.Location.X, btnDashboard.Location.Y);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdicionarControl("Dashboard");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnDashboard.Location.X, btnDashboard.Location.Y);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            AdicionarControl("Produtos");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnProdutos.Location.X, btnProdutos.Location.Y);
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            AdicionarControl("Entrada");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnEntrada.Location.X, btnEntrada.Location.Y);
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            AdicionarControl("Saida");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnSaida.Location.X, btnSaida.Location.Y);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AdicionarControl("Inventario");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnInventario.Location.X, btnInventario.Location.Y);
        }

        private void btnGestores_Click(object sender, EventArgs e)
        {
            AdicionarControl("Gestores");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnGestores.Location.X, btnGestores.Location.Y);
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            AdicionarControl("Vendedores");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnVendedores.Location.X, btnVendedores.Location.Y);
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AdicionarControl("Usuarios");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnUsuario.Location.X, btnUsuario.Location.Y);
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            AdicionarControl("Fornecedores");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnFornecedores.Location.X, btnFornecedores.Location.Y);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AdicionarControl("Clientes");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnClientes.Location.X, btnClientes.Location.Y);
        }

        private void btnMais_Click(object sender, EventArgs e)
        {
            AdicionarControl("Mais");
            ActiveButton(sender);
            //panelActive.Location = new Point(btnMais.Location.X, btnMais.Location.Y);
        }

        void AdicionarControl(string control)
        {
            switch (control)
            {
                case "Dashboard" :
                    if (!panelContent.Contains(dash))
                    {
                        dash = new UcDashboard();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(dash);
                        dash.Invoke((MethodInvoker)(() => dash.Dock = DockStyle.Fill));
                    }
                    break;
                case "Produtos":
                    if (!panelContent.Contains(prod))
                    {
                        prod = new UcProdutos();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(prod);
                        prod.Invoke((MethodInvoker)(() => prod.Dock = DockStyle.Fill));
                    }
                    break;
                case "Entrada":
                    if (!panelContent.Contains(entrada))
                    {
                        entrada = new UcEntrada();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(entrada);
                        entrada.Invoke((MethodInvoker)(() => entrada.Dock = DockStyle.Fill));
                    }
                    break;
                case "Saida":
                    if (!panelContent.Contains(saida))
                    {
                        saida = new UcSaida();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(saida);
                        saida.Invoke((MethodInvoker)(() => saida.Dock = DockStyle.Fill));
                    }
                    break;
                case "Inventario":
                    if (!panelContent.Contains(inve))
                    {
                        inve = new UcInventario();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(inve);
                        inve.Invoke((MethodInvoker)(() => inve.Dock = DockStyle.Fill));
                    }
                    break;
                case "Gestores":
                    if (!panelContent.Contains(gest))
                    {
                        gest = new UcGestores();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(gest);
                        gest.Invoke((MethodInvoker)(() => gest.Dock = DockStyle.Fill));
                    }
                    break;
                case "Vendedores":
                    if (!panelContent.Contains(vend))
                    {
                        vend = new UcVendedores();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(vend);
                        vend.Invoke((MethodInvoker)(() => vend.Dock = DockStyle.Fill));
                    }
                    break;
                case "Usuarios":
                    if (!panelContent.Contains(usu))
                    {
                        usu = new UcUsuarios();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(usu);
                        usu.Invoke((MethodInvoker)(() => usu.Dock = DockStyle.Fill));
                    }
                    break;
                case "Fornecedores":
                    if (!panelContent.Contains(forn))
                    {
                        forn = new UcFornecedores();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(forn);
                        forn.Invoke((MethodInvoker)(() => forn.Dock = DockStyle.Fill));
                    }
                    break;
                case "Clientes":
                    if (!panelContent.Contains(cli))
                    {
                        cli = new UcClientes();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(cli);
                        cli.Invoke((MethodInvoker)(() => cli.Dock = DockStyle.Fill));
                    }
                    break;
                case "Mais":
                    if (!panelContent.Contains(mais))
                    {
                        mais = new UcMais();
                        panelContent.Controls.Clear();
                        panelContent.Controls.Add(mais);
                        mais.Invoke((MethodInvoker)(() => mais.Dock = DockStyle.Fill));
                    }
                    break;
            }
        }

        void ActiveButton(object button)
        {
            List<Button> botoes = new List<Button>();
            botoes.Add(btnDashboard);
            botoes.Add(btnProdutos);
            botoes.Add(btnEntrada);
            botoes.Add(btnSaida);
            botoes.Add(btnInventario);
            botoes.Add(btnGestores);
            botoes.Add(btnVendedores);
            botoes.Add(btnUsuario);
            botoes.Add(btnFornecedores);
            botoes.Add(btnClientes);
            botoes.Add(btnMais);

            foreach(Button btn in botoes)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }

            Button btn_ = (Button)button;
            btn_.BackColor = Color.Purple;
            btn_.ForeColor=Color.White;
        }

        private void tsCaixa_Click(object sender, EventArgs e)
        {
            frmCaixa caixa = new frmCaixa();
            caixa.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.tsFuncionario.Text = "Funcionário Logado: " + Status.nome;
            if (Status.is_Gestor)
                tsCaixa.Enabled = false;
        }

        private void tsTeclado_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("OSK");
        }

        private void tsCalc_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(MessageBox.Show("Tens certeza que desejas fechar?","SIM/NÂO",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes){
            //    Application.Exit();             
            //}
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            new frm_Login().Show();
            this.Hide();
        }
    }
}
