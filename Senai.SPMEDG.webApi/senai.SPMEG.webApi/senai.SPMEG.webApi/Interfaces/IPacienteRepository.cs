using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Busca um paciente através do seu ID
        /// </summary>
        /// <param name="id">ID do paciente que será buscado</param>
        /// <returns>Um paciente buscado</returns>
        Paciente BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente que será cadastrado</param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="id">ID do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto pacienteAtualizado com as novas informações</param>
        void Atualizar(int id, Paciente pacienteAtualizado);

        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="id">ID do paciente que será deletado</param>
        void Deletar(int id);
    }
}
