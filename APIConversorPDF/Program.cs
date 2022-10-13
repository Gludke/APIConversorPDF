using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//necessário fazer este registro para usar codificações diferentes dos padrões do .NET
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
