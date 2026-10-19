using dotnetbackend.Contexts;
using dotnetbackend.Endpoints;
using dotnetbackend.Services;
using dotnetbackend.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IService, Service>();
builder.Services.RegisterValidators();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.RegisterEndpoints();
app.Run();
