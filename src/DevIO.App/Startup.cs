using AutoMapper;
using DevIO.App.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using DevIO.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DevIO.App.Data;
using DevIO.Business.Intefaces;
using DevIO.Data.Repository;

//Classe startup https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/?view=aspnetcore-6.0&tabs=windows
namespace DevIO.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>              /*Aqui eu estou configurando o IdentityDbContext*/
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));// ficar de olho para ver se não apresenta erro. Pego do Git.

            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //aqui eu falo que o meu contexto esta mapeado.

            services.AddAutoMapper(typeof(Startup));
            // Agora iremos configurar o automapper. Para a sua utilização e necessario a instação do pacote AutoMapper.Extensions.Microsoft.DependencyInjection. E o using AutoMapper.
            // typeof = O typeof operador C# ( GetType operador em Visual Basic) é usado para obter um Type objeto que representa String . Desse Type objeto, o GetMethod método é usado para obter uma MethodInfo representação da String.Substring sobrecarga que usa um local inicial e um comprimento.
            //No automapper eu tenho que informa qual assembly ira utilizar para trabalhar como base e referencia para resolver o que for necesario. Neste caso (typeof(Startup)). Teremos que criar uma configuração de resolução do automapper dentro da camada mvc.
            //Eu estou informando " dentro assembly, DevIO.App procure uma referencia ou qualquer classe que possua o profile como herença (Profile e uma classe de configuração de mapeamento do automapper)

            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>(); // Ficar de olho. Pego do Git

            //Criamos um meio de acesso ao banco.

            services.AddMvcConfiguration();

            services.ResolveDependencies();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/erro/500");
                app.UseStatusCodePagesWithRedirects("/erro/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGlobalizationConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
