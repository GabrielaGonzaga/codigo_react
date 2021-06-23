using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SPMEG.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }
        public int? IdTipoPerfil { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereço { get; set; }

        public virtual TipoPerfil IdTipoPerfilNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
