using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PagamentoAPI.Context;
using PagamentoAPI.DTO;
using PagamentoAPI.Models;

namespace PagamentoAPI.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly PagamentoContext _context;
        public PagamentoController(PagamentoContext context)
        {
            _context = context;
        }
        [HttpGet]

        [HttpGet]
        [Route("Bancos")]
        public IEnumerable<BancoDTO> GetBancos()
        {
            var bancos = _context.Bancos.ToList();
            return BancoDTO.MapToDTOs(bancos);
        }
        [HttpGet]
        [Route("Boletos")]
        public IEnumerable<BoletoDTO> GetBoletos()
        {
            var boletos = _context.Boletos.ToList();
            return BoletoDTO.MapToDTOs(boletos);
        }

        [HttpPost]
        [Route("criaBoletos")]
        public async Task<IActionResult> CriarBoleto([FromBody] BoletoDTO boletoDto)
        {

            try
            {
                var boleto = BoletoDTO.BoletoDtoToBoleto(boletoDto);
                _context.Boletos.Add(boleto);
                var response = await _context.SaveChangesAsync();
                return Ok("Inserido Com Sucesso !!!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        [HttpPost]
        [Route("criaBancos")]
        public async Task<IActionResult> CriarBanco([FromBody] BancoDTO bancoDto)
        {
            try
            {
                var banco = BancoDTO.BancoDtoToBanco(bancoDto);
                _context.Bancos.Add(banco);
                var response = await _context.SaveChangesAsync();
                return Ok("Inserido Com Sucesso !!!");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        [HttpGet("BancoId")]
        public ActionResult<BancoDTO> GetBancoPorId(int id)
        {
            var result = _context.Bancos.FirstOrDefault(x => x.Id == id);
            var bancoDTO = BancoDTO.MapToDTO(result);
            if (bancoDTO == null)
            {
                return NotFound();
            }
            return bancoDTO;
        }
        [HttpGet("BoletoId")]
        public ActionResult<BoletoDTO> GetBoletoPorId(int id)
        {
            var result = _context.Boletos.FirstOrDefault(x => x.Id == id);
            var boletoDto = BoletoDTO.MapToDTO(result);
            if (boletoDto == null)
            {
                return NotFound();
            }
            return boletoDto;
        }
        [HttpGet("TodosRegistros")]
        public IEnumerable<ResultDTO> GetAllRegistros()
        {
            var resultados = _context.Boletos
                                        .Join(
                _context.Bancos,
                boleto => boleto.BancoId,
                banco => banco.Id,
                (boleto, banco) => new ResultDTO
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
        })
    .ToList();

            return resultados;
        }
    }
}
