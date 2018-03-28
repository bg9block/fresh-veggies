using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Interfaces;
using ShoppingCart.Services;
using ShoppingCart.Services.Interfaces;

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
            services.AddAutoMapper();
            
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IVoucherService), typeof(VoucherService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            services.AddDbContext<ProductContext>();
            services.AddDbContext<ProductContext>();
            services.AddDbContext<ProductContext>();
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IVoucherRepository), typeof(VoucherRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
        
        
    }
}