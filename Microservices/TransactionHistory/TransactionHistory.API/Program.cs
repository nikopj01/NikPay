using EventBus.Common;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TransactionHistory.API;
using TransactionHistory.API.EventBusConsumer;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TransactionHistory.API", Version = "v1" });
});
builder.Services.AddAuthentication("Bearer")
 .AddJwtBearer("Bearer", options =>
     {
     options.Authority = "https://localhost:5005";
     options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateAudience = false
         };
     });

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config => {
    config.AddConsumer<AddPaymentConsumer>();
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration.GetValue<string>("EventBusSettings:HostAddress"));
        //cfg.UseHealthCheck(ctx);
        cfg.ReceiveEndpoint(EventBusContants.AddPaymentQueue, c => {
            c.ConfigureConsumer<AddPaymentConsumer>(ctx);
        });
    });
});
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<AddPaymentConsumer>();

//Auto Mapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();

var app = builder.Build();
var env = builder.Environment;
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "History.API v1"));
}
// Configure the HTTP request pipeline.
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
