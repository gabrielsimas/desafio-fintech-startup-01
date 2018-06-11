using AutoMapper;
using SimasoftCorp.DesafioStone.Aplicacao.Financeiro.Dtos;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Aplicacao
{
    public class CobrancaDtoParaCobranca : ITypeConverter<CobrancaDto, Cobranca>
    {
        public Cobranca Convert(CobrancaDto source, Cobranca destination, ResolutionContext context)
        {
            if (source == null) return null;

            destination = Cobranca.NovaCobranca(source.Valor, Data.Nova(source.DataDeVencimento), source.Cpf);

            return destination;

        }
    }
}
