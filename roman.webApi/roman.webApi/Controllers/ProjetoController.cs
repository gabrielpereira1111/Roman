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
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }
        public ProjetoController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoRepository.ListarTudo());
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
                return Ok(_projetoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);
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
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
