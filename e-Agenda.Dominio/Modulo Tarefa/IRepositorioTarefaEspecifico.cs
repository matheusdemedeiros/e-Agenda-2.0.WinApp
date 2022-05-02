﻿using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Tarefa;
using System.Collections.Generic;

namespace e_Agenda.Dominio.Modulo_Tarefa
{
    public interface IRepositorioTarefaEspecifico
    {
        public void AdicionarItens(Tarefa tarefaSelecionada, List<Item> itens);

        public void AtualizarItens(Tarefa tarefaSelecionada,
            List<Item> itensConcluidos, List<Item> itensPendentes);
    }
}
