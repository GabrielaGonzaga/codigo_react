using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface ITipoPerfilRepository
    {
        /// <summary>
        /// Lista todos os tipos de Perfis
        /// </summary>
        /// <returns>Uma lista de tipoPerfil</returns>
        List<TipoPerfil> Listar();

        /// <summary>
        /// Busca um tipoPerfil através do seu ID
        /// </summary>
        /// <param name="id">ID do tipoPerfil que será buscado</param>
        /// <returns>Um tipoPerfil buscado</returns>
        TipoPerfil BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipoPerfil
        /// </summary>
        /// <param name="novoTipoPerfil">Objeto novoTipoPerfil que será cadastrado</param>
        void Cadastrar(TipoPerfil novoTipoPerfil);

        /// <summary>
        /// Atualiza um tipoPerfil existente
        /// </summary>
        /// <param name="id">ID do tipoPerfil que será atualizado</param>
        /// <param name="tipoPerfilAtualizado">Objeto tipoPerfilAtualizado com as novas informações</param>
        void Atualizar(int id, TipoPerfil tipoPerfilAtualizado);

        /// <summary>
        /// Deleta um tipoPerfil existente
        /// </summary>
        /// <param name="id">ID do tipoPerfil que será deletado</param>
        void Deletar(int id);

    }
}
