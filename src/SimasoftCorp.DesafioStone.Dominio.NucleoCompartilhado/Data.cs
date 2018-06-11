using SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado.Comum;
using System;

namespace SimasoftCorp.DesafioStone.Dominio.NucleoCompartilhado
{
    public sealed class Data : ObjetoDeValor<Data>
    {        

        public DateTime DataContabil { get; }
        public string CompetenciaMesAno { get;}
        public int CompetenciaMes { get; }
        public int CompetenciaAno { get; }

        private Data(DateTime data)
        {
            DataContabil = data;
            CompetenciaMesAno = string.Format("{0}/{1}", data.Month.ToString(), data.Year.ToString());
            CompetenciaAno = data.Year;
            CompetenciaMes = data.Month;
        }

        public static Data Nova(DateTime data)
        {
            if (data == DateTime.MinValue) throw new InvalidOperationException("A data é obrigatória");

            return new Data(data);
        }          

        public static Data Hoje()
        {
            return new Data(DateTime.Now);
        }
        protected override bool EqualsCore(Data other)
        {
            return DataContabil == other.DataContabil;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = DataContabil.GetHashCode();

                return hashCode;                
            }
        }
    }
}
