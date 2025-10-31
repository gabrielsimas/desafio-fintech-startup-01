namespace Simasoft.Desafios.Fintech.Tdd.Comum
{
    public class CalculadoraPlr
    {
        private readonly Funcionario _funcionario;
        private const int MesesDoAno = 12;

        public CalculadoraPlr(Funcionario funcionario)
        {
            _funcionario = funcionario;
        }

        public double Calcular()
        {
            var pesoPorArea = PesoPorArea();
            var pesoPorFaixaSalarial = PesoPorFaixaSalarial();
            var pesoPorTempoAdmissao = PesoPorTempoAdmissao();

            if (pesoPorFaixaSalarial == 0)
                return 0;

            var bonus = ((_funcionario.SalarioBruto * pesoPorTempoAdmissao) + (_funcionario.SalarioBruto * pesoPorArea)) / pesoPorFaixaSalarial;
            return bonus * MesesDoAno;
        }

        private int PesoPorArea()
        {
            return _funcionario.Area switch
            {
                "Diretoria" => 1,
                "Contabilidade" => 2,
                "Financeiro" => 2,
                "Tecnologia" => 2,
                "Serviços Gerais" => 3,
                "Relacionamento com o Cliente" => 5,
                _ => 0
            };
        }

        private int PesoPorFaixaSalarial()
        {
            if (_funcionario.Cargo == "Estagiário")
                return 1;

            var faixaSalarial = _funcionario.FaixaSalarial;

            if (faixaSalarial > 8) return 5;
            if (faixaSalarial > 5) return 3;
            if (faixaSalarial > 3) return 2;
            return 1;
        }

        private int PesoPorTempoAdmissao()
        {
            var tempoDeCasa = _funcionario.TempoAdmissao;
            if (tempoDeCasa >= 8) return 5;
            if (tempoDeCasa >= 3) return 3;
            if (tempoDeCasa > 1) return 2;
            return 1;
        }
    }
}