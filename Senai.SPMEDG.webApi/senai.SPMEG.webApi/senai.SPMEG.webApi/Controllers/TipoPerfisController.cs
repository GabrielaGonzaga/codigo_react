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
    public class TipoPerfisController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoDePerfilRepository que irá receber todos os métodos definidos na interface ITipoPerfilRepository
        /// </summary>
        private ITipoPerfilRepository _tipoDePerfilRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoDePerfilRepository para que haja a referência nos métodos implementas no repositório TipoPerfilRepository
        /// </summary>
        public TipoPerfisController()
        {
            _tipoDePerfilRepository = new TipoPerfilRepository();
        }

        /// <summary>
        /// Lista todos os tipoPerfis
        /// </summary>
        /// <returns>Uma lista de tipoPerfis e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoDePerfilRepository.Listar());
        }



        /// <summary>
        /// Atualiza um tipoDePerfil existente
        /// </summary>
        /// <param name="id">ID do tipoDePerfil que será atualizado</param>
        /// <param name="tipoDePerfilAtualizado">Objeto tipoDePerfilAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoPerfil tipoDePerfilAtualizado)
        {
            // Faz a chamada para o método
            _tipoDePerfilRepository.Atualizar(id, tipoDePerfilAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Busca um tipoDePerfil através do seu ID
        /// </summary>
        /// <param name="id">ID do tipoDePerfil que será buscado</param>
        /// <returns>Um estúdio encontrado e um status code 200 - Ok</returns>

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoDePerfilRepository.BuscarPorId(id));
        }


        /// <summary>
        /// Cadastra um novo tipoDePerfil
        /// </summary>
        /// <param name="novoTipoPerfil">Objeto novoTipoPerfil que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoPerfil novoTipoPerfil)
        {
            // Faz a chamada para o método
            _tipoDePerfilRepository.Cadastrar(novoTipoPerfil);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um tipoDePerfil existente
        /// </summary>
        /// <param name="id">ID do tipoDePerfil que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _tipoDePerfilRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(200);
        }

    }
}

