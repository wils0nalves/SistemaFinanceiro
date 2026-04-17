using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Data;

using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Data;
using SistemaFinanceiro.Models;
using System.Linq;

namespace SistemaFinanceiro.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? dataInicio, DateTime? dataFim, string status)
        {
            var query = _context.Requisicoes.AsQueryable();

            if (dataInicio.HasValue)
                query = query.Where(r => r.Data >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(r => r.Data <= dataFim.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(r => r.Status == status);

            var lista = query.ToList();

            ViewBag.Total = lista.Sum(r => r.Valor);

            return View(lista);
        }
    }
}