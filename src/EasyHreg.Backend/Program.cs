using EasyHreg.Backend.Services;
using EasyHreg.Backend.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PdfService>();
builder.Services.AddTransient<IDocumentService, FileService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IDatabaseService, ExcelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
