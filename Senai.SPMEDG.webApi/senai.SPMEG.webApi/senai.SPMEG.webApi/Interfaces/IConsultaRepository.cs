using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todos os consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<Consulta> Listar();

        /// <summary>
        /// Busca um consulta através do seu ID
        /// </summary>
        /// <param name="id">ID do consulta que será buscado</param>
        /// <returns>Um consulta buscado</returns>
        Consulta BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrada</param>
        void Agendar(Consulta novaConsulta);

        /// <summary>
        /// Atualiza um consulta existente
        /// </summary>
        /// <param name="id">ID do consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizada com as novas informações</param>
        void Atualizar(int id, Consulta consultaAtualizada);


        /// <summary>
        /// Atualiza uma situaão existente
        /// </summary>
        /// <param name="id">ID do consulta e a situação que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizado com as novas informações</param>
        void AtualizarSituacao(int id, string Situacao);


        /// <summary>
        /// Deleta um consulta existente
        /// </summary>
        /// <param name="id">ID do consulta que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Lista todas as consultas de um medico
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<Consulta> ListarConsultaPorMedico(int id);

        /// <summary>
        /// Lista todas as consultas de um paciente
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<Consulta> ListarConsultaPorPaciente(int id);
    }
}

