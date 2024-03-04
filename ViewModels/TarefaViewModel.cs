using AgendamentoTarefasMVC.Models;

namespace AgendamentoTarefasMVC.ViewModels;

public class TarefaViewModel
{
    public IEnumerable<Tarefa> Tarefas { get; set; }
    public string Titulo { get; set; }
    public DateTime? DataIni { get; set; }
    public DateTime? DataFim { get; set; }
    public StatusTarefa? Status { get; set; }
}