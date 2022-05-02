using e_Agenda.Dominio.Modulo_Tarefa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Tarefas
{
    public partial class CadastroTarefasForm : Form
    {
        private Tarefa tarefa;

        public CadastroTarefasForm()
        {
            InitializeComponent();
            txtDataCriacao.Text = DateTime.Now.ToString();
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
            }
        }      

        private void btnGravar_Click(object sender, EventArgs e)
        {
            //string tituloTarefa, string dataCriacao, int prioridade
            tarefa = new Tarefa();
            tarefa.Titulo = txtTitulo.Text;
            tarefa.DataCriacao = DateTime.Parse(txtDataCriacao.Text);
            tarefa.PrioridadeTarefa = comboBoxPrioridade.Text;
        }

    }
}
