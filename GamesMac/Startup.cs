using GamesMac.Areas.Admin.Servicos;
using GamesMac.Context;
using GamesMac.Models;
using GamesMac.Repositories;
using GamesMac.Repositories.Interfaces;
using GamesMac.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ReflectionIT.Mvc.Paging;

namespace GamesMac;
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
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            //Muda as configurações para Senhas
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
        });

        services.AddTransient<IGamesRepository, GamesRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        services.AddScoped<RelatorioVendasService>();

        //tem q adicionar politica p usar
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin",
                politica =>
                {
                    politica.RequireRole("Admin");
                });
        });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        services.AddControllersWithViews();

        services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";
        });

        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        //cria os perfis
        seedUserRoleInitial.SeedRoles();
        //cria os usuario e atribui ao perfil
        seedUserRoleInitial.SeedUsers();


        app.UseSession();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            //aqui o controller veio como home e eu tive q mudar pra admin, lembrar disso
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            
            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern:"Game/{action}/{categoria?}",
                defaults:new {Controller = "Game", action = "List"});

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}