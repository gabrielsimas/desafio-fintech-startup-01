using System;
using System.Collections.Generic;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.Financeiro.Contratos.Repositorio;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;

namespace SimasoftCorp.DesafioStone.Infraestrutura.Repositorio
{
    public class FinanceiroRepositorio : IFinanceiroRepositorio
    {
        //TODO: Criar o objeto conexão e colocar aqui
        public FinanceiroRepositorio()
        {

        }

        public void CadastraCliente(Cliente clienteDominio)
        {
            ClCliente cliente = new ClCliente()
            {
                Cpf = clienteDominio.Cpf.Numero.ToString(),
                Nome = clienteDominio.Nome.Texto,
                Uf = clienteDominio.Estado.SiglaEstado
            };            
        }

        public void CadastraCobrancaParaCliente(string cpf, Cobranca cobrancaDominio)
        {
            //Pega o cliente
            Cliente clienteDominio = ObterPorCpf(cpf);

            if (clienteDominio.Cpf.Numero > 0)
            {
                ClCobranca collectionCobranca = new ClCobranca()
                {
                    DataDeVencimento = cobrancaDominio.DataDeVencimento.DataContabil,
                    Valor = cobrancaDominio.Valor
                };

                ClCliente collectionCliente = new ClCliente()
                {
                    Cpf = clienteDominio.Cpf.Numero.ToString(),
                    Nome = clienteDominio.Nome.Texto,
                    Uf = clienteDominio.Estado.SiglaEstado,
                };
                collectionCliente.Cobrancas.Add(collectionCobranca);

                //Persiste o objeto no MongoDB com a cláusula Update
            }
            else
            {
                //throw new FinanceiroRepositorioException(string.Format("O cliente de Cpf {0} não foi localizado no Sistema!"));
            }
        }

        public bool Integracao()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarCobrancasRegistradasPorCpfOuMesDeReferencia(string cpf, byte mesDeReferencia)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
