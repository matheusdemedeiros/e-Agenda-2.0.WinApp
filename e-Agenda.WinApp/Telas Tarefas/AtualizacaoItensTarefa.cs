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
    public partial class AtualizacaoItensTarefa : Form
    {
        private readonly Tarefa tarefa;

        public AtualizacaoItensTarefa(Tarefa tarefa)
        {
            InitializeComponent();
            this.tarefa = tarefa;

            labelTituloTarefa.Text = tarefa.Descricao;

            CarregarItensTarefa(tarefa);
        }

        private void CarregarItensTarefa(Tarefa tarefa)
        {
            foreach (var item in tarefa.itens)
                listItensTarefa.Items.Add(item);
            
            int i = 0; 
            foreach (var item in tarefa.Itens)
            {
                listItensTarefa.Items.Add(item);

                if (!item.EstaPendente)
                    listItensTarefa.SetItemChecked(i, true);

                i++;
            }

        }

        public List<Item> ItensConcluidos
        {
            get
            {
                return listItensTarefa.CheckedItems
                    .Cast<Item>()
                    .ToList();
            }
        }

        public List<Item> ItensPendentes
        {
            get
            {
                return listItensTarefa.Items
                    .Cast<Item>()
                    .Except(ItensConcluidos)
                    .ToList();
            }
        }
    }
}
