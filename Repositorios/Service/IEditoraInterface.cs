using Microsoft.AspNetCore.Mvc;
using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;

namespace QuadrinhosAPI.Repositorios.Service
{
    public interface IEditoraInterface
    {
        public  Task<ResponseModel<List<EditoraModel>>> getEditora();
        public  Task<ResponseModel<List<EditoraModel>>> postEditora(EditoraCriacaoDto editoraCriacaoDto);
        public  Task<ResponseModel<List<EditoraModel>>> putEditora(EditoraEdicaoDto editoraEdicaoDto);
        public  Task<ResponseModel<List<EditoraModel>>> deleteEditora(int id);
    }
}
