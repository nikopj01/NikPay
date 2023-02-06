using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TransactionHistory.API;

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
