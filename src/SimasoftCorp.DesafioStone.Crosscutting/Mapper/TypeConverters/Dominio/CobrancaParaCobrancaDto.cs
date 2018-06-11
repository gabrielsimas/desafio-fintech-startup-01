using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Dominio
{
    public class CobrancaParaCobrancaDto : ITypeConverter<Cobranca, CobrancaDto>
    {
        public CobrancaDto Convert(Cobranca source, CobrancaDto destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = new CobrancaDto()
            {
                Cpf = source.Cliente.Cpf.Numero.ToString(),
                DataDeVencimento = source.DataDeVencimento.DataContabil,
                Valor = source.Valor
            };

            return destination;
        }
    }
}