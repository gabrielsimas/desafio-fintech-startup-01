using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Contratos;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SimasoftCorp.DesafioStone.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "get,post")]
    [AllowAnonymous]
    [RoutePrefix("api/v1/stone/cobranca")]
    public class CobrancaController : ApiController
    {
        private readonly IFinanceiroServicoAplicacao financeiroAplicacao;
        private readonly IMapper mapper = AutoMapperConfigFactory.GetMapper();

        public CobrancaController(IFinanceiroServicoAplicacao financeiroAplicacao)
        {
            this.financeiroAplicacao = financeiroAplicacao;            
        }

        public IHttpActionResult RegistrarCobranca(CobrancaDto dto)
        {
            try
            {
                financeiroAplicacao.CadastrarCobranca(dto);
                return Ok();
            }catch(Exception e)
            {
                return BadRequest(string.Format("Erro ao cadastrar cobranca para o cliente de CPF {0}: {1}",dto.Cpf, e.Message));
            }
        }

        public IHttpActionResult RetornaCobrancaRegistrada(string cpf, byte mesReferencia)
        {
            financeiroAplicacao.ConsultarCobranca(cpf, mesReferencia);
            return Ok();            
        }
    }
}
