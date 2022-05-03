using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;
using e_Agenda.Infra.Arquivos.RepositoriosEmArquivo;
using e_Agenda.Infra.Arquivos.SerializacaoJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Contatos
{
    public partial class TelaListagemContatos : UserControl
    {
        private IRepositorio<Contato> repositorioContato;

        public TelaListagemContatos()
        {
            SerializadorEntidadeJson<Contato> serializador = new SerializadorEntidadeJson<Contato>();

            repositorioContato = new RepositorioContatoArquivo(serializador);

            InitializeComponent();

            CarregarContatos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            CadastroContatosForm tela = new CadastroContatosForm();
            
            tela.Contato = new Contato();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioContato.Inserir(tela.Contato);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Contato inserido com sucesso!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarContatos();
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Contato contatoSelecionado = (Contato)listaContatos.SelectedItem;

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Edição de contatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CadastroContatosForm tela = new CadastroContatosForm();

            tela.Contato = contatoSelecionado;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioContato.Editar(x => x.id == tela.Contato.id, tela.Contato);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Contato editado com sucesso", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarContatos();
                }
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Contato contatoSelecionado = (Contato)listaContatos.SelectedItem;

            if (contatoSelecionado == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Exclusão de contatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o contato?",
               "Exclusão de contatos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                string conseguiuExcluir = repositorioContato.Excluir(x => x.id == contatoSelecionado.id);

                if (conseguiuExcluir == "EXCLUSAO_REALIZADA")
                    MessageBox.Show("Contato excluído com sucesso", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(conseguiuExcluir, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                {

                    CarregarContatos();
                }
            }

        }

        private void btnVisualizacaoComum_Click(object sender, EventArgs e)
        {
            CarregarContatos();
        }
        
        private void btnVisualizarPorCargo_Click(object sender, EventArgs e)
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
                return;

            List<string> cargosExistentes = ObterCargos(contatos);

            listaContatos.Items.Clear();

            foreach (string cargo in cargosExistentes)
            {
                listaContatos.Items.Add("Agrupando pelo cargo: " + cargo);

                foreach (Contato contato in contatos)
                    if (contato.Cargo == cargo)
                        listaContatos.Items.Add(contato);

            }
        }

        private List<string> ObterCargos(List<Contato> contatos)
        {
            List<string> cargosCadastrados = new List<string>();

            foreach (Contato contato in contatos)
            {
                cargosCadastrados.Add(contato.Cargo);
            }

            return cargosCadastrados.Distinct().ToList();
        }

        private void CarregarContatos()
        {
            List<Contato> contatos = repositorioContato.SelecionarTodos();

            listaContatos.Items.Clear();

            foreach (Contato c in contatos)
            {
                listaContatos.Items.Add(c);
            }

        }
    }
}
