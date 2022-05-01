using e_Agenda.Dominio.Compartilhado;
using System.Collections.Generic;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Tarefa
{
    public class Item : EntidadeBase
    {
        #region Atributos

        private readonly string descricao;
        private Status statusItem;

        #endregion

        #region Construtor

        public Item(string descricao)
        {
            this.descricao = descricao;
            statusItem = Status.pendente;
        }

        #endregion

        #region Propriedades

        public bool EstaPendente => statusItem == Status.pendente ? true : false;

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

            if (string.IsNullOrEmpty(descricao))
                sb.Append("É necessário inserir uma descrição para o item!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        public override string ToString()
        {
            return
                "\nID: " + id +
                "\nDescrição: " + descricao +
                "\nStatus: " + statusItem;
        }
        
        #endregion
    }
}
