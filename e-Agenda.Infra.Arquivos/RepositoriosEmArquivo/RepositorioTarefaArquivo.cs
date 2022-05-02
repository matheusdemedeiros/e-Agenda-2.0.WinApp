using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Tarefa;
using System.Collections.Generic;
using System.Linq;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioTarefaArquivo : RepositorioBaseArquivo<Tarefa>, IRepositorioTarefaEspecifico
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

        public override string Inserir(Tarefa novaEntidade)
        {
            string validacaoDeTarefa = novaEntidade.Validar();

            string validacaoDeDadosIguais = ValidaTarefasComNomesIguais(novaEntidade);

            string retorno = "REGISTRO_VALIDO";

            if (validacaoDeTarefa != "REGISTRO_VALIDO")
                retorno = validacaoDeTarefa;

            if (validacaoDeDadosIguais != "REGISTRO_VALIDO")
                retorno = validacaoDeDadosIguais;

            if (retorno != "REGISTRO_VALIDO")
                return retorno.ToString();

            novaEntidade.id = ++contadorId;

            registros.Add(novaEntidade);

            serializador.GravarEntidadesEmArquivo(registros);

            return "REGISTRO_VALIDO";
        }

        private string ValidaTarefasComNomesIguais(Tarefa tarefa)
        {
            List<Tarefa> tarefas = registros.Cast<Tarefa>().ToList();

            string sb = "REGISTRO_VALIDO";

            foreach (Tarefa t in tarefas)
            {
                if (t.Titulo.ToUpper() == tarefa.Titulo.ToUpper())
                {
                    sb = "Já existe uma tarefa com este título!\n";
                    break;
                }
            }
            return sb.ToString();
        }




    }
}
