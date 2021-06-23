﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SPMEG.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public int? IdTipoPerfil { get; set; }
        public int? IdEspecialidade { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public int? IdClinica { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual TipoPerfil IdTipoPerfilNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
