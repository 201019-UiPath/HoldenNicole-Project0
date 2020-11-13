using CustomerLib;
using LocationLib;
using OrdersLib;
using StoreDB.Entities;
using StoreDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreUI;

namespace StoreAPI
{
    public class Startup
    {
        readonly string Allowed = "_allowed";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: Allowed,
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1: 44319")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddDbContext<ixdssaucContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IStoreRepo, DBRepo>();
            services.AddScoped<IMapper, StoreMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Allowed);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
