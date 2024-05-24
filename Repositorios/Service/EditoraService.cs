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

        public async Task<ResponseModel<List<EditoraModel>>> deleteEditora(int id)
        {
            var response = new ResponseModel<List<EditoraModel>>();
            try
            {
                var editora = await _context.Editora
                    .FirstOrDefaultAsync(a => a.Id == id);  
                if(editora != null)
                {
                    _context.Editora.Remove(editora);
                    await _context.SaveChangesAsync();
                }

                response.Dados = await _context.Editora.ToListAsync();
                response.Mensagem = "Deu certo!";
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu muito errado " + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<EditoraModel>>> getEditora()
        {
            var response = new ResponseModel<List<EditoraModel>>();
            try
            {
                var editora = await _context.Editora.ToListAsync();
                if(editora is null)
                {
                    response.Mensagem = "Deu errado";
                    response.Status = false;
                    return response;
                }

                response.Dados = await _context.Editora.ToListAsync();
                response.Mensagem = "Deu certo!";
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu muito errado" + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<EditoraModel>> getEditoraById(int id)
        {
           ResponseModel<EditoraModel> response = new ResponseModel<EditoraModel>();

            try
            {
                var editora = await _context.Editora
                    .Include(a => a.Titulos)
                    .FirstOrDefaultAsync(b => b.Id == id);
                if(editora is null)
                {
                    response.Mensagem = "Editora não encontrada";
                    response.Status=false;
                    return response;
                }

                response.Dados = editora;
                response.Mensagem = "Dados retornados com sucesso!";
                
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message ;
                response.Status = false;
                return response;
            }
            return response;
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

        public async  Task<ResponseModel<List<EditoraModel>>> putEditora(EditoraEdicaoDto editoraEdicaoDto)
        {
            var response = new ResponseModel<List<EditoraModel>>();
            try
            {
                var editoraEdicao = await _context.Editora
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == editoraEdicaoDto.Id);
                var editora = new EditoraModel();
                {
                    editora.Id = editoraEdicaoDto.Id;
                    editora.Name = editoraEdicaoDto.Name;
                }

                _context.Editora.Update(editora);
                await _context.SaveChangesAsync();

                response.Dados = await  _context.Editora.ToListAsync();
                response.Mensagem = "Deu certo!";
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu muito errado " + ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }
    }
}
