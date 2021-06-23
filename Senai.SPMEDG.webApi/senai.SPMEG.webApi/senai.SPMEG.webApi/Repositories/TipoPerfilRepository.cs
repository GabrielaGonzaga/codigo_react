using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class TipoPerfilRepository : ITipoPerfilRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();
       
        public void Atualizar(int id, TipoPerfil tipoPerfilAtualizado)
        {
            // Busca um tipo de perfil através do id
            TipoPerfil tipoPerfilBuscado = ctx.TipoPerfils.Find(id);

            // Verifica se o título do tipo de perfil foi informado
            if (tipoPerfilAtualizado.TituloTipoPerfil != null)
            {
                // Atribui os novos valores ao campos existentes
                tipoPerfilBuscado.TituloTipoPerfil = tipoPerfilAtualizado.TituloTipoPerfil;
            }

            // Atualiza o tipo de perfil que foi buscado
            ctx.TipoPerfils.Update(tipoPerfilBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public TipoPerfil BuscarPorId(int id)
        {
            return ctx.TipoPerfils.FirstOrDefault(tu => tu.IdTipoPerfil == id);
        }

        public void Cadastrar(TipoPerfil novoTipoPerfil)
        {
            // Adiciona este novoTipPerfil
            ctx.TipoPerfils.Add(novoTipoPerfil);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um tipo de perfil através do id
            TipoPerfil tipoUsuarioBuscado = ctx.TipoPerfils.Find(id);

            // Remove o tipo de perfil que foi buscado
            ctx.TipoPerfils.Remove(tipoUsuarioBuscado);

            // Salva as alterações
            ctx.SaveChanges();
        }

        public List<TipoPerfil> Listar()
        {
            // Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.TipoPerfils.ToList();
        }
    }
}
