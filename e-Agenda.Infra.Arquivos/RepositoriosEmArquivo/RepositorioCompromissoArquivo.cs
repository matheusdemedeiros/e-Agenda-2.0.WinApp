using e_Agenda.Dominio.Compartilhado;
using e_Agenda.Dominio.Modulo_Compromisso;
using e_Agenda.Dominio.Modulo_Compromissso;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioCompromissoArquivo : RepositorioBaseArquivo<Compromisso>, IRepositorio<Compromisso>, IRepositorioCompromissoEspecifico
    {
        public RepositorioCompromissoArquivo(ISerializadorEntidade<Compromisso> serializador) : base(serializador)
        {
        }

        public override string Inserir(Compromisso novaEntidade)
        {
            string validacao = novaEntidade.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao.ToString();

            novaEntidade.id = ++contadorId;

            novaEntidade.Contato.QuantidadeDeCompromissosRelacionados += 1;

            registros.Add(novaEntidade);

            serializador.GravarEntidadesEmArquivo(registros);

            return "REGISTRO_VALIDO";
        }
        public override string Excluir(Predicate<Compromisso> condicao)
        {
            List<Compromisso> compromissos = registros.Cast<Compromisso>().ToList();

            foreach (Compromisso entidade in registros)
            {
                if (condicao(entidade))
                {
                    //entidade.Contato.QuantidadeDeCompromissosRelacionados -= 1;

                    compromissos.Remove(entidade);

                    serializador.GravarEntidadesEmArquivo(compromissos);

                    return "EXCLUSAO_REALIZADA";
                }
            }
            return "EXCLUSAO_NAOREALIZADA";
        }
        public override string Editar(Predicate<Compromisso> condicao, Compromisso novaEntidade)
        {

            string validacao = novaEntidade.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao.ToString();

            foreach (Compromisso entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEntidade.id = entidade.id;

                    int posicaoParaEditar = registros.IndexOf(entidade);

                    registros[posicaoParaEditar] = novaEntidade;

                    serializador.GravarEntidadesEmArquivo(registros);

                    return "REGISTRO_VALIDO";
                }
            }

            return "REGISTRO_INVALIDO";
        }

        public List<Compromisso> SelecionarCompromissosSemanais()
        {
            int hoje = (int)DateTime.Today.DayOfWeek;

            int diferencaParaSabado = 6 - hoje;

            DateTime dataFinal = DateTime.Today.AddDays(diferencaParaSabado);

            dataFinal.AddHours(23);

            dataFinal.AddMinutes(59);

            return registros.FindAll(x => x.DataInicio >= DateTime.Today
            && x.DataInicio <= dataFinal && x.Passou == false);
        }

    }
}
