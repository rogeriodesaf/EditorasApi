using Microsoft.EntityFrameworkCore;
using QuadrinhosAPI.Data;
using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;

namespace QuadrinhosAPI.Repositorios.Service
{
    public class TituloService : ITituloInterface
    {
        private readonly AppDbContext _context;
            public TituloService(AppDbContext context)
        {
                _context = context;
        }
        public async Task<ResponseModel<List<TituloModel>>> deleteTitulo(int id)
        {
           var response = new ResponseModel<List<TituloModel>>();
            try
            {
                var titulo = await _context.Titulo
                    .Include(a => a.Editora)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if(titulo == null)
                {
                    response.Mensagem = "Não foi encontrado nenhum titulo";
                    response.Status = false;
                    return response;

                }

                _context.Titulo.Remove(titulo);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Titulo.ToListAsync();
                response.Mensagem = "Exclui geral!";
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<TituloModel>>> getTitulo()
        {
            var response = new ResponseModel<List<TituloModel>>();
            try
            {
                var titulos = await _context.Titulo
                    .Include(a => a.Editora)
                    .ToListAsync();
                if(titulos is null)
                {
                    response.Mensagem = "Tá nulo, parceiro!";
                    response.Status = false;
                    return response;
                }

                response.Dados = titulos;
                response.Mensagem = "Deu certo geral!";
            }
            catch (Exception ex)
            {

                response.Mensagem = "Deu errado véi!"+ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async  Task<ResponseModel<TituloModel>> getTituloById(int id)
        {
            var response = new ResponseModel<TituloModel>();
            try
            {
                var titulo = await _context.Titulo
                    .Include(a => a.Editora)
                    .FirstOrDefaultAsync(b => b.Id == id);
                if(titulo == null)
                {
                    response.Mensagem = "Titulo não encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = titulo;
                response.Mensagem = "Dados retornados com sucesso";

                
            }
            catch (Exception ex)
            {

                response.Mensagem = ex.Message;
                response.Status= false;
                return response;
            }
            return response;
        }

        public async  Task<ResponseModel<List<TituloModel>>> getTituloByIdEditora(int id)
        {
            ResponseModel<List<TituloModel>> response = new ResponseModel<List<TituloModel>>();
            try
            {
                var titulos = await _context.Titulo
                    .Include(a => a.Editora)
                    .FirstOrDefaultAsync(b => b.Editora.Id ==id);   
                if(titulos == null)
                {
                    response.Mensagem = "titulo não encontrado";
                    response.Status = false;
                    return response;
                }

                response.Dados = await _context.Titulo.ToListAsync();
                response.Mensagem = "Titulos pelo Id da Editora retornados!";
            }
            catch (Exception ex)
            {

                throw;
            }
            return response;
        }

        public async Task<ResponseModel<List<TituloModel>>> postTitulo(TituloCriacaoDto tituloCriacaoDto)
        {
            var response = new ResponseModel<List<TituloModel>>();

            try
            {

                var editora = await _context.Editora
                    .FirstOrDefaultAsync(a => a.Id == tituloCriacaoDto.Editora.EditoraId);

                var titulo = new TituloModel();
                {
                    titulo.Nome = tituloCriacaoDto.Nome;
                    titulo.Editora = editora;
                   
                }
                if(editora != null)
                {
                    _context.Titulo.Add(titulo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    response.Mensagem = "Não existe editora para este ID";
                    response.Status=false;
                    return response;
                }
                response.Dados = await _context.Titulo.ToListAsync();
                response.Mensagem = "Legal!";


                
            }
            catch (Exception ex)
            {

                response.Mensagem = "deu erro hein "+ex.Message;
                response.Status = false;
                return response;
            }
            return response;
        }

        public async Task<ResponseModel<List<TituloModel>>> putTitulo(TituloEdicaoDto tituloEdicaoDto)
        {
            var response = new ResponseModel<List<TituloModel>>();
            try
            {
                var titulo = await _context.Titulo
                    .Include(a => a.Editora)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(b => b.Id == tituloEdicaoDto.TituloId);

              

                var tituloEditado = new TituloModel();
                {
                    tituloEditado.Id = tituloEdicaoDto.TituloId;
                    tituloEditado.Nome = tituloEdicaoDto.Nome;
                    
                  
                }
              
                _context.Titulo.Update(tituloEditado);
                await _context.SaveChangesAsync();

                response.Dados = await _context.Titulo
                    .Include(a =>a.Editora)
                    .ToListAsync();
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
    }
}
