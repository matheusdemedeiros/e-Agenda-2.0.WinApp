﻿using e_Agenda.Dominio.Modulo_Tarefa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace e_Agenda.WinApp.Telas_Tarefas
{
    public partial class CadastroItensTarefa : Form
    {
        private readonly Tarefa tarefa;

        public CadastroItensTarefa(Tarefa tarefa)
        {
            InitializeComponent();

            this.tarefa = tarefa;

            labelTituloTarefa.Text = tarefa.Descricao;

            foreach (Item item in tarefa.Itens)
            {
                listItensTarefa.Items.Add(item);
            }

        }

        public List<Item> ItensAdicionados 
        {
            get 
            {
                return listItensTarefa.Items.Cast<Item>().ToList();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {            
            List<string> descricoes = ItensAdicionados.Select(x => x.Descricao).ToList();

            if (descricoes.Count == 0 || descricoes.Contains(txtDescricaoItem.Text) == false)
            {
                Item item = new Item();

                item.Descricao = txtDescricaoItem.Text;

                listItensTarefa.Items.Add(item);
            }
        }
       
    }
}