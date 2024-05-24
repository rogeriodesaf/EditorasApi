using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using QuadrinhosAPI.Dto;
using QuadrinhosAPI.Models;
using QuadrinhosAPI.Repositorios.Service;

namespace QuadrinhosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraInterface _editoraInterface;
        public EditoraController(IEditoraInterface editoraInterface)
        {
            _editoraInterface = editoraInterface;   
        }
        [HttpPost("v1/post")]
        public async Task<ActionResult<List<EditoraModel>>> postEditora(EditoraCriacaoDto editoraCriacaoDto)
        {
            var editora = await _editoraInterface.postEditora(editoraCriacaoDto);
            if(editora == null)
            {
                return NotFound(editora.Mensagem);
            }
            return Ok(editora);
        }
        [HttpGet("v1/get")]
        public async Task<ActionResult<List<EditoraModel>>> getEditora()
        {
            var editora = await _editoraInterface.getEditora();
            if(editora is null)
            {
                return NotFound(editora.Mensagem);
            }
            return Ok(editora);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<EditoraModel>>> getEditoraById( int id)
        {
            var editora = await _editoraInterface.getEditoraById(id);
            {
                if(editora != null)
                {
                    return Ok(editora);
                }
                return BadRequest(editora.Mensagem);
            }
        }
        [HttpPut("v1/put")]
        public async Task<ActionResult<List<EditoraModel>>> putEditora(EditoraEdicaoDto editoraEdicaoDto)
        {
            var editora = await _editoraInterface.putEditora(editoraEdicaoDto);
            if(editora is null)
            {
                return NotFound(editora.Mensagem);
            }
            return Ok(editora);
        }
        [HttpDelete("v1/delete")]
        public async Task<ActionResult<List<EditoraModel>>> deleteEditora(int id) 
        {
            var editora = await _editoraInterface.deleteEditora(id);
            if(editora is null)
            {
                return BadRequest(editora.Mensagem);
            }
            return Ok(editora);
        }
    }

}
