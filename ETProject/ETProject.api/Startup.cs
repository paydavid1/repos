using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ETProject.api.Features.Categorys;
using ETProject.api.Features.Interfaces;
using ETProject.api.Features.Transactions;
using ETProject.api.Features.Users;
using ETProject.api.Helpers;
using ETProject.api.Persistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ETProject.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services){
            services.AddDbContext<ETDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }, ServiceLifetime.Scoped);

                ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services){
            services.AddDbContext<ETDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }, ServiceLifetime.Scoped);

                ConfigureServices(services);
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            

            services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped(typeof(ICategoryRepository),typeof(CategoryRepository)); 
            services.AddScoped(typeof(IAuthRepository),typeof(AuthRepository)); 
            services.AddScoped(typeof(ITransactionRepository),typeof(TransactionRepository)); 
            services.AddScoped(typeof(CategoryAppServices)); 
            services.AddScoped(typeof(AuthAppServices));
            services.AddScoped(typeof(TransactionAppServices));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else{
                // app.UseExceptionHandler(builder => {
                //     builder.Run(async context => {
                //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //         var error = context.Features.Get<IExceptionHandlerFeature>();
                //         if (error != null)
                //         {
                //             context.Response.AddApplicationError(error.Error.Message);
                //             await context.Response.WriteAsync(error.Error.Message);
                //         }  
                //     });
                // });
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index","Fallback");
            });
        }
    }
}
