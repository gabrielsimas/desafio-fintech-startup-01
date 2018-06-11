using System;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado.Comum;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;

namespace SimasoftCorp.DesafioStone.Dominio.Financeiro
{    
    public class Cobranca : Entidade
    {
        public enum TipoCompetencia {MesAno,Mes,Ano }

        private readonly Data dataDeVencimento;        
        private readonly decimal valor;
        private readonly Cliente cliente;

        public Data DataDeVencimento { get { return dataDeVencimento; } } 
        public decimal Valor { get { return valor; } }
        public Cliente Cliente { get { return cliente; } }


        private Cobranca() { }

        private Cobranca(decimal valor, Data dataDeVencimento )
        {
            if (valor <= 0) throw new ArgumentException("O Valor da Cobrança deve ser positivo e maior do que zero!");
            if (dataDeVencimento.DataContabil == DateTime.MinValue) throw new ArgumentException("A data de vencimento da Cobrança não poder ser vazia!");
            this.valor = valor;
            this.dataDeVencimento = dataDeVencimento;
        }

        private Cobranca(decimal valor, Data dataDeVencimento, string cpf)
        {
            if (valor <= 0) throw new ArgumentException("O Valor da Cobrança deve ser positivo e maior do que zero!");
            if (dataDeVencimento.DataContabil == DateTime.MinValue) throw new ArgumentException("A data de vencimento da Cobrança não poder ser vazia!");
            if (string.IsNullOrEmpty(cpf)) throw new ArgumentNullException("A Cobrança precisa do Cpf do Cliente para ser corretamente registrada");            

            this.valor = valor;
            this.dataDeVencimento = dataDeVencimento;
            if (cliente == null)
            {
                cliente = Cliente.NovoClienteApenasComCpf(Cpf.Novo(cpf));
            }            
        }

        private Cobranca(decimal valor, Data dataDeVencimento, Cliente cliente)
        {
            if (valor <= 0) throw new ArgumentException("O Valor da Cobrança deve ser positivo e maior do que zero!");
            if (dataDeVencimento.DataContabil == DateTime.MinValue) throw new ArgumentException("A data de vencimento da Cobrança não poder ser vazia!");            
            if (cliente == null) throw new ArgumentNullException("É necessário um Cliente atrelado à Cobrança!");

            this.valor = valor;
            this.dataDeVencimento = dataDeVencimento;
            this.cliente = cliente;
        }
        
        public static Cobranca NovaCobranca(decimal valor,Data dataDeVencimento) => (new Cobranca(valor, dataDeVencimento));
        public static Cobranca NovaCobranca(decimal valor, Data dataDeVencimento, string cpf) => (new Cobranca(valor, dataDeVencimento, cpf));
        public static Cobranca NovaCobranca(decimal valor, Data dataDeVencimento, Cliente cliente) => (new Cobranca(valor, dataDeVencimento, cliente));
        
        public object SelecionaCompetencia(TipoCompetencia tipo)
        {
            switch (tipo)
            {
                case TipoCompetencia.MesAno:
                    return dataDeVencimento.CompetenciaMesAno;
                case TipoCompetencia.Ano:
                    return dataDeVencimento.CompetenciaAno;
                case TipoCompetencia.Mes:
                    return dataDeVencimento.CompetenciaMes;                                        
            }
            return null;
        }               
    }
}
