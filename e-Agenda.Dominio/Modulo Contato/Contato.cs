﻿using e_Agenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Contato
{
    [Serializable]
    public class Contato : EntidadeBase
    {
        #region Propriedades

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        #endregion

        #region Construtores

        public Contato()
        {

        }
        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Empresa = empresa;
            this.Cargo = cargo;
        }

        #endregion

        #region Métodos públicos

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(Nome))
            sb.AppendLine("É necessário inserir um nome válido para os contatos!");

            if (!ValidarEmail())
                sb.AppendLine("É necessário inserir um email válido para os contatos (mínimo de 6 caracteres e contendo @ e . )!");

            if (!ValidarTelefone())
                sb.AppendLine("É necessário inserir um telefone válido para os contatos (mínimo 10 números com o DDD)!");

            if (string.IsNullOrEmpty(Empresa))
                sb.AppendLine("É necessário inserir uma empresa válida para os contatos!");

            if (string.IsNullOrEmpty(Cargo))
                sb.AppendLine("É necessário inserir um cargo válido para os contatos!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        public override string ToString()
        {
            string retorno =
          "ID: " + id +
          "\tNome: " + Nome +
          "\tEmail: " + Email +
          "\tTelefone: " + Telefone +
          "\tEmpresa: " + Empresa +
          "\tCargo: " + Cargo;

            return retorno;
        }

        #endregion

        #region Métodos privados

        //private bool ValidarTelefone()
        //{
        //    if (!string.IsNullOrEmpty(Telefone))
        //        if (Telefone.Length >= 10)
        //            if (long.TryParse(Telefone, out long res))
        //                return true;
        //    return false;
        //}


        private bool ValidarTelefone()
        {
            bool telefoneEstaValido = false;

            // utilizando o método Replace() para remover caracteres especiais da string
            string telefoneProcessado = Telefone.Replace("-", string.Empty)
                                                .Replace(" ", string.Empty)
                                                .Replace(")", string.Empty)
                                                .Replace("(", string.Empty);

            if (telefoneProcessado.Length  < 10)
                return telefoneEstaValido;

            telefoneEstaValido = System.Text.RegularExpressions.Regex.IsMatch(telefoneProcessado, @"^[0-9]*$");

            return telefoneEstaValido;
        }


        private bool ValidarEmail()
        {
            // podemos utilizar o valor discard (representado pelo _ (underscore))
            // para descartar argumento out do método
            bool emailEstaValido = System.Net.Mail.MailAddress.TryCreate(Email, out _);

            return emailEstaValido;
        }

        #endregion
    }
}
