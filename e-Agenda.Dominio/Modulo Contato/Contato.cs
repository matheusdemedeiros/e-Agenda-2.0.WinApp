using e_Agenda.Dominio.Compartilhado;
using System.Text;

namespace e_Agenda.Dominio.Modulo_Contato
{
    public class Contato : EntidadeBase
    {
        private int quantidadeDeCompromissosRelacionados;

        public string Nome { get; set; }
        
        public string Email { get; set; }
        
        public string Telefone { get; set; }
        
        public string Empresa { get; set; }
        
        public string Cargo { get; set; }
        
        public int QuantidadeDeCompromissosRelacionados { get => quantidadeDeCompromissosRelacionados; set => quantidadeDeCompromissosRelacionados = value; }

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
        
        public Contato(string nome, string email, string telefone)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        public override string Validar()
        {
            StringBuilder sb = new StringBuilder();

            int cont = 0;

            if (string.IsNullOrEmpty(Nome))
                sb.AppendLine(++cont + " - É necessário inserir um nome válido para os contatos!");

            if (!ValidarEmail())
                sb.AppendLine(++cont + " - É necessário inserir um email válido para os contatos (mínimo de 6 caracteres e contendo @ e . )!");

            if (!ValidarTelefone())
                sb.AppendLine(++cont + " - É necessário inserir um telefone válido para os contatos (mínimo 10 números com o DDD)!");

            if (sb.Length == 0)
                sb.Append("REGISTRO_VALIDO");

            return sb.ToString();
        }

        public override string ToString()
        {
            string
                retorno =
              "ID: " + id +
              "\tNome: " + Nome +
              "\tEmail: " + Email +
              "\tTelefone: " + Telefone +
              "\tEmpresa: " + Empresa +
              "\tCargo: " + Cargo;

            return retorno;
        }

        private bool ValidarTelefone()
        {
            bool telefoneEstaValido = false;

            // utilizando o método Replace() para remover caracteres especiais da string
            string telefoneProcessado = Telefone.Replace("-", string.Empty)
                                                .Replace(" ", string.Empty)
                                                .Replace(")", string.Empty)
                                                .Replace("(", string.Empty);

            if (telefoneProcessado.Length < 10)
                return telefoneEstaValido;

            telefoneEstaValido = System.Text.RegularExpressions.Regex.IsMatch(telefoneProcessado, @"^[0-9]*$");

            return telefoneEstaValido;
        }
        
        private bool ValidarEmail()
        {
            // podemos utilizar o valor discard (representado pelo _ (underscore))
            // para descartar argumento out do método
            if (string.IsNullOrEmpty(Email))
                return false;

            bool emailEstaValido = System.Net.Mail.MailAddress.TryCreate(Email, out _);

            return emailEstaValido;
        }
    }
}
