using System;
using System.Collections.Generic;

#nullable disable

namespace senai.SPMEG.webApi.Domains
{
    public partial class Perfi
    {
        public int IdPerfil { get; set; }
        public int? IdTipoPerfil { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoPerfil IdTipoPerfilNavigation { get; set; }
    }
}
