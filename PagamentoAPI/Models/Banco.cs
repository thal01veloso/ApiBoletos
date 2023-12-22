using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PagamentoAPI.Models
{
    public class Banco
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Nome_Banco")]
        public string? NomeDoBanco { get; set; }
        [Column("Codigo_Banco")]
        public string? CodigoDoBanco { get; set; }
        [Column("Percentual_Juros")]
        public decimal PercentualDeJuros { get; set; }
        public List<Boleto>? Boletos { get; set; } = new List<Boleto>() { };
    }

}
