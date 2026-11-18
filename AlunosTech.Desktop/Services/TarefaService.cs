
using AlunosTech.Desktop.Models;
using AlunosTech.Desktop.Repositories;

namespace AlunosTech.Desktop.Services;

public class TarefaService
{
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public List<Tarefa> ListarTarefas()
    {
        return _repository.Listar();
    }

    public void AtualizarStatus(int tarefaId, string novoStatus)
    {
        _repository.AtualizarStatus(tarefaId, novoStatus);
    }
}
