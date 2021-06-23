using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todos os clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca um clinica através do seu ID
        /// </summary>
        /// <param name="id">ID do clinica que será buscado</param>
        /// <returns>Um clinica buscado</returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo clinica
        /// </summary>
        /// <param name="novoClinica">Objeto novoClinica que será cadastrado</param>
        void Cadastrar(Clinica novoClinica);

        /// <summary>
        /// Atualiza um clinica existente
        /// </summary>
        /// <param name="id">ID do clinica que será atualizado</param>
        /// <param name="clinicaAtualizado">Objeto clinicaAtualizado com as novas informações</param>
        void Atualizar(int id, Clinica clinicaAtualizado);

        /// <summary>
        /// Deleta um clinica existente
        /// </summary>
        /// <param name="id">ID do clinica que será deletado</param>
        void Deletar(int id);
    }
}
