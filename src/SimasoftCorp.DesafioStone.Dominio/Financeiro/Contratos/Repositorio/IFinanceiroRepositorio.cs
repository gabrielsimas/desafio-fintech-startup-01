using System.Collections.Generic;

namespace SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Repositorio
{
    public interface IFinanceiroRepositorio
    {
        void CadastraCliente(Cliente clienteDominio);
        void CadastraCobrancaParaCliente(string cpf, Cobranca cobrancaDominio);
        Cliente ObterPorCpf(string cpf);
        List<Cliente> ListarCobrancasRegistradasPorCpfOuMesDeReferencia(string cpf, byte mesDeReferencia);
        List<Cliente> ListarTodos();
        bool Integracao();
    }
}
