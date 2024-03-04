using System.ComponentModel.DataAnnotations;

namespace AgendamentoTarefasMVC.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public StatusTarefa Status { get; set; }
}