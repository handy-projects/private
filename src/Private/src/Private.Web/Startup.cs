using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Private.Core.Repositories;
using System.Threading.Tasks;

namespace Private.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Private.Core.Domain.PrivateContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            /*services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();*/
                
            services.AddMvc();

            services.AddAntiforgery();

            services.AddAuthentication(options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            //services.Configure<CookieAuthenticationOptions>(options =>
            //{
            //    options.LoginPath = new PathString("/Account/LogIn");
            //});

            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new Microsoft.AspNet.Http.PathString("/Account/LogIn");
            });

            // configure policys and claims
            // http://stackoverflow.com/questions/31464359/custom-authorizeattribute-in-asp-net-5-mvc-6

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManageStore", policy => policy.RequireClaim("Action", "ManageStore"));
            });

            // Add application services.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCookieAuthentication(options =>
            {
                options.LoginPath = new PathString("/Account/LogIn");
                // LoginPath redirect only with this shit 
                options.AutomaticChallenge = true;
                

                options.AutomaticAuthenticate = true;
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.CookieHttpOnly = true;
                options.CookieName = "PRIVATE";
                //options.Events = new CookieAuthenticationEvents()
                //{
                //    OnRedirectToLogin = ctx =>
                //    {
                //        if (ctx.Request.Path.StartsWithSegments("/api") &&
                //        ctx.Response.StatusCode == 200)
                //        {
                //            ctx.Response.StatusCode = 401;
                //            return Task.FromResult<object>(null);
                //        }
                //        else
                //        {
                //            ctx.Response.Redirect(ctx.RedirectUri);
                //            return Task.FromResult<object>(null);
                //        }
                //    }

                //};

                //.
            });

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<Private.Core.Domain.PrivateContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler();

            // serve index.html from wwwroot
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            

            

            // Bearer token auth
            // http://stackoverflow.com/questions/29048122/token-based-authentication-in-asp-net-5-vnext/29698502#29698502


            //app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
