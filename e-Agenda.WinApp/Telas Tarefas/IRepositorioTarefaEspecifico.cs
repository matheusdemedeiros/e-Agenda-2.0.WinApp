using e_Agenda.Dominio.Modulo_Tarefa;
using System.Collections.Generic;

namespace e_Agenda.WinApp.Telas_Tarefas
{
    public interface IRepositorioTarefaEspecifico
    {
        public void AdicionarItens(Tarefa tarefaSelecionada, List<Item> itens);

        public void AtualizarItens(Tarefa tarefaSelecionada,
            List<Item> itensConcluidos, List<Item> itensPendentes);
    }
}
