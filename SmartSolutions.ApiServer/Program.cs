using SmartSolutions.ApiServer.DataStore;
using SmartSolutions.ApiServer.DataStore.Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }));
builder.Services.AddScoped<SmartSolutions.ApiServer.DataStore.Repository.IRepository, EFRepository<ApplicationDbContext>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(name: "v1", info: new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SmartSolutions Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint(url: "/Swagger/v1/Swagger.json", name: "SmartSolutions API v1"); });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

