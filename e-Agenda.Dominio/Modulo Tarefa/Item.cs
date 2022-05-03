namespace e_Agenda.Dominio.Modulo_Tarefa
{
    public class Item
    {
        private Status statusItem;

        public Item()
        {

        }

        public Item(string descricao)
        {
            this.Descricao = descricao;
            statusItem = Status.pendente;
        }

        public bool EstaPendente
        {
            get
            {
                return statusItem == Status.pendente ? true : false;
            }
            set
            {
                statusItem = value == true ? Status.pendente : Status.concluido;
            }
        }

        public string Descricao { get; set; }
        
        public void MarcarPendente()
        {
            EstaPendente = true;
        }
        
        public void Concluir()
        {
            if (statusItem == Status.pendente)
                statusItem = Status.concluido;
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
