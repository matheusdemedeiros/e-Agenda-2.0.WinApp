using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Compromissso
{
    public class Compromisso : EntidadeBase
    {
        #region Atributos

        private readonly string assunto;
        private readonly string local;
        private readonly DateTime horaInicio;
        private readonly DateTime horaTermino;
        private readonly Contato contato;

        #endregion

        #region Propriedades

        public bool Passou => DataInicio < DateTime.Now ? true : false;

        public DateTime DataInicio => horaInicio;

        public DateTime HoraInicio => horaTermino;

        #endregion

        #region Construtores
        public Compromisso()
        {

        }
        public Compromisso(string assunto, string local, string horaInicio, string horaTermino, Contato contato)
        {
            this.assunto = assunto;
            this.local = local;
            this.horaInicio = DateTime.TryParse(horaInicio, out DateTime inicio) ? inicio : new DateTime(1, 1, 1);
            this.horaTermino = DateTime.TryParse(horaTermino, out DateTime termino) ? termino : new DateTime(1, 1, 1);
            this.contato = contato;
        }

        public Compromisso(string assunto, string local, DateTime horaInicio, DateTime horaTermino, Contato contato)
        {
            this.assunto = assunto;
            this.local = local;
            this.horaInicio = horaInicio;
            this.horaTermino = horaTermino;
            this.contato = contato;
        }

        #endregion

        #region Método públicos

        public override string ToString()
        {
            string retorno =
                "Assunto: " + assunto +
                "\nLocal: " + local +
                "\nData e o horário de início: " + horaInicio +
                "\nHorário de término: " + horaTermino +
                "\nContato: " + contato.Nome + "\n";
        
            return retorno;
        }

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(assunto))
                sb.AppendLine("É necessário inserir um assunto válido para os compromissos!");

            if (string.IsNullOrEmpty(local))
                sb.AppendLine("É necessário inserir um local válido para os compromissos!");

            if (horaInicio == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir uma data e hora de início válida para os compromissos!");
            
            if (horaTermino == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir um horário de término válido para os compromissos!");
            
            if (contato == null)
                sb.AppendLine("É necessário inserir um contato válido para os compromissos!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        #endregion
    }
}
