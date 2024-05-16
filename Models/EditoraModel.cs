using System.Text.Json.Serialization;

namespace QuadrinhosAPI.Models
{
    public class EditoraModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<TituloModel> Titulos { get; set; }
    }
}
