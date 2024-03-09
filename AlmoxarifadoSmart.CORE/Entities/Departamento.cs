using System;
using System.Collections.Generic;

namespace AlmoxarifadoSmart.API
{
    public partial class Departamento
    {
        public Departamento()
        {
            Requisicaos = new HashSet<Requisicao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Requisicao> Requisicaos { get; set; }
    }
}
