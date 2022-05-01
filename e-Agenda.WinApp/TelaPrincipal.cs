using e_Agenda.WinApp.Telas_Compromissos;
using e_Agenda.WinApp.Telas_Contatos;
using e_Agenda.WinApp.Telas_Tarefas;
using System;
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
            TelaListagemContatos tela = new TelaListagemContatos();
            panelPrincipal.Controls.Add(tela);
        }
    }
}
