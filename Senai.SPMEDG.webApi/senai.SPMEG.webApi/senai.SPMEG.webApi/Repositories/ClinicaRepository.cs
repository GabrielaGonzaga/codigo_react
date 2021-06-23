using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Atualizar(int id, Clinica clinicaAtualizado)
        {
            //Busca um clinica através do id
            Clinica clinicaBuscado = ctx.Clinicas.Find(id);

            // Verifica as informações

            if (clinicaAtualizado.NomeClinica != null)
            {
                // Atribui os novos valores aos campos existentes
                clinicaBuscado.NomeClinica = clinicaAtualizado.NomeClinica;
            }

            if (clinicaAtualizado.RazaoSocial != null)
            {
                // Atribui os novos valores aos campos existentes
                clinicaBuscado.RazaoSocial = clinicaAtualizado.RazaoSocial;
            }

            if (clinicaAtualizado.Endereço != null)
            {
                // Atribui os novos valores aos campos existentes
                clinicaBuscado.Endereço = clinicaAtualizado.Endereço;
            }

            // Atualiza o clinica que foi buscado
            ctx.Clinicas.Update(clinicaBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            // Retorna o primeiro clinica encontrado para o ID informado
            return ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id);
        }

        public void Cadastrar(Clinica novoClinica)
        {
            //Adiciona este novoClinica
            ctx.Clinicas.Add(novoClinica);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um clinica através do seu id
            Clinica clinicaBuscado = ctx.Clinicas.Find(id);

            // Remove o clinica que foi buscado
            ctx.Clinicas.Remove(clinicaBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}

