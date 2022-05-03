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

            Inicializar();
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

        private void btnFiltrarPeriodo_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDataInicioPeriodo.Value > dateTimePickerDataFimPeriodo.Value)
            {
                MessageBox.Show("A data inicial deve ser menor que a data final!",
                "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dateTimePickerHoraInicioPeriodo.Value > dateTimePickerHoraFimPeriodo.Value)
            {
                MessageBox.Show("O horário inicial deve ser menor que o horário final!",
                "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime inicioFiltro = IniciarDateTimeFiltro(dateTimePickerDataInicioPeriodo, dateTimePickerHoraInicioPeriodo);

            DateTime fimFiltro = IniciarDateTimeFiltro(dateTimePickerDataFimPeriodo, dateTimePickerHoraFimPeriodo);

            CarregarCompromissos(FiltrarCompromissos(inicioFiltro, fimFiltro));
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            Inicializar();

            CarregarCompromissos();
        }

        private void tabControlCompromissos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlCompromissos.SelectedIndex == 0)
            {
                btnFiltrarPeriodo.Enabled = true;
                btnLimparFiltro.Enabled = true;
                btnCompromissosSemana.Enabled = true;
                btnCompromissosDia.Enabled = true;
            }
            else if (tabControlCompromissos.SelectedIndex == 1)
            {
                btnFiltrarPeriodo.Enabled = false;
                btnLimparFiltro.Enabled = false;
                btnCompromissosSemana.Enabled = false;
                btnCompromissosDia.Enabled = false;

            }
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

            foreach (Compromisso c in compromissosPassados)
            {
                listCompromissosPassados.Items.Add(c);
            }

            List<Compromisso> compromissosFuturos = repositorioCompromisso.Filtrar(x => !x.Passou);

            listCompromissosFuturos.Items.Clear();

            foreach (Compromisso c in compromissosFuturos)
            {
                listCompromissosFuturos.Items.Add(c);
            }

        }

        private void CarregarCompromissos(List<Compromisso> compromissos)
        {
            listCompromissosFuturos.Items.Clear();

            foreach (Compromisso c in compromissos)
            {
                listCompromissosFuturos.Items.Add(c);
            }
        }

        private void Inicializar()
        {
            dateTimePickerDataInicioPeriodo.MinDate = DateTime.Today;
            dateTimePickerDataFimPeriodo.MinDate = DateTime.Today;
            dateTimePickerDataInicioPeriodo.Value = DateTime.Today;
            dateTimePickerDataFimPeriodo.Value = DateTime.Today;
            dateTimePickerHoraInicioPeriodo.Text = "12:00";
            dateTimePickerHoraFimPeriodo.Text = "12:00";
        }

        private List<Compromisso> FiltrarCompromissos(DateTime inicioFiltro, DateTime fimFiltro)
        {
            //return repositorioCompromisso.SelecionarTodos().FindAll(x => x.DataInicialCompleta >= inicioFiltro && x.DataInicialCompleta <= fimFiltro);
            return repositorioCompromisso.Filtrar(x => x.DataInicialCompleta >= inicioFiltro && x.DataInicialCompleta <= fimFiltro && x.Passou == false).ToList();
        }

        private DateTime IniciarDateTimeFiltro(DateTimePicker data, DateTimePicker hora)
        {
            int dia, mes, ano, minutos, horas;
            dia = data.Value.Day;
            mes = data.Value.Month;
            ano = data.Value.Year;
            horas = hora.Value.Hour;
            minutos = hora.Value.Minute;
            return new DateTime(ano, mes, dia, horas, minutos, 0);

        }

        private void btnCompromissosDia_Click(object sender, EventArgs e)
        {
            DateTime inicioFiltro = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);

            DateTime fimFiltro = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);

            CarregarCompromissos(FiltrarCompromissos(inicioFiltro, fimFiltro));
        }
    }
}
