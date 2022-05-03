using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Compromissso;
using e_Agenda.Dominio.Modulo_Contato;
using e_Agenda.Infra.Arquivos;
using e_Agenda.Infra.Arquivos.RepositoriosEmArquivo;
using e_Agenda.Infra.Arquivos.SerializacaoJson;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Compromissos
{
    public partial class CadastroCompromissosForm : Form
    {
        private Compromisso compromisso;
        private IRepositorio<Contato> repositorioContatos;
        private ISerializadorEntidade<Contato> serializador;

        public CadastroCompromissosForm()
        {
            InitializeComponent();

            Inicializar();
        }

        public Compromisso Compromisso
        {
            get => compromisso;
            set
            {
                compromisso = value;
                txtAssunto.Text = compromisso.Assunto;
                txtLocal.Text = compromisso.Local;
                dateTimePickerDataCompromisso.Value = compromisso.DataInicio == new DateTime(1, 1, 1) ? DateTime.Today : compromisso.DataInicio;
                dateTimePickerHoraInicio.Value = compromisso.HoraInicio == new DateTime(1, 1, 1) ? DateTime.Now : compromisso.HoraInicio; ;
                dateTimePickerHoraTermino.Value = compromisso.HoraTermino == new DateTime(1, 1, 1) ? DateTime.Now : compromisso.HoraTermino; ;
                comboBoxContato.SelectedItem = compromisso.Contato;

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dateTimePickerDataCompromisso.Value = DateTime.Now;

            comboBoxContato.SelectedIndex = -1;

            txtAssunto.Clear();

            txtLocal.Clear();

            PopularCamposDeHorario();

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Compromisso.Assunto = txtAssunto.Text;
            Compromisso.Local = txtLocal.Text;
            Compromisso.DataInicio = dateTimePickerDataCompromisso.Value;
            Compromisso.HoraInicio = dateTimePickerHoraInicio.Value;
            Compromisso.HoraTermino = dateTimePickerHoraTermino.Value;
            Compromisso.Contato = (Contato)comboBoxContato.SelectedItem;

        }

        private void PopularNomesContatosCombobox()
        {
            serializador = new SerializadorEntidadeJson<Contato>();

            repositorioContatos = new RepositorioContatoArquivo(serializador);

            List<Contato> contatos = repositorioContatos.SelecionarTodos();

            if (contatos.Count > 0)
            {
                foreach (Contato item in contatos)
                {
                    comboBoxContato.Items.Add(item);
                }
            }
        }

        private void PopularCamposDeHorario()
        {
            dateTimePickerHoraInicio.Value = DateTime.Now;
            dateTimePickerHoraTermino.Value = DateTime.Now;
        }

        private void Inicializar()
        {
            dateTimePickerDataCompromisso.MinDate = DateTime.Today;

            PopularNomesContatosCombobox();

            PopularCamposDeHorario();
        }
    }
}
