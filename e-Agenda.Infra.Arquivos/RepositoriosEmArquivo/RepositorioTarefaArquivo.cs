using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Tarefa;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioTarefaArquivo : RepositorioBaseArquivo<Tarefa>, IRepositorio<Tarefa>
    {
        public RepositorioTarefaArquivo(ISerializadorEntidade<Tarefa> serializador) : base(serializador)
        {
        }
    }
}
