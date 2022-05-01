using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void btnCompromisso_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            TelaCompromissos tela = new TelaCompromissos();
            panelPrincipal.Controls.Add(tela);
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            TelaTarefas tela = new TelaTarefas();
            panelPrincipal.Controls.Add(tela);
        }

        private void btnContatos_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            TelaContatos tela = new TelaContatos();
            panelPrincipal.Controls.Add(tela);
        }
    }
}
