using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;
using e_Agenda.Infra.Arquivos.RepositoriosEmArquivo;
using e_Agenda.Infra.Arquivos.SerializacaoJson;
using System;
using System.Collections.Generic;
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
                    CarregarContatos();
            }

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
                    CarregarContatos();
            }

        }
    }
}
