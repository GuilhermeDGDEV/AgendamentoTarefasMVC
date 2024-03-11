using Microsoft.AspNetCore.Mvc;
using AgendamentoTarefasMVC.Models;
using AgendamentoTarefasMVC.Context;
using Microsoft.EntityFrameworkCore;
using AgendamentoTarefasMVC.ViewModels;

namespace AgendamentoTarefasMVC.Controllers;

public class TarefaController(ContextTarefa context) : Controller
{
    private readonly ContextTarefa _context = context;

    public async Task<IActionResult> Index(string Titulo, StatusTarefa? Status, DateTime? DataIni, DateTime? DataFim)
    {
        var model = new TarefaViewModel
        {
            Tarefas = await _context.Tarefas
            .Where(tarefa => (string.IsNullOrWhiteSpace(Titulo) || tarefa.Titulo.ToLower().Contains(Titulo.ToLower()))
                && (DataIni == null || tarefa.Data.Date >= DataIni)
                && (DataFim == null || tarefa.Data.Date <= DataFim)
                && (Status == null || tarefa.Status == Status)
                ).ToListAsync(),
            Titulo = Titulo,
            Status = Status,
            DataIni = DataIni,
            DataFim = DataFim
        };
        return View(model);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(tarefa);
    }

    public IActionResult Editar(int id)
    {
        var tarefa = _context.Tarefas.Find(id);

        if (tarefa == null)
            return RedirectToAction(nameof(Index));

        return View(tarefa);
    }

    [HttpPost]
    public IActionResult Editar(Tarefa tarefa)
    {
        var tarefaBanco = _context.Tarefas.Find(tarefa.Id);

        tarefaBanco.Titulo = tarefa.Titulo;
        tarefaBanco.Descricao = tarefa.Descricao;
        tarefaBanco.Data = tarefa.Data;
        tarefaBanco.Status = tarefa.Status;

        _context.Tarefas.Update(tarefaBanco);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Detalhes(int id)
    {
        var tarefa = _context.Tarefas.Find(id);

        if (tarefa == null)
            return RedirectToAction(nameof(Index));

        return View(tarefa);
    }

    public async Task<IActionResult> Deletar(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}