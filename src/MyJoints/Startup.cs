using Microsoft.AspNet.Builder;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using MyJoints.Core.Intrefaces.Repositories;
using MyJoints.DataAcceess.Context;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using MyJoints.DataAcceess.Repositories.MsSqlDb;

namespace MyJoints
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Setup configuration sources.
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add our repository type
            services.AddScoped<IUserRepository, DataAcceess.Repositories.MsSqlDb.UserRepository>();

            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<MyJointDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.Get("Data:ConnectionString"));
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();
        }
    }
}
