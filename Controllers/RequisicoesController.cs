using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaFinanceiro.Data;
using SistemaFinanceiro.Models;

namespace SistemaFinanceiro.Controllers
{
    public class RequisicoesController : Controller
    {
        private readonly AppDbContext _context;

        public RequisicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Requisicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requisicoes.ToListAsync());
        }

        // GET: Requisicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // GET: Requisicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requisicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Valor,Data,Status")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requisicao);
        }

        // GET: Requisicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicoes.FindAsync(id);
            if (requisicao == null)
            {
                return NotFound();
            }
            return View(requisicao);
        }

        // POST: Requisicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor,Data,Status")] Requisicao requisicao)
        {
            if (id != requisicao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicaoExists(requisicao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(requisicao);
        }

        // GET: Requisicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicao = await _context.Requisicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requisicao == null)
            {
                return NotFound();
            }

            return View(requisicao);
        }

        // POST: Requisicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicao = await _context.Requisicoes.FindAsync(id);
            if (requisicao != null)
            {
                _context.Requisicoes.Remove(requisicao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicaoExists(int id)
        {
            return _context.Requisicoes.Any(e => e.Id == id);
        }
    }
}
