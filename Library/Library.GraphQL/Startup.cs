using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Library.EF;
using Library.GraphQL.Contract;
using Library.GraphQL.GraphQLTypes;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Library.GraphQL.GraphQLTypes.ObjectTypes;
using Library.GraphQL.MutationTypes;
using Library.GraphQL.QueryTypes;
using Library.GraphQL.Services;
using Microsoft.EntityFrameworkCore;
using Library.GraphQL.Mapping;
using Library.GraphQL.TokenAuth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Library.GraphQL.Error;

namespace Library.GraphQL {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            services.Configure<TokenSettings>(Configuration.GetSection("JWT"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    var tokenSettings = Configuration
                    .GetSection("JWT").Get<TokenSettings>();
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidIssuer = tokenSettings.Issuer,
                        ValidateIssuer = true,
                        ValidAudience = tokenSettings.Audience,
                        ValidateAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key)),
                        ValidateIssuerSigningKey = true
                    };
                });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            services.AddPooledDbContextFactory<LibraryContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("LibraryDB")));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<BookMapper>();
            services.AddScoped<AuthorMapper>();

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<BookQuery>()
                .AddTypeExtension<AuthorQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<BookMutation>()
                .AddTypeExtension<AuthorMutation>()
                .AddTypeExtension<LoginMutation>()
                .AddType<BookType>()
                .AddType<AuthorType>()
                .AddAuthorization();

            services.AddErrorFilter<LibraryErrorFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();

                app.UsePlayground(new PlaygroundOptions {
                    QueryPath = "/api",
                    Path = "/playground"
                });
            }

            app
            .UseAuthentication()
            .UseAuthorization()
            .UseRouting()
                .UseEndpoints(endpoints => {
                    endpoints.MapGraphQL();
                    endpoints.MapControllers();
                });

            
        }
    }
}
