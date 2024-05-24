using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;

namespace QuadrinhosAPI.Repositorios.Service
{
    public interface ITituloInterface
    {
        public Task<ResponseModel<List<TituloModel>>> getTitulo();
        public Task<ResponseModel<List<TituloModel>>> postTitulo(TituloCriacaoDto tituloCriacaoDto);
        public Task<ResponseModel<List<TituloModel>>> putTitulo(TituloEdicaoDto tituloEdicaoDto);
        public Task<ResponseModel<List<TituloModel>>> deleteTitulo(int id);
        public Task<ResponseModel<TituloModel>> getTituloById(int id);
        public Task<ResponseModel<List<TituloModel>>> getTituloByIdEditora(int id);

    }
}
