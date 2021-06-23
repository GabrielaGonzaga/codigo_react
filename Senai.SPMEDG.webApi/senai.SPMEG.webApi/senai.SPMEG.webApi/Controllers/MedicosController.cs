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
    public class MedicosController : ControllerBase
    {

        /// <summary>
        /// Objeto _medicoRepository que irá receber todos os métodos definidos na interface IMedicoRepository
        /// </summary>
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _medicoRepository para que haja a referência nos métodos implementadas no repositório MedicoRepository
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista de medicos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_medicoRepository.Listar());
        }



        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto medicoAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medico medicoAtualizado)
        {
            // Faz a chamada para o método
            _medicoRepository.Atualizar(id, medicoAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um medico através do seu ID
        /// </summary>
        /// <param name="id">ID do medico que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_medicoRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            // Faz a chamada para o método
            _medicoRepository.Cadastrar(novoMedico);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _medicoRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}

