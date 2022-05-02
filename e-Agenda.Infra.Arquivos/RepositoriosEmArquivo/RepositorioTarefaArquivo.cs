using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Tarefa;
using System.Collections.Generic;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioTarefaArquivo : RepositorioBaseArquivo<Tarefa>, IRepositorio<Tarefa>, IRepositorioTarefaEspecifico
    {
        public RepositorioTarefaArquivo(ISerializadorEntidade<Tarefa> serializador) : base(serializador)
        {
        }

        public void AdicionarItens(Tarefa tarefaSelecionada, List<Item> itens)
        {
            foreach (var item in itens)
            {
                tarefaSelecionada.AdicionarItem(item);
            }

            serializador.GravarEntidadesEmArquivo(registros);
        }

        public void AtualizarItens(Tarefa tarefaSelecionada, List<Item> itensConcluidos, List<Item> itensPendentes)
        {
            foreach (var item in itensConcluidos)
            {
                tarefaSelecionada.ConcluirItem(item);
            }

            foreach (var item in itensPendentes)
            {
                tarefaSelecionada.MarcarPendente(item);
            }

            serializador.GravarEntidadesEmArquivo(registros);
        }
    }
}
