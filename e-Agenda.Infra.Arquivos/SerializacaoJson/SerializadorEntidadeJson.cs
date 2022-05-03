using e_Agenda.Dominio.Compartilhado;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace e_Agenda.Infra.Arquivos.SerializacaoJson
{
    public class SerializadorEntidadeJson<T> : ISerializadorEntidade<T> where T : EntidadeBase
    {
        private string arquivoEntidades;

        public SerializadorEntidadeJson()
        {
            string diretorio = @"C:\temp";

            if(Directory.Exists(diretorio) == false)
                Directory.CreateDirectory(diretorio);

            string arquivo = $"\\{typeof(T).Name}.json";

            arquivoEntidades = diretorio + arquivo;
        }

        public List<T> CarregarEntidadesDoArquivo()
        {
            if (File.Exists(arquivoEntidades) == false)
                return new List<T>();

            string entidadesJson = File.ReadAllText(arquivoEntidades);

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            return JsonConvert.DeserializeObject<List<T>>(entidadesJson, settings);
        }

        public void GravarEntidadesEmArquivo(List<T> entidades)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.Formatting = Formatting.Indented;

            string entidadesJson = JsonConvert.SerializeObject(entidades, settings);

            File.WriteAllText(arquivoEntidades, entidadesJson);
        }
        
    }
}
