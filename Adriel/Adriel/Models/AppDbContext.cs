using Microsoft.EntityFrameworkCore;

namespace Adriel.Models;

//Classe que representa o EF dentro do projeto
public class AppDbContext : DbContext
{
    //Classes que vão representar as tabelas
    //no banco de dados
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Folha> Folhas { get; set; }

    //Configurando qual o banco de dados vai
    //ser utilizado
    //Configurando a string de conexão
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Adriel.db");
    }
}