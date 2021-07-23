using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using roman.webApi.Domains;
using roman.webApi.Interface;
using roman.webApi.Repository;
using roman.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepositoy { get; set; }
        public LoginController()
        {
            _usuarioRepositoy = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepositoy.Login(login.usuario, login.senha);
                if(usuarioBuscado == null)
                {
                    return NotFound("E-mail e/ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim("role", usuarioBuscado.IdTipo.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioBuscado.Usuario1)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "roman.webApi",
                        audience: "roman.webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
