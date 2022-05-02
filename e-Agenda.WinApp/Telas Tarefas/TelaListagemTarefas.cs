using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Tarefa;
using e_Agenda.Infra.Arquivos.RepositoriosEmArquivo;
using e_Agenda.Infra.Arquivos.SerializacaoJson;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Tarefas
{
    public partial class TelaListagemTarefas : UserControl
    {

        IRepositorio<Tarefa> repositorioTarefa;

        public TelaListagemTarefas()
        {
            SerializadorEntidadeJson<Tarefa> serializador = new SerializadorEntidadeJson<Tarefa>();

            repositorioTarefa = new RepositorioTarefaArquivo(serializador);

            InitializeComponent();

            CarregarTarefas();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            CadastroTarefasForm tela = new CadastroTarefasForm();
            tela.Tarefa = new Tarefa();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioTarefa.Inserir(tela.Tarefa);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    CarregarTarefas();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CadastroTarefasForm tela = new CadastroTarefasForm();

            tela.Tarefa = tarefaSelecionada;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioTarefa.Editar(x => x.id == tela.Tarefa.id, tela.Tarefa);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Tarefa editada com sucesso", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarTarefas();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a tarefa?",
                "Exclusão de Tarefas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTarefa.Excluir(x => x == tarefaSelecionada);
                CarregarTarefas();
            }
        }

        private void btnVisualizarPorCargo_Click(object sender, EventArgs e)
        {

        }

        private void btnVisualizacaoComum_Click(object sender, EventArgs e)
        {

        }

        private void CarregarTarefas()
        {
            List<Tarefa> tarefasConcluidas = repositorioTarefa.Filtrar(x => x.StatusTarefa == Status.concluido);

            listTarefasConcluidas.Items.Clear();

            foreach (Tarefa t in tarefasConcluidas)
            {
                listTarefasConcluidas.Items.Add(t);
            }

            List<Tarefa> tarefasPendentes = repositorioTarefa.Filtrar(x => x.StatusTarefa == Status.pendente);

            listTarefasPendentes.Items.Clear();

            foreach (Tarefa t in tarefasPendentes)
            {
                listTarefasPendentes.Items.Add(t);
            }

        }
    }
}
