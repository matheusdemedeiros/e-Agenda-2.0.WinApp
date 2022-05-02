using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Compromissso;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioCompromissoArquivo : RepositorioBaseArquivo<Compromisso>, IRepositorio<Compromisso>
    {
        public RepositorioCompromissoArquivo(ISerializadorEntidade<Compromisso> serializador) : base(serializador)
        {
        }
    }
}
