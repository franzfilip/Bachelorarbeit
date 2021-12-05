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

namespace Library.GraphQL {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            services.AddPooledDbContextFactory<LibraryContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("LibraryDB")));

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<BookMapper>();

            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<BookQuery>()
                .AddTypeExtension<AuthorQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<BookMutation>()
                .AddType<BookType>()
                //.AddType<BookCreateType>()
                //.AddType<BookUpdateType>()
                .AddType<AuthorType>();
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

            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            app.UseAuthorization();
        }
    }
}
