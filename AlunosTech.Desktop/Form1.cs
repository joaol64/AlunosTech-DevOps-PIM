
using AlunosTech.Desktop.Repositories;
using AlunosTech.Desktop.Services;

namespace AlunosTech.Desktop;

public partial class Form1 : Form
{
    private readonly TarefaService _service;

    private readonly DataGridView tabela = new();
    private readonly ComboBox comboStatus = new();
    private readonly Button botaoAtualizar = new();

    public Form1()
    {
        InitializeComponent();

        _service = new TarefaService(new TarefaRepository());

        ConfigurarInterface();
        CarregarTarefas();
    }

    private void ConfigurarInterface()
    {
        Text = "Alunos Tech - Gerenciamento de Tarefas";
        Size = new Size(850, 480);
        StartPosition = FormStartPosition.CenterScreen;

        var titulo = new Label
        {
            Text = "Alunos Tech - Painel de Tarefas",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Location = new Point(20, 20),
            AutoSize = true
        };

        tabela.Location = new Point(20, 75);
        tabela.Size = new Size(790, 270);
        tabela.ReadOnly = true;
        tabela.AllowUserToAddRows = false;
        tabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabela.MultiSelect = false;
        tabela.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        comboStatus.Location = new Point(20, 365);
        comboStatus.Size = new Size(190, 30);
        comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        comboStatus.Items.AddRange(new[]
        {
            "Backlog",
            "EmAndamento",
            "Concluida"
        });
        comboStatus.SelectedIndex = 0;

        botaoAtualizar.Text = "Atualizar Status";
        botaoAtualizar.Location = new Point(230, 365);
        botaoAtualizar.Size = new Size(150, 30);
        botaoAtualizar.Click += AtualizarStatus;

        Controls.Add(titulo);
        Controls.Add(tabela);
        Controls.Add(comboStatus);
        Controls.Add(botaoAtualizar);
    }

    private void CarregarTarefas()
    {
        tabela.DataSource = null;
        tabela.DataSource = _service.ListarTarefas();

        tabela.Columns["TarefaId"].HeaderText = "ID";
        tabela.Columns["Titulo"].HeaderText = "Tarefa";
        tabela.Columns["HorasEstimadas"].HeaderText = "Horas";
        tabela.Columns["Status"].HeaderText = "Status";

        tabela.Columns["ProjetoId"].Visible = false;
        tabela.Columns["ColaboradorId"].Visible = false;

        tabela.Columns["Titulo"].FillWeight = 55;
        tabela.Columns["TarefaId"].FillWeight = 10;
        tabela.Columns["HorasEstimadas"].FillWeight = 15;
        tabela.Columns["Status"].FillWeight = 20;
    }

    private void AtualizarStatus(object? sender, EventArgs e)
    {
        if (tabela.CurrentRow == null)
        {
            MessageBox.Show("Selecione uma tarefa.");
            return;
        }

        int tarefaId = Convert.ToInt32(
            tabela.CurrentRow.Cells["TarefaId"].Value
        );

        string novoStatus = comboStatus.SelectedItem!.ToString()!;

        try
        {
            _service.AtualizarStatus(tarefaId, novoStatus);
            CarregarTarefas();

            MessageBox.Show("Status atualizado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
