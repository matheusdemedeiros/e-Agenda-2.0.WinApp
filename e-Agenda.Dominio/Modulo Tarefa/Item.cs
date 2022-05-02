using e_Agenda.Dominio.Compartilhado;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Tarefa
{
    public class Item : EntidadeBase
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


        public void MarcarPendente()
        {
            EstaPendente = true;
        }

        public string Descricao { get; set; }

        #endregion

        #region Métodos públicos

        public void Concluir()
        {
            if (statusItem == Status.pendente)
                statusItem = Status.concluido;
        }

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Descricao))
                sb.Append("É necessário inserir uma descrição para o item!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        public override string ToString()
        {
            return
                "ID: " + id +
                "\tDescrição: " + Descricao +
                "\tStatus: " + statusItem;
        }
        
        #endregion
    }
}
