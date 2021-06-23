using senai.SPMEG.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Interfaces
{
    interface IPerfilRepository
    {
        /// <summary>
        /// Lista todos os perfis
        /// </summary>
        /// <returns>Uma lista de perfis</returns>
        List<Perfi> Listar();

        /// <summary>
        /// Busca um perfil através do seu ID
        /// </summary>
        /// <param name="id">ID do perfil que será buscado</param>
        /// <returns>Um perfil buscado</returns>
        Perfi BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo perfil
        /// </summary>
        /// <param name="novoPerfil">Objeto novoPerfil que será cadastrado</param>
        void Cadastrar(Perfi novoPerfil);

        /// <summary>
        /// Atualiza um perfil existente
        /// </summary>
        /// <param name="id">ID do perfil que será atualizado</param>
        /// <param name="perfilAtualizado">Objeto perfilAtualizado com as novas informações</param>
        void Atualizar(int id, Perfi perfilAtualizado);

        /// <summary>
        /// Deleta um perfil existente
        /// </summary>
        /// <param name="id">ID do perfil que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Perfil que foi buscado</returns>
        Perfi Login(string email, string senha);

    }
}

