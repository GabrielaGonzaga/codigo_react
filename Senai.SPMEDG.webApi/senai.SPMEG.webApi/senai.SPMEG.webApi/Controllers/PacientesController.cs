using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using senai.SPMEG.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Objeto _pacienteRepository que irá receber todos os métodos definidos na interface IPacienteRepository
        /// </summary>
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _pacienteRepository para que haja a referência nos métodos implementadas no repositório PacienteRepository
        /// </summary>
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_pacienteRepository.Listar());
        }



        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="id">ID do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto pacienteAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente pacienteAtualizado)
        {
            // Faz a chamada para o método
            _pacienteRepository.Atualizar(id, pacienteAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um paciente através do seu ID
        /// </summary>
        /// <param name="id">ID do paciente que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_pacienteRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            // Faz a chamada para o método
            _pacienteRepository.Cadastrar(novoPaciente);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="id">ID do paciente que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _pacienteRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}
