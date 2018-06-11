using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Contratos;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SimasoftCorp.DesafioStone.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "get,post")]
    [AllowAnonymous]
    [RoutePrefix("api/v1/stone/financeiro")]
    public class FinanceiroController : ApiController
    {
        private readonly IFinanceiroServicoAplicacao financeiroAplicacao;
        private readonly IMapper mapper = AutoMapperConfigFactory.GetMapper();

        public FinanceiroController(IFinanceiroServicoAplicacao financeiroAplicacao)
        {
            this.financeiroAplicacao = financeiroAplicacao;            
        }        


    }
}
