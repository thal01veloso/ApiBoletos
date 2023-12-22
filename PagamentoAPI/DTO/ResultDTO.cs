using PagamentoAPI.Models;

namespace PagamentoAPI.DTO
{
    public class ResultDTO
    {
        public int IdBoleto { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public decimal PercentualJuros { get; set; }
        public int IdBanco { get; set; }
        public string? NomePagador { get; set; }
        public string? CPFCNPJPagador { get; set; }
        public string? NomeBeneficiario { get; set; }
        public string? CPFCNPJBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }

        public static List<ResultDTO> MapToResultDTO(List<Boleto> boletos, List<Banco> bancos)
        {
            int tamanho = Math.Min(boletos.Count, bancos.Count);
            var resultados = boletos.Take(tamanho)
                                    .Zip(bancos.Take(tamanho), (boleto, banco) => new ResultDTO
                                    {
                                        IdBoleto = boleto.Id,
                                        NomePagador = boleto.NomePagador,
                                        CPFCNPJPagador = boleto.CPFCNPJPagador,
                                        NomeBeneficiario = boleto.NomeBeneficiario,
                                        CPFCNPJBeneficiario = boleto.CPFCNPJBeneficiario,
                                        Valor = boleto.Valor,
                                        DataVencimento = boleto.DataVencimento,
                                        Observacao = boleto.Observacao,
                                        BancoId = boleto.BancoId,
                                        IdBanco = banco.Id,
                                        Nome = banco.NomeDoBanco,
                                        Codigo = banco.CodigoDoBanco,
                                        PercentualJuros = banco.PercentualDeJuros
                                    }).ToList();

            return resultados;
        }
    }
}
