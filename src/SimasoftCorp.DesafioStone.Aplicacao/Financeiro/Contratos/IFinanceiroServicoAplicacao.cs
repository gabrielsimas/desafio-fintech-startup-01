using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Contratos
{
    public interface IFinanceiroServicoAplicacao
    {
        void CadastrarCliente(ClienteDto clienteDto);
        ClienteDto ObterPorCpf(string cpf);
        void CadastrarCobranca(CobrancaDto cobrancaDto);
        CobrancaDto ConsultarCobranca(string cpf, byte mesReferencia);
        IList<ClienteDto> CalculaValorDasCobrancas();
    }
}
