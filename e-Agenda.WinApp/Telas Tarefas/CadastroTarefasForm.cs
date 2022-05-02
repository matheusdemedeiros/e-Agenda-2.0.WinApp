using e_Agenda.Dominio.Modulo_Tarefa;
using System;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Tarefas
{
    public partial class CadastroTarefasForm : Form
    {
        private Tarefa tarefa;

        public CadastroTarefasForm()
        {
            InitializeComponent();
            //PreencherCampoDataCriacao();
            comboBoxPrioridade.SelectedIndex = 0;
        }

        public Tarefa Tarefa
        {
            get
            {
                return tarefa;
            }
            set
            {
                tarefa = value;
                txtId.Text = tarefa.id.ToString();
                txtTitulo.Text = tarefa.Titulo;
                comboBoxPrioridade.Text = tarefa.PrioridadeTarefa;
                txtDataCriacao.Text = tarefa.DataCriacao.ToString();
                PreencherCampoDataCriacao();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            tarefa.Titulo = txtTitulo.Text;
            tarefa.DataCriacao = DateTime.Parse(txtDataCriacao.Text);
            tarefa.PrioridadeTarefa = comboBoxPrioridade.Text;
        }

        private void PreencherCampoDataCriacao()
        {
            if (tarefa.DataCriacao == new DateTime(1, 1, 1))
                txtDataCriacao.Text = DateTime.Now.ToString();
            else
                txtDataCriacao.Text = Tarefa.DataCriacao.ToString();
        }
    }
}
