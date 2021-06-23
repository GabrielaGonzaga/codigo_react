using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Atualizar(int id, Perfi perfilAtualizado)
        {
            //Busca um perfil através do id
            Perfi perfilBuscado = ctx.Perfis.Find(id);

            // Verifica as informações

            if (perfilAtualizado.IdTipoPerfil != null)
            {
                // Atribui os novos valores aos campos existentes
                perfilBuscado.IdTipoPerfil = perfilAtualizado.IdTipoPerfil;
            }

            if (perfilAtualizado.NomeUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                perfilBuscado.NomeUsuario = perfilAtualizado.NomeUsuario;
            }

            if (perfilAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                perfilBuscado.Email = perfilAtualizado.Email;
            }

            if (perfilAtualizado.Senha != null)
            {
                // Atribui os novos valores aos campos existentes
                perfilBuscado.Senha = perfilAtualizado.Senha;
            }
            // Atualiza o perfil que foi buscado
            ctx.Perfis.Update(perfilBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Perfi BuscarPorId(int id)
        {
            // Retorna o primeiro perfil encontrado para o ID informado
            return ctx.Perfis.FirstOrDefault(u => u.IdPerfil == id);
        }

        public void Cadastrar(Perfi novoPerfil)
        {
            // Adiciona este novoPerfil
            ctx.Perfis.Add(novoPerfil);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um perfil através do seu id
            Perfi perfilBuscado = ctx.Perfis.Find(id);

            // Remove o perfil que foi buscado
            ctx.Perfis.Remove(perfilBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Perfi> Listar()
        {
            return ctx.Perfis.ToList();
        }

        public Perfi Login(string email, string senha)
        {
            // Retorna o perfil encontrado através do e-mail e da senha
            return ctx.Perfis.FirstOrDefault(l => l.Email == email && l.Senha == senha);
        }
    }
}
