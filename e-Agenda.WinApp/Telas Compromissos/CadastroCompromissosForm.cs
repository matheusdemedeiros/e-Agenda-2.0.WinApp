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
    public partial class CadastroCompromissosForm : Form
    {
        private Compromisso compromisso;
        private IRepositorio<Contato> repositorioContatos;
        private ISerializadorEntidade<Contato> serializador;

        public CadastroCompromissosForm()
        {
            InitializeComponent();
            
            dateTimePickerDataCompromisso.MinDate = DateTime.Now;

            PopularNomesContatosCombobox();

        }

        public Compromisso Compromisso { get => compromisso; set => compromisso = value; }

        private void PopularNomesContatosCombobox()
        {
            serializador = new SerializadorEntidadeJson<Contato>();

            repositorioContatos = new RepositorioContatoArquivo(serializador);

            List<Contato> contatos = repositorioContatos.SelecionarTodos();
            
            if(contatos.Count > 0)
            {
                foreach (Contato item in contatos)
                {
                    comboBoxContato.Items.Add(item.Nome);
                }
            }
        }
    }
}
