
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TrialA.App_Context;
using TrialA.Mapping;
using TrialA.Repo;

namespace TrialA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitWork, UniOfWork>();
            builder.Services.AddScoped<IAuthrepo,Authrepo>();
            builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenariceRepo<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IJopRepo,JopRepo>();
            builder.Services.AddScoped<IApplicationsrepo, ApplicationRepo>();
            builder.Services.AddScoped<ICompany, CompanyRepo>();
            var kye = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!);
            builder.Services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(a =>
                
            {
                a.RequireHttpsMetadata = false;
                a.SaveToken = true;
                a.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(kye)
                };
            }
            );
            builder.Services.AddDbContext<AppDbContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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
