using senai.SPMEG.webApi.Contexts;
using senai.SPMEG.webApi.Domains;
using senai.SPMEG.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SPMEG.webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMEDGContext ctx = new SPMEDGContext();

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            //Busca um paciente através do id
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            // Verifica as informações

            if (pacienteAtualizado.IdTipoPerfil != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.IdTipoPerfil = pacienteAtualizado.IdTipoPerfil;
            }

            if (pacienteAtualizado.Nome != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Nome = pacienteAtualizado.Nome;
            }

            if (pacienteAtualizado.Email != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Email = pacienteAtualizado.Email;
            }

            if (pacienteAtualizado.DataNascimento.ToString() != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.DataNascimento = pacienteAtualizado.DataNascimento;
            }

            if (pacienteAtualizado.Telefone != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Telefone = pacienteAtualizado.Telefone;
            }

            if (pacienteAtualizado.Rg != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }

            if (pacienteAtualizado.Cpf != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }

            if (pacienteAtualizado.Endereço != null)
            {
                // Atribui os novos valores aos campos existentes
                pacienteBuscado.Endereço = pacienteAtualizado.Endereço;
            }
            // Atualiza o paciente que foi buscado
            ctx.Pacientes.Update(pacienteBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            // Retorna o primeiro paciente encontrado para o ID informado
            return ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            //Adiciona este novoPaciente
            ctx.Pacientes.Add(novoPaciente);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um paciente através do seu id
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            // Remove o paciente que foi buscado
            ctx.Pacientes.Remove(pacienteBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }
    }
}

