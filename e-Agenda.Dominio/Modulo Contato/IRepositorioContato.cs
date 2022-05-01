using e_Agenda.Dominio.Compartilhado;
using System.Collections.Generic;

namespace e_Agenda.Dominio.Modulo_Contato
{
    public interface IRepositorioContato
    {
        void Editar(Contato contato);
        void Excluir(Contato contato);
        void Inserir(Contato novoContato);
        List<Contato> SelecionarTodos();

        //List<Contato> SelecionarContatosAgrupadosPorCargo();
    }
}
