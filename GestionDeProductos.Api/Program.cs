using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
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

            builder.Services.AddCors(options =>
                options.AddPolicy("Policy_Name", builder =>
              builder.WithOrigins("https://*:7052/")
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyOrigin())
            );

            WarmupDbConn();

            builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(Environment.GetEnvironmentVariable("mssql_connstring")));
         
            builder.Services.AddScoped<IRepository<Log>, LogRepository>();
            builder.Services.AddScoped<ILogService, LogService>();

            builder.Services.AddScoped<IRepository<Producto>, ProductRepository>();
            builder.Services.AddScoped<IRepository<Deposito>, DepositoRepository>();
            builder.Services.AddScoped<IRepository<ProductoTienda>, ProductoXTiendaRepository>();
            builder.Services.AddScoped<IRepository<ProductoDeposito>, ProductoXDepositoRepository>();
            builder.Services.AddScoped<IRepository<Operacion>, OperacionRepository>();
            builder.Services.AddScoped<IRepository<Tienda>, TiendaRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            app.UseCors("Policy_Name");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();                   
        }

        static void WarmupDbConn()
        {
            string connectionString = Environment.GetEnvironmentVariable("mssql_connstring");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT @@version";
                string version = connection.ExecuteScalar<string>(sql);

                Console.WriteLine($"SQL Server version {version} conectado.");
            }
        }
    }
}