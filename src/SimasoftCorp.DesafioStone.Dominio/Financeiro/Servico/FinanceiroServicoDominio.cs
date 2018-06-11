using System;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Repositorio;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Servico;

namespace SimasoftCorp.DesafioStone.Dominio.Financeiro.Servico
{
    public class FinanceiroServicoDominio: IFinanceiroServicoDominio
    {
        private readonly IFinanceiroRepositorio financeiroRepositorio;

        public FinanceiroServicoDominio(IFinanceiroRepositorio financeiroRepositorio)            
        {
            this.financeiroRepositorio = financeiroRepositorio;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            //Converte o cliente para a entidade clCliente
            //Utiliza o Automapper para fazer a conversão

            //Executa a persistência
            throw new NotImplementedException();
        }

        public void CadastrarCobranca(Cobranca cobranca)
        {
            throw new NotImplementedException();
        }

        public Cliente CalculaValorDasCobrancas()
        {
            throw new NotImplementedException();
        }

        public void ConsultarCobranca(string cpf, byte mesReferencia)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
