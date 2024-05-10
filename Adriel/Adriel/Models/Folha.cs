namespace Adriel.Models;

public class Folha
{


    public Folha()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Folha
        (Double valor, Double quantidade, String mes, String ano)
    {
        this.Funcionarios = new HashSet<Funcionario>();

        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        Id = Guid.NewGuid().ToString();

    }
    

  
    public string? Id { get; set; }
    public HashSet<Funcionario> Funcionarios { get; }
    public Double? Valor { get; set; }
    public Double? Quantidade { get; set; }
    public String? Mes { get; set; }
    public String? Ano { get; set; }
    public Double? SalarioBruto { get; set; }
    public Double? ImpostoIrrf { get; set; }
    public Double? ImpostoInss { get; set; }
    public Double? ImpostoFgts { get; set; }
    public Double? SalarioLiquido { get; set; }
    
}