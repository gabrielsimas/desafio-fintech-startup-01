using System;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado.Comum;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using System.Collections.Generic;
using System.Linq;

namespace SimasoftCorp.DesafioStone.Dominio.Financeiro
{
    //TODO:Utilizar Builder ao invés de Factory para o Construtor da Classe de Domínio
    public class Cliente: Entidade
    {
        private readonly Cpf cpf;
        private readonly Nome nome;
        private readonly Uf estado;
        private readonly List<Cobranca> cobrancas = new List<Cobranca>();

        public decimal Consumo
        {
            get
            {
                string inicioCPF = cpf.Numero.ToString("00000000000").Substring(0, 2);
                string fimCPF = cpf.Numero.ToString("00000000000").Substring(cpf.Numero.ToString("00000000000").Length - 2);
                return decimal.Parse(inicioCPF + fimCPF);
            }
        }

        public Cpf Cpf { get { return cpf; }}
        public Nome Nome { get { return nome; } }
        public Uf Estado { get { return estado; } }        
        public List<Cobranca> Cobrancas { get { return cobrancas; } }

        private Cliente(Cpf cpf, Nome nome, Uf estado, List<Cobranca> cobrancas)
        {            
            this.cpf = cpf;
            this.nome = nome;
            this.estado = estado;
            this.cobrancas = cobrancas;
        }

        private Cliente(Cpf cpf, Nome nome, Uf estado)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.estado = estado;
        }

        private Cliente(Cpf cpf)
        {
            this.cpf = cpf;
        }

        private Cliente(Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException("É preciso um objeto Cliente");
            if (cliente.cobrancas != null && cliente.cobrancas.Count > 0 )
            {
                NovoCliente(cliente.Cpf, cliente.Nome, cliente.Estado,cliente.Cobrancas);
            }
            else
            {
                NovoCliente(cliente.Cpf, cliente.Nome, cliente.Estado);
            }            
        }

        public static Cliente NovoCliente(Cpf cpf, Nome nome, Uf estado) => (new Cliente(cpf, nome, estado));
        public static Cliente NovoCliente(Cpf cpf, Nome nome, Uf estado, List<Cobranca> cobrancas) => (new Cliente(cpf, nome, estado, cobrancas));        
        public static Cliente NovoClienteApenasComCpf(Cpf cpf) => (new Cliente(cpf));

        public void AdicionarCobranca(Cobranca cobranca)
        {
            cobrancas.Add(cobranca);
        }

        public void AdicionarCobrancas(List<Cobranca> cobrancas)
        {
            if (cobrancas == null && cobrancas.Count == 0) throw new ArgumentNullException("Não é possível adicionar cobranças não existentes!");
            this.cobrancas.AddRange(cobrancas);
        }
               
        public void RemoverCobranca(Cobranca cobranca)
        {
            cobrancas.Remove(cobranca);
        }
        
        public decimal TotalizarCobrancas()
        {
            return cobrancas.Sum(x => x.Valor);
        }                      
    }
}
