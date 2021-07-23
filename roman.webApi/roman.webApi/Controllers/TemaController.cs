using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using roman.webApi.Domains;
using roman.webApi.Interface;
using roman.webApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private ITemaRepository _temaRepository { get; set; }
        public TemaController()
        {
            _temaRepository = new TemaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_temaRepository.ListarTudo());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_temaRepository.BuscaPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(Tema novoTema)
        {
            try
            {
                _temaRepository.Cadastrar(novoTema);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _temaRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
