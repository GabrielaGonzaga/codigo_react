using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using senai.SPMEG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace senai.SPMEG.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginsController : ControllerBase
    {
        /// <summary>
        /// Objeto _perfilRepository que irá receber todos os métodos definidos na interface IPerfilRepository
        /// </summary>
        private IPerfilRepository _perfilRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _perfilRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginsController()
        {
            _perfilRepository = new PerfilRepository();
        }


        [HttpPost]
        public IActionResult Login(Perfi login)
        {
            //Busca o usuário pelo e-mail e senha
            Perfi perfilBuscado = _perfilRepository.Login(login.Email, login.Senha);

            //Caso não encontre nenhum usuário com o e-mail e senha informados
            if (perfilBuscado == null)
            {
                //retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            //Caso encontre um token será criado

            //Dados fornceidos no token (Payload)
            var claims = new[]
            {
                                              //Tipo da claim + seu valor
                new Claim(JwtRegisteredClaimNames.Email, perfilBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, perfilBuscado.IdPerfil.ToString()),
                new Claim(ClaimTypes.Role, perfilBuscado.IdTipoPerfil.ToString())

            };

            //Chave de acesso do token          Valor codificado
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Semprepea10_perfis"));

            //Credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token 
            var token = new JwtSecurityToken(

                issuer: "SPMEDG.webApi",                 // emissor do token
                audience: "SPMEDG.webApi",               // destinatário do token
                claims: claims,                         // dados de definidos "claims (linha 53)"
                expires: DateTime.Now.AddMinutes(45),    // tempo de expiração (05:38)
                signingCredentials: creds                // credenciais do token 
            );

            //Retorna um satus code 200 (Token foi criado)
            return Ok(new
            {

                token = new JwtSecurityTokenHandler().WriteToken(token)

            });

        }

    }
}
