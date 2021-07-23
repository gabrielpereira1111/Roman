using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.ListarTudo());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
