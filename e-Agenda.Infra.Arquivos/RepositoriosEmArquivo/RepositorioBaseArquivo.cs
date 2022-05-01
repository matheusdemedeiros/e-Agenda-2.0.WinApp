using e_Agenda.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_Agenda.Infra.Arquivos.RepositoriosEmArquivo
{
    public class RepositorioBaseArquivo<T> where T : EntidadeBase
    {
        #region Atributos

        protected readonly ISerializadorEntidade<T> serializador;

        protected readonly List<T> registros;

        protected int contadorId;

        #endregion

        #region Construtor

        public RepositorioBaseArquivo(ISerializadorEntidade<T> serializador)
        {
            this.serializador = serializador;

            registros = serializador.CarregarEntidadesDoArquivo();

            if (registros.Count > 0)
                contadorId = registros.Max(x => x.id);
        }

        #endregion

        #region Métodos públicos

        public virtual string Inserir(T novaEntidade)
        {
            ResultadoValidacao validacao = novaEntidade.Validar();

            if (validacao.Status == StatusValidacao.Erro)
                return validacao.ToString();

            novaEntidade.id = ++contadorId;

            registros.Add(novaEntidade);

            serializador.GravarEntidadesEmArquivo(registros);

            return "REGISTRO_VALIDO";
        }

        public bool Editar(int idSelecionado, T novaEntidade)
        {
            return Editar(x => x.id == idSelecionado, novaEntidade);
        }

        public bool Editar(Predicate<T> condicao, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    novaEntidade.id = entidade.id;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    
                    registros[posicaoParaEditar] = novaEntidade;
                    
                    serializador.GravarEntidadesEmArquivo(registros);
                    
                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int idSelecionado)
        {
            return Excluir(x => x.id == idSelecionado);
        }

        public bool Excluir(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
            {
                if (condicao(entidade))
                {
                    registros.Remove(entidade);

                    serializador.GravarEntidadesEmArquivo(registros);

                    return true;
                }
            }
            return false;
        }

        public T SelecionarRegistro(int idSelecionado)
        {
            return SelecionarRegistro(x => x.id == idSelecionado);
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

        public bool ExisteRegistro(int idSelecionado)
        {
            return ExisteRegistro(x => x.id == idSelecionado);
        }

        public bool ExisteRegistro(Predicate<T> condicao)
        {
            foreach (T entidade in registros)
                if (condicao(entidade))
                    return true;
                
            return false;
        }
        
        #endregion
    }
}
