using System.ComponentModel.DataAnnotations;
using Adriel.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();


//GET: http://localhost:5000
app.MapGet("/", () => "Minha primeira API em C# com watch");


//GET: http://localhost:5000/api/funcionario/listar
app.MapGet("/api/funcionario/listar",
    ([FromServices] AppDbContext ctx) =>
{
    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});

    //POST: http://localhost:5000/api/funcionario/cadastrar
app.MapPost("/api/funcionario/cadastrar",
    ([FromBody] Funcionario funcionario,
    [FromServices] AppDbContext ctx) =>
{
   
    List<ValidationResult> erros = new
        List<ValidationResult>();
    if(!Validator.TryValidateObject(
        funcionario, new ValidationContext(funcionario),
        erros, true))
    {
        return Results.BadRequest(erros);
    }

 
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

//GET: http://localhost:5000/api/funcionario/buscar/id_do_funcionario
app.MapGet("/api/funcionario/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDbContext ctx) =>
{
   
    Funcionario? funcionario =
        ctx.Funcionarios.FirstOrDefault(x => x.Id == id);
    if (funcionario is null)
    {
        return Results.NotFound("Funcionario não encontrado!");
    }
    return Results.Ok(funcionario);
});

//GET: http://localhost:5000/api/folha/listar
app.MapGet("/api/folha/listar",
    ([FromServices] AppDbContext ctx) =>
{
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound("Tabela vazia!");
});


  //POST: http://localhost:5000/api/folha/cadastrar
app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, Double salaralioLiquido, Double valor, Double quantidade, Double salarioBruto, Double impostoInss, Double impostoIrrf, Double impostoFgts,[FromServices] AppDbContext ctx) =>
{
    salarioBruto = valor * quantidade;
    Double impostoRenda = impostoInss + impostoIrrf;

    if (salarioBruto >= 1903.08 && salarioBruto <= 2826.65)
    {
        salarioBruto -= 142.80;
    }else if (salarioBruto >= 2826.66 && salarioBruto <= 3751.05)
    {
        salarioBruto -= 354.80;
    }else if (salarioBruto >= 3751.06 && salarioBruto <= 4664.68)
    {
        salarioBruto -= 636.13;
    }else if (salarioBruto > 4664.68)
    {
        salarioBruto -= 869.36;
    }
    
    if (salarioBruto <= 1693.72)
    {
        impostoInss -= impostoInss * 0.08;
    }else if (salarioBruto >= 1693.72 && salarioBruto <= 2822.90)
    {
        impostoInss -= impostoInss * 0.09;
    }else if (salarioBruto >= 2822.91 && salarioBruto <= 5645.80)
    {
        impostoInss -= impostoInss * 0.11;
    }else if (salarioBruto > 5645.81)
    {
        impostoInss -= 621.03;
    }

    impostoInss -= salarioBruto + 0.08; 
    salaralioLiquido = impostoRenda - salarioBruto - impostoInss;

    List<ValidationResult> erros = new
        List<ValidationResult>();
    if(!Validator.TryValidateObject(
        folha, new ValidationContext(folha),
        erros, true))

    {
        return Results.BadRequest(erros);
    }

 
    ctx.Folhas.Add(folha);
    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});


//GET: http://localhost:5000/api/folha/buscar/id_do_folha
app.MapGet("/api/folha/buscar/{id}", ([FromRoute] string id,
    [FromServices] AppDbContext ctx) =>
{

    Folha? folha =
        ctx.Folhas.FirstOrDefault(x => x.Id == id);
    if (folha is null)
    {
        return Results.NotFound("Folha não encontrado!");
    }
    return Results.Ok(folha);
});

app.Run();









