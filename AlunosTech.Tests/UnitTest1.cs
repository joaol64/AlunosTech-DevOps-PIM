
using AlunosTech.Desktop.Models;
using Xunit;

namespace AlunosTech.Tests;

public class TarefaTests
{
    [Fact]
    public void AtualizarStatus_ComStatusValido_DeveAtualizar()
    {
        var tarefa = new Tarefa
        {
            TarefaId = 1,
            Titulo = "Levantamento de requisitos",
            HorasEstimadas = 16
        };

        tarefa.AtualizarStatus("EmAndamento");

        Assert.Equal("EmAndamento", tarefa.Status);
    }

    [Fact]
    public void AtualizarStatus_ComStatusInvalido_DeveGerarErro()
    {
        var tarefa = new Tarefa
        {
            TarefaId = 2,
            Titulo = "Planejamento da primeira sprint",
            HorasEstimadas = 8
        };

        Assert.Throws<ArgumentException>(() =>
            tarefa.AtualizarStatus("Cancelada")
        );
    }
}
