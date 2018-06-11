using AutoMapper;
using SimasoftCorp.DesafioStone.Dominio.Financeiro;
using SimasoftCorp.DesafioStone.Infraestrutura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Crosscutting.Mapper.TypeConverters.Dominio
{
    public class CobrancaParaClCobranca : ITypeConverter<Cobranca, ClCobranca>
    {
        public ClCobranca Convert(Cobranca source, ClCobranca destination, ResolutionContext context)
        {
            if (source == null) return null;
            destination = new ClCobranca()
            {
                Cpf = source.Cliente != null ?  source.Cliente.Cpf.Numero.ToString() : null,
                DataDeVencimento = source.DataDeVencimento.DataContabil,
                Valor = source.Valor                
            };

            return destination;
        }
    }
}
