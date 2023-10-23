using FluentAssertions.Common;
using OskiFSPY.Core;
using OskiFSPY.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

ServiceConfiguration.ConfigureServices(builder.Services, configuration);
CoreServiceConfiguration.ConfigureServices(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();