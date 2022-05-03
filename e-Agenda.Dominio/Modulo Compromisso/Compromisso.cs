using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Compromissso
{
    public class Compromisso : EntidadeBase
    {

        #region Propriedades

        public bool Passou => DataInicio < DateTime.Now && HoraInicio < DateTime.Now ? true : false;
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public Contato Contato { get; set; }

        #endregion

        #region Construtores
        public Compromisso()
        {

        }

        public Compromisso(string assunto, string local,
            DateTime dataInicio, DateTime horaInicio,
            DateTime horaTermino, Contato contato)
        {
            Assunto = assunto;
            Local = local;
            DataInicio = dataInicio;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Contato = contato;
        }

        #endregion

        #region Método públicos

        public override string ToString()
        {
            string retorno =
                "Assunto: " + Assunto +
                "\tLocal: " + Local +
                "\tData: " + DataInicio.ToShortDateString() +
                "\tHorário de início: " + HoraInicio.ToShortTimeString() +
                "\tHorário de término: " + HoraTermino.ToShortTimeString() +
                "\tContato: " + Contato.Nome + "\n";

            return retorno;
        }

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Assunto))
                sb.AppendLine("É necessário inserir um assunto válido para os compromissos!");

            if (string.IsNullOrEmpty(Local))
                sb.AppendLine("É necessário inserir um local válido para os compromissos!");

            if (DataInicio == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir uma data de início válida para os compromissos!");

            if (HoraInicio == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir um horário de início válido para os compromissos!");

            if (HoraTermino == new DateTime(1, 1, 1))
                sb.AppendLine("É necessário inserir um horário de término válido para os compromissos!");
            
            if (VerificaHoraInicioMenorHoraTermino() == false)
                sb.AppendLine("O horário de início deve ser menor do que o horário de término!");

            if (Contato == null)
                sb.AppendLine("É necessário inserir um contato válido para os compromissos!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        private bool VerificaHoraInicioMenorHoraTermino()
        {
            if (HoraInicio < HoraTermino)
                return true;
            else
                return false;
        }



        #endregion
    }
}
