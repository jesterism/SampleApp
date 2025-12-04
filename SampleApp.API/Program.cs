using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UsersMemoryRepository>(); // Добавьте эту строку

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); 

    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "SampleApp",
            Version = "v1",
            Description = "API для пользователей",
            Contact = new OpenApiContact
            {
                Url = new Uri("https://github.com/staslesogorov/sampleapp"),
                Email = "14ib233@prep.scc",
            },
        }
    );
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

