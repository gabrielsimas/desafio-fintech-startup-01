using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Contratos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;

namespace SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Servicos
{
    public class FinanceiroServicoAplicacao: IFinanceiroServicoAplicacao
    {
        private readonly IFinanceiroServicoDominio dominio;
        private readonly IMapper mapper;

        public FinanceiroServicoAplicacao(IFinanceiroServicoDominio dominio)
        {
            this.dominio = dominio;
            //this.mapper = AutoMapperConfigFactory.GetMapper();
        }

        public void CadastrarCliente(ClienteDto clienteDto)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCobranca(CobrancaDto cobrancaDto)
        {
            throw new NotImplementedException();
        }

        public IList<ClienteDto> CalculaValorDasCobrancas()
        {
            throw new NotImplementedException();
        }

        public CobrancaDto ConsultarCobranca(string cpf, byte mesReferencia)
        {
            throw new NotImplementedException();
        }

        public ClienteDto ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
