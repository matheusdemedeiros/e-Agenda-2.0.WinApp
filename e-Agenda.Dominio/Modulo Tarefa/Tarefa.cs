﻿using e_Agenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Tarefa
{
    [Serializable]
    public class Tarefa : EntidadeBase, IComparable<Tarefa>
    {
        #region Atributos

        private int prioridade;
        private Status statusTarefa;
        public List<Item> itens = new List<Item>();

        #endregion

        #region Propriedades

        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public List<Item> Itens { get { return itens; } }
        public Status StatusTarefa { get => statusTarefa; }
        public string PrioridadeTarefa
        {
            get
            {
                string retorno = "";
                if (prioridade == 1)
                    retorno = "Baixa";
                else if (prioridade == 2)
                    retorno = "Normal";
                else if (prioridade == 3)
                    retorno = "Alta";

                return retorno;
            }

            set
            {
                if (value == "Baixa")
                    prioridade = 1;
                else if (value == "Normal")
                    prioridade = 2;
                else if (value == "Alta")
                    prioridade = 3;
            }
        }

        #endregion

        public Tarefa()
        {
            DataCriacao = DateTime.Now;
        }

        public Tarefa(int id, string descricao, string prioridade) : this()
        {
            base.id = id;
            Descricao = descricao;
            DataConclusao = null;
            PrioridadeTarefa = prioridade;
        }

        public void ConcluirItem(Item item)
        {
            Item itemTarefa = itens.Find(x => x.Equals(item));

            itemTarefa?.Concluir();

            var percentual = CalcularPercentualConcluido();

            if (percentual == 100)
                DataConclusao = DateTime.Now;
        }

        public void AdicionarItem(Item item)
        {
            if (Itens.Exists(x => x.Equals(item)) == false)
                itens.Add(item);
        }

        public void MarcarPendente(Item item)
        {
            Item itemTarefa = itens.Find(x => x.Equals(item));

            itemTarefa?.MarcarPendente();
        }

        public decimal CalcularPercentualConcluido()
        {
            if (itens.Count == 0)
                return 0;

            int qtdConcluidas = itens.Count(x => !x.EstaPendente);

            var percentualConcluido = (qtdConcluidas / (decimal)itens.Count()) * 100;

            return Math.Round(percentualConcluido, 2);
        }

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Descricao))
                sb.AppendLine("É necessário inserir um título para as tarefas!");

            if (DataCriacao.Date == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir uma data de criação válida para as tarefas!");

            if (prioridade == 0)
                sb.AppendLine("É necessário inserir uma prioridade válida (Alta, Normal ou Baixa) para as tarefas!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        public override string ToString()
        {
            return
            "ID: " + id +
            "\tDescrição: " + Descricao +
            "\tData de criação: " + DataCriacao.ToShortDateString() +
            "\tData de conclusão: " + DataConclusao == null ? "Indeterminado" : DataConclusao +
            "\tPrioridade: " + PrioridadeTarefa +
            "\tPercentual de conclusao: " + CalcularPercentualConcluido();
        }

        public int CompareTo(Tarefa other)
        {
            if (prioridade < other.prioridade)
                return 1;
            else if (prioridade > other.prioridade)
                return -1;
            else
                return 0;
        }

    }
}
