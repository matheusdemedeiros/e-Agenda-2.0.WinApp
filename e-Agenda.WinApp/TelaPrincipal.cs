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
            TelaListagemCompromissos tela = new TelaListagemCompromissos();
            panelPrincipal.Controls.Add(tela);
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            TelaListagemTarefas tela = new TelaListagemTarefas();
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
