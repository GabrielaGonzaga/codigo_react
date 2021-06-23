using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Uma lista de medicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Busca um medico através do seu ID
        /// </summary>
        /// <param name="id">ID do medico que será buscado</param>
        /// <returns>Um medico buscado</returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto medicoAtualizado com as novas informações</param>
        void Atualizar(int id, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um medico existente
        /// </summary>
        /// <param name="id">ID do medico que será deletado</param>
        void Deletar(int id);
    }
}
