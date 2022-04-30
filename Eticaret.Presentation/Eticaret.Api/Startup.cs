using Eticaret.Business.Helpers;
using Eticaret.Business.Services;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eticaret.Api", Version = "v1" });
            });

            services.AddScoped<ICookieHelper, CookieHelper>();
            services.AddScoped<IStringHelper, StringHelper>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddScoped<IUserTokenService, UserTokenService>();
            services.AddScoped<IUserTokenDal, UserTokenDal>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, CategoryDal>();

            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderDal, SliderDal>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, ProductDal>();

            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductImageDal, ProductImageDal>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDal, OrderDal>();

            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddSingleton<IMemoryCache, MemoryCache>();//using Microsoft.Extensions.Caching.Memory;();//-------------------------------------------------buuuu
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eticaret.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
            });
        }
    }
}
