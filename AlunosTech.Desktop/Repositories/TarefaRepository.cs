
using AlunosTech.Desktop.Models;

namespace AlunosTech.Desktop.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly List<Tarefa> _tarefas = new()
    {
        new Tarefa
        {
            TarefaId = 1,
            ProjetoId = 1,
            Titulo = "Levantamento de requisitos",
            HorasEstimadas = 16
        },
        new Tarefa
        {
            TarefaId = 2,
            ProjetoId = 1,
            Titulo = "Planejamento da primeira sprint",
            HorasEstimadas = 8
        }
    };

    public List<Tarefa> Listar()
    {
        return _tarefas.ToList();
    }

    public void AtualizarStatus(int tarefaId, string novoStatus)
    {
        Tarefa? tarefa = _tarefas.FirstOrDefault(
            t => t.TarefaId == tarefaId
        );

        if (tarefa == null)
        {
            throw new ArgumentException("Tarefa não encontrada.");
        }

        tarefa.AtualizarStatus(novoStatus);
    }
}
