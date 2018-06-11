namespace SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Servico
{
    public interface IFinanceiroServicoDominio
    {
        void CadastrarCliente(Cliente cliente);
        Cliente ObterPorCpf(string cpf);
        void CadastrarCobranca(Cobranca cobranca);
        void ConsultarCobranca(string cpf, byte mesReferencia);
        Cliente CalculaValorDasCobrancas();

    }
}
