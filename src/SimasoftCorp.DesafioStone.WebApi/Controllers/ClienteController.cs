using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Contratos;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Crosscutting.Mapper;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SimasoftCorp.DesafioStone.WebApi.Controllers
{
    [EnableCors(origins: "*",headers: "*", methods:"get,post")]
    [AllowAnonymous]
    [RoutePrefix("api/v1/stone/cliente")]
    public class ClienteController : ApiController
    {

        private readonly IFinanceiroServicoAplicacao financeiroAplicacao;
        private readonly IMapper mapper = AutoMapperConfigFactory.GetMapper();

        public ClienteController(IFinanceiroServicoAplicacao financeiroAplicacao)
        {
            this.financeiroAplicacao = financeiroAplicacao;            
        }

        //[EnableCors(origins: "*", headers: "*", methods: "post")]
        /// <summary>
        /// Cadastra um Cliente.
        /// </summary>
        /// <param name="dto">Objeto contendo o cliente</param>
        /// <returns>200 para sucesso ou 400 para falha</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ClienteDto))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(Exception))]
        public IHttpActionResult CadastraCliente(ClienteDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {                                        
                    financeiroAplicacao.CadastrarCliente(dto);
                    return Ok(string.Format("Cliente {0} sob o Cpf {1}, residente no Estado {2} cadastrado com sucesso!"));
                }
                else
                {
                    var errors = new List<string>(); //lista de mensagens..

                    foreach (var state in ModelState)
                    {
                        foreach (var e in state.Value.Errors)
                        {
                            errors.Add(e.ErrorMessage);
                        }
                    }

                    return BadRequest(string.Format("Erro ao Cadastrar o cliente {0} [{1}]: {2}",dto.Nome , dto.Cpf,string.Join(", ", errors.ToArray())));
                }
            }
            catch (Exception e)
            {
                return BadRequest(string.Format("Erro ao Cadastrar o cliente {0} [{1}]: {2}", dto.Nome, dto.Cpf,e.Message));
            }            
        }

        /// <summary>
        /// Consulta um cliente cadastrado pelo seu cpf
        /// </summary>
        /// <param name="cpf">CPF do cliente a ser localizado</param>
        /// <returns>200 para sucesso ou 400 para CPF não localizado</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ClienteDto))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(Exception))]
        public IHttpActionResult ConsultarCliente(string cpf)
        {
            ClienteDto dto = new ClienteDto();
            try
            {
                if (ModelState.IsValid)
                {
                    dto = financeiroAplicacao.ObterPorCpf(cpf);
                }else
                {
                    var errors = new List<string>(); //lista de mensagens..

                    foreach (var state in ModelState)
                    {
                        foreach (var e in state.Value.Errors)
                        {
                            errors.Add(e.ErrorMessage);
                        }
                    }
                    return BadRequest(string.Format("Erro(s) ao Buscar o CPF {0} do cliente: {1}", dto.Cpf, string.Join(", ", errors.ToArray())));

                }
                return Ok(dto);
            }catch(Exception e)
            {
                return BadRequest(string.Format("Erro ao Cadastrar o cliente {0} [{1}]: {2}", dto.Nome, dto.Cpf, e.Message));
            }            
        }

        /// <summary>
        /// Fazer um  map/reduce das cobranças realizadas e gerar um relatório com o total cobrado no mês para cada estado.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ClienteDto))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(Exception))]
        public IHttpActionResult RelatorioDeCobrancasRealizadas()
        {
            return Ok();
        }
    }
}
