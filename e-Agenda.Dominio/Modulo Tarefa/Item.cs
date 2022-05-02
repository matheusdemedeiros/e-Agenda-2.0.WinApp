using e_Agenda.Dominio.Compartilhado;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Tarefa
{
    public class Item
    {
        #region Atributos

        private Status statusItem;



        #endregion

        #region Construtor

        public Item()
        {

        }

        public Item(string descricao)
        {
            this.Descricao = descricao;
            statusItem = Status.pendente;
        }

        #endregion

        #region Propriedades

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

        #endregion

        #region Métodos públicos
        
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
            return "Descrição: " + Descricao;
        }

        #endregion
    }
}
