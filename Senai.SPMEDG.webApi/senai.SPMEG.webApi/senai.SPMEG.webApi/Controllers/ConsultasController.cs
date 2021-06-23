using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using senai.SPMEG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class ConsultasController : ControllerBase
    {
        /// <summary>
        /// Objeto _consultaRepository que irá receber todos os métodos definidos na interface IConsultaRepository
        /// </summary>
        private IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja a referência nos métodos implementadas no repositório ConsultaRepository
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todos os consultas
        /// </summary>
        /// <returns>Uma lista de consultas e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_consultaRepository.Listar());
        }



        /// <summary>
        /// Atualiza um consulta existente
        /// </summary>
        /// <param name="id">ID do consulta que será atualizado</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            // Faz a chamada para o método
            _consultaRepository.Atualizar(id, consultaAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Atualiza uma situacao existente
        /// </summary>
        /// <param name="id">ID da situacao que será atualizado</param>
        /// <param name="Situacao">Objeto situacao com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("Situacao/{id}")]
        public IActionResult Put(int id, string Situacao)
        {
            try
            {
                // Faz chamada para o método
                _consultaRepository.AtualizarSituacao(id, Situacao);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // Retorna a exception e um status code 400 - Bad Request
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um consulta através do seu ID
        /// </summary>
        /// <param name="id">ID do consulta que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_consultaRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novoConsulta que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>

        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            // Faz a chamada para o método
            _consultaRepository.Agendar(novaConsulta);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um consulta existente
        /// </summary>
        /// <param name="id">ID do consulta que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _consultaRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

        [Authorize(Roles = "2")]
        [HttpGet("Medicos")]
        public IActionResult GetMyM()
        {
            try
            {
                // Cria uma variável idPerfil que recebe o valor do ID do usuário que está logado
                int idPerfil = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_consultaRepository.ListarConsultaPorMedico(idPerfil));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        [Authorize(Roles = "3")]
        [HttpGet("Pacientes")]
        public IActionResult GetMyP()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idPerfil = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_consultaRepository.ListarConsultaPorPaciente(idPerfil));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }


    }
}
