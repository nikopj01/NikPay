using MassTransit;
using Microsoft.OpenApi.Models;
using Payment.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment.API", Version = "v1" });
});
builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration.GetValue<string>("EventBusSettings:HostAddress"));
    });
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

var app = builder.Build();
var env = builder.Environment;
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment.API v1"));
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
