
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
    Results.Ok(new
    {
        Sistema = "Alunos Tech",
        Modulo = "API Corporativa",
        Status = "Online"
    })
);

app.MapGet("/health", () =>
    Results.Ok(new
    {
        Status = "Healthy"
    })
);

app.Run();
