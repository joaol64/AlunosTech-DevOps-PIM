
namespace AlunosTech.Desktop.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public int ProjetoId { get; set; }
    public int? ColaboradorId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public decimal HorasEstimadas { get; set; }

    public string Status { get; private set; } = "Backlog";

    public void AtualizarStatus(string novoStatus)
    {
        string[] statusPermitidos =
        {
            "Backlog",
            "EmAndamento",
            "Concluida"
        };

        if (!statusPermitidos.Contains(novoStatus))
        {
            throw new ArgumentException(
                "Status inválido para a tarefa."
            );
        }

        Status = novoStatus;
    }
}
