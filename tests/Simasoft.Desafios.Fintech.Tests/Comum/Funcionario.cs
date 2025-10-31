namespace Simasoft.Desafios.Fintech.Tdd.Comum;

public sealed class Funcionario
{
    private const double SalarioMinimo = 1518.00;

    private Funcionario(string matricula, string nome, string area, string cargo, double salarioBruto, DateOnly dataAdmissao)
    {
        Matricula = matricula;
        Nome = nome;
        Area = area;
        Cargo = cargo;
        SalarioBruto = salarioBruto;
        DataAdmissao = dataAdmissao;
    }

    public string Matricula { get; private set; }
    public string Nome { get; private set; }
    public string Area { get; private set; }
    public string Cargo { get; private set; }
    public double SalarioBruto { get; private set; }
    public DateOnly DataAdmissao { get; private set; }
    public double FaixaSalarial { get => SalarioBruto / SalarioMinimo; }
    public int TempoAdmissao
    {
        get
        {
            var hoje = DateOnly.FromDateTime(DateTime.Today);
            int tempo = hoje.Year - DataAdmissao.Year;
            if (DataAdmissao.DayOfYear > hoje.DayOfYear)
            {
                tempo--;
            }
            return tempo;
        }
    }
    public static Funcionario Criar(string matricula, string nome, string area, string cargo, double salarioBruto, DateOnly dataAdmissao)
    {
        if (string.IsNullOrWhiteSpace(matricula)) throw new ArgumentNullException(nameof(matricula));
        if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
        if (string.IsNullOrWhiteSpace(area)) throw new ArgumentNullException(nameof(area));
        if (string.IsNullOrWhiteSpace(cargo)) throw new ArgumentNullException(nameof(cargo));
        if (salarioBruto <= 0) throw new ArgumentOutOfRangeException(nameof(salarioBruto));
        if (dataAdmissao > DateOnly.FromDateTime(DateTime.Today)) throw new ArgumentOutOfRangeException(nameof(dataAdmissao));

        return new(matricula, nome, area, cargo, salarioBruto, dataAdmissao);
    }
}
