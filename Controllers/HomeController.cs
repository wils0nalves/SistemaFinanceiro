using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Models;
using SistemaFinanceiro.Data;
using System.Linq;

namespace SistemaFinanceiro.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var totalRequisicoes = _context.Requisicoes.Count();

        var saldo = _context.Requisicoes
            .Where(r => r.Status == "Aprovado")
            .Sum(r => (decimal?)r.Valor) ?? 0;

        var movimentacoes = _context.Requisicoes.Count();

        ViewBag.TotalRequisicoes = totalRequisicoes;
        ViewBag.Saldo = saldo;
        ViewBag.Movimentacoes = movimentacoes;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}