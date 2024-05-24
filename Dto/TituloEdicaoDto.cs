using QuadrinhosAPI.VinculoDto;

namespace QuadrinhosAPI.Dto
{
    public class TituloEdicaoDto
    {
        public int TituloId { get; set; }
        public string Nome { get; set; }
        public TituloVinculoDto Editora { get; set; }
    }
}
