using PagamentoAPI.Models;

namespace PagamentoAPI.DTO
{
    public class BancoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public decimal PercentualJuros { get; set; }

        public static Banco BancoDtoToBanco(BancoDTO bancoDto)
        {
            return new Banco
            {
                Id = bancoDto.Id,
                NomeDoBanco = bancoDto.Nome,
                CodigoDoBanco=bancoDto.Codigo,
                PercentualDeJuros=bancoDto.PercentualJuros,

            };
        }
        public static BancoDTO MapToDTO(Banco banco) 
        {
            return new BancoDTO
            {
                Id = banco.Id,
                Nome = banco.NomeDoBanco,
                Codigo = banco.CodigoDoBanco,
                PercentualJuros = banco.PercentualDeJuros
            };
        }
        public static List<BancoDTO> MapToDTOs(List<Banco> bancos)
        {
            List<BancoDTO> resultados = new List<BancoDTO>(); 

            foreach (var banco in bancos)
            {
                var result = new BancoDTO
                {
                    Id = banco.Id,
                    Nome = banco.NomeDoBanco,
                    Codigo = banco.CodigoDoBanco,
                    PercentualJuros = banco.PercentualDeJuros
                };

                resultados.Add(result); 
            }

            return resultados; 
        }

    }

}
