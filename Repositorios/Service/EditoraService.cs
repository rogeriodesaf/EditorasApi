using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadrinhosAPI.Data;
using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;

namespace QuadrinhosAPI.Repositorios.Service
{
    public class EditoraService : IEditoraInterface
    {
        private readonly AppDbContext _context;
        public EditoraService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<List<EditoraModel>>> deleteEditora(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<EditoraModel>>> getEditora()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<EditoraModel>>> postEditora(EditoraCriacaoDto editoraCriacaoDto)
        {
            var response = new ResponseModel<List<EditoraModel>>();
            try
            {
                var editora = new EditoraModel();
                {
                    editora.Name = editoraCriacaoDto.Name;
                }
                if(editora is null)
                {
                    response.Mensagem = "Não achei ";
                    response.Status = false;
                    return response;
                }

                _context.Editora.Add(editora);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Editora.ToListAsync();
                response.Mensagem = "Deu certo";
            }
            catch (Exception ex)
            {

               response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public Task<ResponseModel<List<EditoraModel>>> putEditora()
        {
            throw new NotImplementedException();
        }
    }
}
