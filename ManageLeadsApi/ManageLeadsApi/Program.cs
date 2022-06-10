using ManageLeadsApp;
using ManageLeadsApp.Interfaces;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsApp.Mapper;
using ManageLeadsDomainCore.Interfaces.Repos;
using ManageLeadsDomainCore.Interfaces.Services;
using ManageLeadsDomainServices;
using ManageLeadsInfra.Data;
using ManageLeadsInfra.Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SqlContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepositoryLead, RepositoryLead>();
builder.Services.AddScoped<IApplicationServiceLead, ApplicationServiceLead>();
builder.Services.AddScoped<IServiceLead, ServiceLead>();
builder.Services.AddScoped<IServiceEmail, ServiceEmail>();
builder.Services.AddScoped<IMapperLead, MapperLead>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage Leads API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manage Leads API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
