using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Compromissso;
using e_Agenda.Dominio.Modulo_Contato;
using e_Agenda.Infra.Arquivos;
using e_Agenda.Infra.Arquivos.RepositoriosEmArquivo;
using e_Agenda.Infra.Arquivos.SerializacaoJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Compromissos
{
    public partial class TelaListagemCompromissos : UserControl
    {
        private IRepositorio<Compromisso> repositorioCompromisso;
        private IRepositorio<Contato> repositorioContatos;
        private ISerializadorEntidade<Contato> serializadorContatos;

        public TelaListagemCompromissos()
        {
            SerializadorEntidadeJson<Compromisso> serializador = new SerializadorEntidadeJson<Compromisso>();

            repositorioCompromisso = new RepositorioCompromissoArquivo(serializador);

            serializadorContatos = new SerializadorEntidadeJson<Contato>();

            repositorioContatos = new RepositorioContatoArquivo(serializadorContatos);

            InitializeComponent();

            CarregarCompromissos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            CadastroCompromissosForm tela = new CadastroCompromissosForm();
            tela.Compromisso = new Compromisso();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioCompromisso.Inserir(tela.Compromisso);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    Contato contatoIncrementar = repositorioContatos.SelecionarRegistro(x => x.id == tela.Compromisso.Contato.id);

                    contatoIncrementar.QuantidadeDeCompromissosRelacionados++;

                    repositorioContatos.Editar(x => x.id == contatoIncrementar.id, contatoIncrementar);

                    MessageBox.Show("Compromisso inserido com sucesso!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCompromissos();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Compromisso? compromissoSelecionado = ObtemCompromissoSelecionado();

            if (compromissoSelecionado == null)
            {
                MessageBox.Show("Selecione um compromisso primeiro",
                "Exclusão de compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Contato contatoInicial = compromissoSelecionado.Contato;

            DialogResult resultado = MessageBox.Show("Deseja mesmo excluir este compromisso?",
                "Exclusão de compromissos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                string conseguiuExcluir = repositorioCompromisso.Excluir(x => x.id == compromissoSelecionado.id);

                if (conseguiuExcluir != "EXCLUSAO_REALIZADA")
                    MessageBox.Show(conseguiuExcluir, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    MessageBox.Show("Compromisso excluído com sucesso", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    Contato contatoDecrementar = repositorioContatos.SelecionarRegistro(x => x.id == contatoInicial.id);

                    contatoDecrementar.QuantidadeDeCompromissosRelacionados--;

                    repositorioContatos.Editar(x => x.id == contatoDecrementar.id, contatoDecrementar);
                    
                    CarregarCompromissos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Compromisso? compromissoSelecionado = ObtemCompromissoSelecionado();

            if (compromissoSelecionado == null)
            {
                MessageBox.Show("Selecione um compromisso primeiro",
                "Edição de compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CadastroCompromissosForm tela = new CadastroCompromissosForm();

            tela.Compromisso = compromissoSelecionado;

            Contato contatoInicial = compromissoSelecionado.Contato;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                string validacao = repositorioCompromisso.Editar(x => x.id == tela.Compromisso.id, tela.Compromisso);

                if (validacao != "REGISTRO_VALIDO")
                    MessageBox.Show(validacao, "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (contatoInicial.id != tela.Compromisso.Contato.id)
                    {
                        Contato contatoDecrementar = repositorioContatos.SelecionarRegistro(x => x.id == contatoInicial.id);
                        
                        contatoDecrementar.QuantidadeDeCompromissosRelacionados--;
                        
                        repositorioContatos.Editar(x => x.id == contatoDecrementar.id, contatoDecrementar);
                        
                        Contato contatoIncrementar = repositorioContatos.SelecionarRegistro(x => x.id == tela.Compromisso.Contato.id);
                        
                        contatoIncrementar.QuantidadeDeCompromissosRelacionados++;
                        
                        repositorioContatos.Editar(x => x.id == contatoIncrementar.id, contatoIncrementar);
                    }

                    MessageBox.Show("Compromisso editado com sucesso", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarCompromissos();
                }
            }
        }

        private void btnVisualizacaoComum_Click(object sender, EventArgs e)
        {
            CarregarCompromissos();
        }

        private void btnCadastrarItens_Click(object sender, EventArgs e)
        {
            //Compromisso compromissoSelecionado = (Compromisso)listCompromissosPendentes.SelectedItem;

            //if (compromissoSelecionado == null)
            //{
            //    MessageBox.Show("Selecione uma tarefa primeiro",
            //    "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //CadastroItensCompromisso tela = new CadastroItensCompromisso(compromissoSelecionado);

            //if (tela.ShowDialog() == DialogResult.OK)
            //{
            //    List<Item> itens = tela.ItensAdicionados;

            //    var repositorio = (IRepositorioCompromissoEspecifico)repositorioCompromisso;

            //    repositorio.AdicionarItens(compromissoSelecionado, itens);

            //    CarregarCompromissos();
            //}
        }

        private void btnAtualizarItens_Click(object sender, EventArgs e)
        {
            //Compromisso? compromissoSelecionado = ObtemCompromissoSelecionado();

            //if (compromissoSelecionado == null)
            //{
            //    MessageBox.Show("Selecione uma tarefa primeiro",
            //    "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //AtualizacaoItensCompromisso tela = new AtualizacaoItensCompromisso(compromissoSelecionado);

            //if (tela.ShowDialog() == DialogResult.OK)
            //{
            //    List<Item> itensConcluidos = tela.ItensConcluidos;

            //    List<Item> itensPendentes = tela.ItensPendentes;

            //    IRepositorioCompromissoEspecifico repositorio = (IRepositorioCompromissoEspecifico)repositorioCompromisso;

            //    repositorio.AtualizarItens(compromissoSelecionado, itensConcluidos, itensPendentes);

            //    CarregarCompromissos();
            //}
        }

        private void btnOrdenarPorPrioridade_Click(object sender, EventArgs e)
        {

        }

        private Compromisso? ObtemCompromissoSelecionado()
        {
            Compromisso? compromissoSelecionado = null;

            if (tabControlCompromissos.SelectedTab == tabPageCompromissosPassados)
                compromissoSelecionado = (Compromisso)listCompromissosPassados.SelectedItem;
            else if (tabControlCompromissos.SelectedTab == tabPageCompromissosFuturos)
                compromissoSelecionado = (Compromisso)listCompromissosFuturos.SelectedItem;
            return compromissoSelecionado;
        }
        
        private void CarregarCompromissos()
        {
            SerializadorEntidadeJson<Compromisso> serializador = new SerializadorEntidadeJson<Compromisso>();

            repositorioCompromisso = new RepositorioCompromissoArquivo(serializador);

            List<Compromisso> compromissosPassados = repositorioCompromisso.Filtrar(x => x.Passou);

            listCompromissosPassados.Items.Clear();

            foreach (Compromisso t in compromissosPassados)
            {
                listCompromissosPassados.Items.Add(t);
            }

            List<Compromisso> compromissosFuturos = repositorioCompromisso.Filtrar(x => !x.Passou);

            listCompromissosFuturos.Items.Clear();

            foreach (Compromisso t in compromissosFuturos)
            {
                listCompromissosFuturos.Items.Add(t);
            }

        }

     
    }
}
