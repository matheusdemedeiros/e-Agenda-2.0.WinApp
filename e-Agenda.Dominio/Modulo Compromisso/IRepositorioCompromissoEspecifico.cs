using e_Agenda.Dominio.Modulo_Compromissso;
using System.Collections.Generic;

namespace e_Agenda.Dominio.Modulo_Compromisso
{
    public interface IRepositorioCompromissoEspecifico
    {
        List<Compromisso> SelecionarCompromissosSemanais();
    }
}
