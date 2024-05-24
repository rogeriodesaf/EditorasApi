using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;
using QuadrinhosAPI.Repositorios.Service;

namespace QuadrinhosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TituloController : ControllerBase
    {
        
        private readonly ITituloInterface _tituloInterface;
        public TituloController(ITituloInterface tituloInterface)
        {
            _tituloInterface = tituloInterface;
        }
        [HttpPost("criar-titulo/v1")]
        public async Task<ActionResult<ResponseModel<List<TituloModel>>>> postTitulo(TituloCriacaoDto tituloCriacaoDto)
        {
            var titulo = await _tituloInterface.postTitulo(tituloCriacaoDto);   
            if(titulo.Dados == null)
            {
                return NotFound(titulo.Mensagem);
            }
            return Ok(titulo);
        }
        [HttpGet("get-titulo/v1")]
        public async Task<ActionResult<ResponseModel<List<TituloModel>>>> getTitulo()
        {
            var titulo = await _tituloInterface.getTitulo();
            if (titulo.Dados == null)
            {
                return NotFound(titulo.Mensagem);
            }
            return Ok(titulo);
        }
        [HttpGet("titulo/{id}")]
        public async Task<ActionResult<ResponseModel<TituloModel>>> getTituloById(int id)
        {
            var titulo = await _tituloInterface.getTituloById(id);
            if(titulo is null)
            {
                return NotFound(titulo.Mensagem);
            }
            return Ok(titulo);
        }
        [HttpGet("{idEditora}")]
        public async Task<ActionResult<ResponseModel<List<TituloModel>>>> getTituloByEditoraId(int idEditora)
        {
            var titulos = await _tituloInterface.getTituloByIdEditora(idEditora);
            {
                if(titulos != null)
                {
                    return Ok(titulos);
                }
                return NotFound(titulos.Mensagem);
            }
        }
        [HttpPut("edicao/v1")]
        public async Task<ActionResult<ResponseModel<List<TituloModel>>>> putTitulo(TituloEdicaoDto tituloEdicaoDto)
        {
            var titulo = await _tituloInterface.putTitulo(tituloEdicaoDto);
            if(titulo != null)
            {
                return Ok(titulo);
            }
            return NotFound(titulo.Mensagem);
        }
        [HttpDelete("titulo/v1")]
        public async Task<ActionResult<ResponseModel<List<TituloModel>>>> deleteTitulo(int id)
        {
            var titulo = await _tituloInterface.deleteTitulo(id);
            if(titulo is null)
            {
                return NotFound(titulo.Mensagem);
            }
            return Ok(titulo);
        }
    }
}
