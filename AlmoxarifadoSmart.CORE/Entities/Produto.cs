using System;
using System.Collections.Generic;

namespace AlmoxarifadoSmart.API
{
    public partial class Produto
    {
        public Produto()
        {
            IdRequisicaos = new HashSet<Requisicao>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public int? EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }

        public virtual ICollection<Requisicao> IdRequisicaos { get; set; }
    }
}
