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
                repositorioContato.Inserir(tela.Contato);
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
    }
}
