using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPU911.DAL;
using SPU911.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPU911
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddControllersWithViews();
            //_ = services.AddScoped<IProducControllerService, ProductService>();
            //_ = services.AddScoped<IHomeControllerProductService, ProductService>();

            //services.AddSingleton<IProductCommonService, ProductService>();

            services.AddScoped<IWishListService, WishListService>();
            services.AddScoped<IProducControllerService, ProductService>();
            services.AddScoped<IHomeControllerProductService, ProductService>();
            services.AddScoped<IWishListProducts, ProductService>();

            var blobConnectionString = Configuration.GetConnectionString("BlobStorageConnection");
            services.AddSingleton(x => new BlobServiceClient(blobConnectionString));
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageDALService, ImageDALService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "blog",
                //    pattern: "admin/{article?}",
                //    defaults: new { controller = "test", action = "index" }
                //    );
            });
        }
    }
}
