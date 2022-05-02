
using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Contato;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioContatoArquivo : RepositorioBaseArquivo<Contato>, IRepositorio<Contato>
    {
        public RepositorioContatoArquivo(ISerializadorEntidade<Contato> serializador) : base(serializador)
        {
        }

        public override string Inserir(Contato novaEntidade)
        {
            string validacaoDeContato = novaEntidade.Validar();

            string validacaoDeDadosIguais = ValidaContatosComDadosIguais(novaEntidade);

            string retorno = "REGISTRO_VALIDO";

            if (validacaoDeContato != "REGISTRO_VALIDO")
                retorno = validacaoDeContato;

            if (validacaoDeDadosIguais != "REGISTRO_VALIDO")
                retorno = validacaoDeDadosIguais;

            if(retorno != "REGISTRO_VALIDO")
                return retorno.ToString();

            novaEntidade.id = ++contadorId;

            registros.Add(novaEntidade);

            serializador.GravarEntidadesEmArquivo(registros);

            return "REGISTRO_VALIDO";
        }

        private string ValidaContatosComDadosIguais(Contato contato)
        {
            List<Contato> contatos = registros.Cast<Contato>().ToList();

            string sb = "REGISTRO_VALIDO";

            foreach (Contato c in contatos)
            {
                if (c.Nome.ToUpper() == contato.Nome.ToUpper())
                {
                    if (c.Telefone == contato.Telefone && c.Email == contato.Email)
                    {
                        sb = "";
                        sb = "Já existe um contato com este nome, email e telefone!\n";
                        sb += "Para cadastrar contatos de nomes iguais, tanto o telefone como o email devem ser diferentes!";
                        break;
                    }
                }
            }
            return sb.ToString();
        }
    }
}
