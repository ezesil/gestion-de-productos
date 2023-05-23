using System;
using GestionDeProductos.Business.Interfaces;
using GestionDeProductos.Business.Services;
using GestionDeProductos.Business.Uow;
using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.DataAccess.Repository.Sql;
using GestionDeProductos.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GestionDeProductos.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddSingleton<IGenericRepository<Producto>, ProductoRepository>();
            builder.Services.AddSingleton<IGenericRepository<Operacion>, OperacionRepository>();
            builder.Services.AddSingleton<IDepositoRepository, DepositoRepository>();
            builder.Services.AddSingleton<ITiendaRepository, TiendaRepository>();

            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IGenericService<Producto>, ProductoService>();
            builder.Services.AddScoped<IGenericService<Operacion>, OperacionService>();
            builder.Services.AddScoped<IDepositoService, DepositoService>();
            builder.Services.AddScoped<ITiendaService, TiendaService>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.MetadataAddress = Environment.GetEnvironmentVariable("kc_address");
                o.Authority = Environment.GetEnvironmentVariable("kc_authority");
                o.Audience = Environment.GetEnvironmentVariable("kc_audience");
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
        }
    }
}