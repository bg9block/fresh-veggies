using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ShoppingCart.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(new List<Assembly>() {Assembly.GetAssembly(typeof(Startup))});
            
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IVoucherService), typeof(VoucherService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            services.AddDbContext<ProductContext>();
            services.AddDbContext<OrderContext>();
            services.AddDbContext<VoucherContext>();
            services.AddDbContext<ShoppingCartContext>();
            services.AddDbContext<OrderProductContext>();
            
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IVoucherRepository), typeof(VoucherRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Shopping Cart API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
        
        
    }
}