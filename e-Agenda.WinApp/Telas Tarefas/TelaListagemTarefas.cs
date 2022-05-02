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
            Tarefa? tarefaSelecionada = ObtemTarefaSelecionada();

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
            Tarefa? tarefaSelecionada = ObtemTarefaSelecionada();

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
                string conseguiuExcluir = repositorioTarefa.Excluir(x => x.id == tarefaSelecionada.id);

                if (conseguiuExcluir == "EXCLUSAO_REALIZADA")
                {
                    MessageBox.Show("Tarefa excluída com sucesso!",
               "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(conseguiuExcluir,
                                   "Exclusão de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarregarTarefas();
            }
        }

        private Tarefa? ObtemTarefaSelecionada()
        {
            Tarefa? tarefaSelecionada = null;
            
            if (tabControlTarefas.SelectedTab == tabPageTarefasPendentes)
                tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;
            else if (tabControlTarefas.SelectedTab == tabPageTarefasConcluidas)
                tarefaSelecionada = (Tarefa)listTarefasConcluidas.SelectedItem;
            return tarefaSelecionada;
        }

        private void btnVisualizacaoComum_Click(object sender, EventArgs e)
        {
            CarregarTarefas();
        }

        private void btnCadastrarItens_Click(object sender, EventArgs e)
        {
            Tarefa tarefaSelecionada = (Tarefa)listTarefasPendentes.SelectedItem;

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CadastroItensTarefa tela = new CadastroItensTarefa(tarefaSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<Item> itens = tela.ItensAdicionados;

                var repositorio = (IRepositorioTarefaEspecifico)repositorioTarefa;

                repositorio.AdicionarItens(tarefaSelecionada, itens);

                CarregarTarefas();
            }
        }

        private void btnAtualizarItens_Click(object sender, EventArgs e)
        {
            Tarefa? tarefaSelecionada = ObtemTarefaSelecionada();

            if (tarefaSelecionada == null)
            {
                MessageBox.Show("Selecione uma tarefa primeiro",
                "Edição de Tarefas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AtualizacaoItensTarefa tela = new AtualizacaoItensTarefa(tarefaSelecionada);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                List<Item> itensConcluidos = tela.ItensConcluidos;

                List<Item> itensPendentes = tela.ItensPendentes;

                IRepositorioTarefaEspecifico repositorio = (IRepositorioTarefaEspecifico)repositorioTarefa;

                repositorio.AtualizarItens(tarefaSelecionada, itensConcluidos, itensPendentes);

                CarregarTarefas();
            }
        }

        private void btnOrdenarPorPrioridade_Click(object sender, EventArgs e)
        {
            CarregarTarefasOrdenadasPorPrioridade();
        }

        private void CarregarTarefas()
        {
            SerializadorEntidadeJson<Tarefa> serializador = new SerializadorEntidadeJson<Tarefa>();

            repositorioTarefa = new RepositorioTarefaArquivo(serializador);

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

        private void CarregarTarefasOrdenadasPorPrioridade()
        {
            List<Tarefa> tarefasConcluidas = repositorioTarefa.Filtrar(x => x.StatusTarefa == Status.concluido);

            tarefasConcluidas.Sort();

            listTarefasConcluidas.Items.Clear();

            foreach (Tarefa t in tarefasConcluidas)
            {
                listTarefasConcluidas.Items.Add(t);
            }

            List<Tarefa> tarefasPendentes = repositorioTarefa.Filtrar(x => x.StatusTarefa == Status.pendente);

            tarefasPendentes.Sort();

            listTarefasPendentes.Items.Clear();

            foreach (Tarefa t in tarefasPendentes)
            {
                listTarefasPendentes.Items.Add(t);
            }

        }

    }
}
