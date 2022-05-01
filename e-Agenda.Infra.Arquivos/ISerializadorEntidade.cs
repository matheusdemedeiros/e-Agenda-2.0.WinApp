using e_Agenda.Dominio.Compartilhado;
using System.Collections.Generic;

namespace e_Agenda.Infra.Arquivos
{
    public interface ISerializadorEntidade<T> where T : EntidadeBase
    {
        List<T> CarregarEntidadesDoArquivo();
        void GravarEntidadesEmArquivo(List<T> entidades);
        
    }
}
