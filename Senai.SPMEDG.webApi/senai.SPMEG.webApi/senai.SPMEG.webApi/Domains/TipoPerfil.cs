using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SPMEG.webApi.Domains
{
    public partial class TipoPerfil
    {
        public TipoPerfil()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
            Perfis = new HashSet<Perfi>();
        }

        public int IdTipoPerfil { get; set; }
        public string TituloTipoPerfil { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
        public virtual ICollection<Perfi> Perfis { get; set; }
    }
}
