using Microsoft.EntityFrameworkCore;
using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Agendar(Consulta novaConsulta)
        {
            //Adiciona este novoClinica
            ctx.Consultas.Add(novaConsulta);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            //Busca um consulta através do id
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            // Verifica as informações

            if (consultaAtualizada.IdMedico!= null)
            {
                // Atribui os novos valores aos campos existentes
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.DataConsulta.ToString() != null)
            {
                // Atribui os novos valores aos campos existentes
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            if (consultaAtualizada.Situacao != null)
            {
                // Atribui os novos valores aos campos existentes
                consultaBuscada.Situacao = consultaAtualizada.Situacao;
            }

            // Atualiza o consulta que foi buscado
            ctx.Consultas.Update(consultaBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void AtualizarSituacao(int id, string Situacao)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (Situacao != null)
            {
                // Atribui os novos valores aos campos existentes
                consultaBuscada.Situacao = Situacao;
            }

            // Atualiza o consulta que foi buscado
            ctx.Consultas.Update(consultaBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            // Retorna o primeiro consulta encontrado para o ID informado
            return ctx.Consultas.FirstOrDefault(u => u.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            //Adiciona este novoConsulta
            ctx.Consultas.Add(novaConsulta);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um consulta através do seu id
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            // Remove o consulta que foi buscado
            ctx.Consultas.Remove(consultaBuscada);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }

        public List<Consulta> ListarConsultaPorMedico(int id)
        {
            return ctx.Consultas
                .Include(c => c.IdMedicoNavigation.Nome)
                .Include(c => c.IdPacienteNavigation.Nome)
                .Include(c => c.DataConsulta.ToString())
                .Include(c => c.Situacao)
                .Where(p => p.IdMedico == id)
                .ToList();
        }

        public List<Consulta> ListarConsultaPorPaciente(int id)
        {
            return ctx.Consultas
               .Include(c => c.IdPacienteNavigation.Nome)
               .Include(c => c.IdMedicoNavigation.Nome)
               .Include(c => c.DataConsulta.ToString())
               .Include(c => c.Situacao)
               .Where(p => p.IdPaciente == id)
               .ToList();
        }
    }
}

