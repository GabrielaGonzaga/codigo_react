using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            //Busca um medico através do id
            Medico medicoBuscado = ctx.Medicos.Find(id);

            // Verifica as informações

            if (medicoAtualizado.IdTipoPerfil != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.IdTipoPerfil = medicoAtualizado.IdTipoPerfil;
            }

            if (medicoAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.Nome = medicoAtualizado.Nome;
            }

            if (medicoAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.Email = medicoAtualizado.Email;
            }

            if (medicoAtualizado.IdEspecialidade != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            }

            if (medicoAtualizado.Crm != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            if (medicoAtualizado.Cnpj != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.Cnpj = medicoAtualizado.Cnpj;
            }

            if (medicoAtualizado.IdClinica != null)
            {
                // Atribui os novos valores aos campos existentes
                medicoBuscado.IdClinica = medicoAtualizado.IdClinica;
            }

            // Atualiza o medico que foi buscado
            ctx.Medicos.Update(medicoBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            // Retorna o primeiro medico encontrado para o ID informado
            return ctx.Medicos.FirstOrDefault(u => u.IdMedico == id);
        }

        public void Cadastrar(Medico novoMedico)
        {
            //Adiciona este novoMedico
            ctx.Medicos.Add(novoMedico);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um medico através do seu id
            Medico medicoBuscado = ctx.Medicos.Find(id);

            // Remove o medico que foi buscado
            ctx.Medicos.Remove(medicoBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }
    }
}
