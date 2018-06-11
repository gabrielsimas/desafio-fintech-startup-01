using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimasoftCorp.DesafioStone.Infraestrutura.Entidades
{
    [Serializable]
    public class ClCobranca
    {
        [BsonElement("cpf")]
        public string Cpf { get; set; }
        
        [BsonElement("valor")]
        public decimal Valor { get; set; }

        [BsonElement("datavencimento")]
        public DateTime DataDeVencimento { get; set; }
    }
}
