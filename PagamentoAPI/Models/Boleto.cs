using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PagamentoAPI.Models
{
    public class Boleto
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Nome_Pagador")]
        public string? NomePagador { get; set; }
        [Column("CPF_CNPJ_Pagador")]
        public string? CPFCNPJPagador { get; set; }
        [Column("Nome_Beneficiario")]
        public string? NomeBeneficiario { get; set; }
        [Column("CPF_CNPJ_Beneficiario")]
        public string? CPFCNPJBeneficiario { get; set; }
        [Column("Valor")]

        public decimal Valor { get; set; }
        [Column("Data_vencimento")]
        public DateTime DataVencimento { get; set; }
        [Column("Observacao")]

        public string? Observacao { get; set; }
        [ForeignKey("BancoId")]
        public int BancoId { get; set; }
        public Banco? Banco { get; set; } = new Banco();
    }
}
