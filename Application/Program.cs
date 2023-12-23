using Application.Helpers.Extensions;
using Application.Middlewares;
using Base.Application.Middlewares;
using Microsoft.EntityFrameworkCore;
using Core;
using Application.Helpers;
using Infrastructure.SignalRHub;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
#region Services
services.AddEndpointsApiExplorer();

services.AddCors(options => { 
    options.AddPolicy("AllowAll", 
        b => { 
            b.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default"),
        npgsqlOptions =>
        {
            npgsqlOptions.MigrationsAssembly("Application");
        });
});

services.AddSignalR();
services.SwaggerConfig();
services.JwtConfig(builder.Configuration);
services.AddAutoMapper(typeof(DataMapping));
services.AddMemoryCache(); 
#endregion
var app = builder.Build();
#region App
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Base Core V3.3"); 
});
app.UseCors("AllowAll"); 
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapHub<SignalrHub>("/chat");
app.RouterDefinition();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();
#endregion