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
    public class EspecialidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _especialidadeRepository que irá receber todos os métodos definidos na interface IEspecialidadeRepository
        /// </summary>
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _especialidadeRepository para que haja a referência nos métodos implementadas no repositório EspecialidadeRepository
        /// </summary>
        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todos os especialidades
        /// </summary>
        /// <returns>Uma lista de especialidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_especialidadeRepository.Listar());
        }



        /// <summary>
        /// Atualiza um especialidade existente
        /// </summary>
        /// <param name="id">ID do especialidade que será atualizado</param>
        /// <param name="especialidadeAtualizado">Objeto especialidadeAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Especialidade especialidadeAtualizado)
        {
            // Faz a chamada para o método
            _especialidadeRepository.Atualizar(id, especialidadeAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um especialidade através do seu ID
        /// </summary>
        /// <param name="id">ID do especialidade que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>
        /// http://localhost:5000/api/estudios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_especialidadeRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo especialidade
        /// </summary>
        /// <param name="novoEspecialidade">Objeto novoEspecialidade que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        
        [HttpPost]
        public IActionResult Post(Especialidade novoEspecialidade)
        {
            // Faz a chamada para o método
            _especialidadeRepository.Cadastrar(novoEspecialidade);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um especialidade existente
        /// </summary>
        /// <param name="id">ID do especialidade que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _especialidadeRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }
    }
}

