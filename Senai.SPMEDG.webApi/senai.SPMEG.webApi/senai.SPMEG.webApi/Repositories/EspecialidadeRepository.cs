using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Atualizar(int id, Especialidade especialidadeAtualizado)
        {
            //Busca um especialidade através do id
            Especialidade especialidadeBuscado = ctx.Especialidades.Find(id);

            // Verifica as informações

            if (especialidadeAtualizado.NomeEspecialidade != null)
            {
                // Atribui os novos valores aos campos existentes
                especialidadeBuscado.NomeEspecialidade = especialidadeAtualizado.NomeEspecialidade;
            }

            // Atualiza o especialidade que foi buscado
            ctx.Especialidades.Update(especialidadeBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int id)
        {
            // Retorna o primeiro especialidade encontrado para o ID informado
            return ctx.Especialidades.FirstOrDefault(u => u.IdEspecialidade == id);
        }

        public void Cadastrar(Especialidade novoEspecialidade)
        {
            //Adiciona este novoEspecialidade
            ctx.Especialidades.Add(novoEspecialidade);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um especialidade através do seu id
            Especialidade especialidadeBuscado = ctx.Especialidades.Find(id);

            // Remove o especialidade que foi buscado
            ctx.Especialidades.Remove(especialidadeBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
