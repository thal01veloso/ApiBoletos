using PagamentoAPI.Models;

namespace PagamentoAPI.DTO
{
    public class BoletoDTO
    {
        public int Id { get; set; }
        public string? NomePagador { get; set; }
        public string? CPFCNPJPagador { get; set; }
        public string? NomeBeneficiario { get; set; }
        public string? CPFCNPJBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
        public static BoletoDTO MapToDTO(Boleto boleto)
        {
            return new BoletoDTO
            {
                Id = boleto.Id,
                NomePagador = boleto.NomePagador,
                CPFCNPJPagador = boleto.CPFCNPJPagador,
                NomeBeneficiario = boleto.NomeBeneficiario,
                CPFCNPJBeneficiario = boleto.CPFCNPJBeneficiario,
                Valor = boleto.Valor,
                DataVencimento = boleto.DataVencimento,
                Observacao = boleto.Observacao,
                BancoId = boleto.BancoId,
                

            };
        }
        public static Boleto BoletoDtoToBoleto(BoletoDTO boletoDto)
        {
            return new Boleto
            {


                Id = boletoDto.Id,
                NomePagador = boletoDto.NomePagador,
                CPFCNPJPagador = boletoDto.CPFCNPJPagador,
                NomeBeneficiario = boletoDto.NomeBeneficiario,
                CPFCNPJBeneficiario = boletoDto.CPFCNPJBeneficiario,
                Valor = boletoDto.Valor,
                DataVencimento = boletoDto.DataVencimento,
                Observacao = boletoDto.Observacao,
                BancoId = boletoDto.BancoId,
                


            };
        }
        public static List<BoletoDTO> MapToDTOs(List<Boleto> boletos)
        {
            List<BoletoDTO> resultados = new List<BoletoDTO>(); 

            foreach (var boleto in boletos)
            {
                var result = new BoletoDTO
                {
                    Id = boleto.Id,
                    NomePagador = boleto.NomePagador,
                    CPFCNPJPagador = boleto.CPFCNPJPagador,
                    NomeBeneficiario = boleto.NomeBeneficiario,
                    CPFCNPJBeneficiario = boleto.CPFCNPJBeneficiario,
                    Valor = boleto.Valor,
                    DataVencimento = boleto.DataVencimento,
                    Observacao = boleto.Observacao,
                    BancoId = boleto.BancoId 
                };

                resultados.Add(result); 
            }

            return resultados; 
        }
    }


}
