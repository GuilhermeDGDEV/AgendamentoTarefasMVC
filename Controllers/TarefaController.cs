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
}