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
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto _clinicaRepository que irá receber todos os métodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para que haja a referência nos métodos implementadas no repositório ClinicaRepository
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todos os clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_clinicaRepository.Listar());
        }



        /// <summary>
        /// Atualiza um clinica existente
        /// </summary>
        /// <param name="id">ID do clinica que será atualizado</param>
        /// <param name="clinicaAtualizado">Objeto clinicaAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizado)
        {
            // Faz a chamada para o método
            _clinicaRepository.Atualizar(id, clinicaAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um clinica através do seu ID
        /// </summary>
        /// <param name="id">ID do clinica que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_clinicaRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo clinica
        /// </summary>
        /// <param name="novoClinica">Objeto novoClinica que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>

        [HttpPost]
        public IActionResult Post(Clinica novoClinica)
        {
            // Faz a chamada para o método
            _clinicaRepository.Cadastrar(novoClinica);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um clinica existente
        /// </summary>
        /// <param name="id">ID do clinica que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _clinicaRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}
