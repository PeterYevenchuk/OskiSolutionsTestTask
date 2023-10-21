using OskiFSPY.Core;
using OskiFSPY.WebAPI;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

ServiceConfiguration.ConfigureServices(builder.Services, configuration);
CoreServiceConfiguration.ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();