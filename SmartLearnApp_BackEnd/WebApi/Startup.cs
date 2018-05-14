using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApi.Contracts;
//using FluentScheduler;

namespace WebApi
{
    [UsedImplicitly]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Settings settings = new Settings(Configuration);

            services.AddSingleton<IDalSettings>(settings);
            services.AddSingleton<IWebApiSettings>(settings);

            DalModule.Register(services);
            BlModule.Register(services);
            WebApiModule.Register(services);

            Mapper.Initialize(config =>
                {
                    DalMappings.Initialize(config);
                    BlMappings.Initialize(config);
                    WebApiMappings.Initialize(config);
                });

            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims

            services
                .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                    })
                .AddJwtBearer(cfg =>
                    {
                        cfg.RequireHttpsMetadata = false;
                        cfg.SaveToken = true;

                        cfg.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidIssuer = settings.JwtIssuer,
                                ValidAudience = settings.JwtIssuer,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtKey)),
                                ClockSkew = TimeSpan.Zero // remove delay of token when expire
                            };
                    });

            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            // ===== Use Authentication ======
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
