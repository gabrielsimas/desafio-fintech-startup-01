using AutoMapper;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;
using System;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Repositorio
{
    public class ClCobrancaParaCobranca : ITypeConverter<ClCobranca, Cobranca>
    {
        public Cobranca Convert(ClCobranca source, Cobranca destination, ResolutionContext context)
        {
            if (source == null) return null;
            destination = Cobranca.NovaCobranca(source.Valor, Data.Nova(source.DataDeVencimento), Cliente.NovoClienteApenasComCpf(Cpf.Novo(source.Cpf)));

            return destination;
        }
    }
}
