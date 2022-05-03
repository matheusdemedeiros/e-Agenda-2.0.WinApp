using e_Agenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioBaseArquivo<T> where T : EntidadeBase
    {
        protected readonly ISerializadorEntidade<T> serializador;
        protected readonly List<T> registros;
        protected int contadorId;

        public RepositorioBaseArquivo(ISerializadorEntidade<T> serializador)
        {
            this.serializador = serializador;

            registros = serializador.CarregarEntidadesDoArquivo();

            if (registros.Count > 0)
                contadorId = registros.Max(x => x.id);
        }

        public virtual string Inserir(T novaEntidade)
        {
            string validacao = novaEntidade.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao.ToString();

            novaEntidade.id = ++contadorId;

            registros.Add(novaEntidade);

            serializador.GravarEntidadesEmArquivo(registros);

            return "REGISTRO_VALIDO";
        }
        
        public virtual string Editar(Predicate<T> condicao, T novaEntidade)
        {

            string validacao = novaEntidade.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao.ToString();

            foreach (T entidade in registros)
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

        public virtual string Excluir(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);

                    serializador.GravarEntidadesEmArquivo(registros);

                    return "EXCLUSAO_REALIZADA";
                }
            }
            return "EXCLUSAO_NAOREALIZADA";
        }

        public T SelecionarRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public List<T> Filtrar(Predicate<T> condicao)
        {
            List<T> registrosFiltrados = new List<T>();

            foreach (T registro in registros)
                if (condicao(registro))
                    registrosFiltrados.Add(registro);

            return registrosFiltrados;
        }
        
        public bool ExisteRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;
                
            return false;
        }
    }
}
