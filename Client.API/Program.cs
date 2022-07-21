using Client.Domain.ClientContext;
using System.Reflection;
using MediatR;
using AutoMapper;
using Client.Repository.ClientContext;
using Client.Domain.SharedContext;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência dos commands
builder.Services.AddMediatR(typeof(GetAllClientsCommand).GetTypeInfo().Assembly);

// Injeção de dependênica do mapeamento
var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new AddressMapping());
    config.AddProfile(new ClientMapping());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Injeção de dependência do Utils
builder.Services.AddSingleton(new Util());

// Injeção de dependência do repositório
builder.Services.AddTransient<IClientRepository, ClientRepository>();

// configuração para compactação de json de retorno
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;

});
builder.Services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);

// Configuração para remover atributos nulos do retorno
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.WriteIndented = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
