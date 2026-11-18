
using AlunosTech.Desktop.Models;

namespace AlunosTech.Desktop.Repositories;

public interface ITarefaRepository
{
    List<Tarefa> Listar();
    void AtualizarStatus(int tarefaId, string novoStatus);
}
