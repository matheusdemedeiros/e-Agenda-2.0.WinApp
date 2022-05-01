
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioContatoArquivo : RepositorioBaseArquivo<Contato>, IRepositorio<Contato>
    {
        public RepositorioContatoArquivo(ISerializadorEntidade<Contato> serializador) : base(serializador)
        {
        }
    }
}
