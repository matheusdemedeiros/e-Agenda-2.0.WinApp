using e_Agenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;

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

        public override ResultadoValidacao Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("\nÉ necessário inserir um nome válido para os contatos!");

            if (!ValidarEmail())
                erros.Add("\nÉ necessário inserir um email válido para os contatos (mínimo de 6 caracteres e contendo @ e . )!");

            if (!ValidarTelefone())
                erros.Add("\nÉ necessário inserir um telefone válido para os contatos (mínimo 10 números com o DDD)!");

            if (string.IsNullOrEmpty(Empresa))
                erros.Add("\nÉ necessário inserir uma empresa válida para os contatos!");

            if (string.IsNullOrEmpty(Cargo))
                erros.Add("\nÉ necessário inserir um cargo válido para os contatos!");

            return new ResultadoValidacao(erros);
        }

        public override string ToString()
        {
            string retorno =
          "ID: " + id +
          "\tNome: " + Nome +
          "\tEmail:" + Email +
          "\tTelefone: " + Telefone +
          "\tEmpresa: " + Empresa +
          "\tCargo: " + Cargo;

            return retorno;
        }

        #endregion

        #region Métodos privados

        private bool ValidarTelefone()
        {
            if (!string.IsNullOrEmpty(Telefone))
                if (Telefone.Length >= 10)
                    if (long.TryParse(Telefone, out long res))
                        return true;
            return false;
        }

        private bool ValidarEmail()
        {
            if (!string.IsNullOrEmpty(Email))
                if (Email.Length >= 6)
                    if (Email.Contains("@") && Email.Contains("."))
                        return true;
            return false;
        }

        #endregion
    }
}
