namespace Adriel.Models;

public class Funcionario
{

    //Construtores
    public Funcionario()
    {
        Id = Guid.NewGuid().ToString();
    }

    public Funcionario
        (string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        Id = Guid.NewGuid().ToString();

    }

    //Características - Atributos e propriedades
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    
}