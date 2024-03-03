using Microsoft.EntityFrameworkCore;
using AgendamentoTarefasMVC.Models;

namespace AgendamentoTarefasMVC.Context;

public class ContextTarefa(DbContextOptions<ContextTarefa> options) : DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
}