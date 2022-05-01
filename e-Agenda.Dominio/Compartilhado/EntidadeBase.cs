namespace e_Agenda.Dominio.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int id;

        public abstract ResultadoValidacao Validar();
    }
}
