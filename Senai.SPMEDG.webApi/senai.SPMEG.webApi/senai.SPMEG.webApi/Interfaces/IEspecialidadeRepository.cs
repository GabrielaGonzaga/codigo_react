using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todos os especialidades
        /// </summary>
        /// <returns>Uma lista de especialidades</returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca um especialidade através do seu ID
        /// </summary>
        /// <param name="id">ID do especialidade que será buscado</param>
        /// <returns>Um especialidade buscado</returns>
        Especialidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo especialidade
        /// </summary>
        /// <param name="novoEspecialidade">Objeto novoEspecialidade que será cadastrado</param>
        void Cadastrar(Especialidade novoEspecialidade);

        /// <summary>
        /// Atualiza um especialidade existente
        /// </summary>
        /// <param name="id">ID do especialidade que será atualizado</param>
        /// <param name="especialidadeAtualizado">Objeto especialidadeAtualizado com as novas informações</param>
        void Atualizar(int id, Especialidade especialidadeAtualizado);

        /// <summary>
        /// Deleta um especialidade existente
        /// </summary>
        /// <param name="id">ID do especialidade que será deletado</param>
        void Deletar(int id);
    }
}
