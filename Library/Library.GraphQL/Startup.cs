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
using Library.GraphQL.Mutations;
using Library.GraphQL.Querys;
using Library.GraphQL.Services;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();

            //services.AddDbContextPool<LibraryContext>(item => item.UseSqlServer(Configuration.GetConnectionString("LibraryDB")));
            services.AddPooledDbContextFactory<LibraryContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("LibraryDB")));

            services.AddScoped<IBookService, BookService>();
            //services.AddScoped<Query>();

            //services.AddGraphQL(c => SchemaBuilder.New().AddServices(c).AddType<BookType>()
            //    .AddQueryType<Query>()
            //    .AddMutationType<Mutation>()
            //    .Create());

            services
                .AddGraphQLServer()
                .AddQueryType<Query>();

            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //services.AddSwaggerGen(c => {
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library.GraphQL", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library.GraphQL v1"));
                //app.UsePlayground(new PlaygroundOptions
                //{
                //    QueryPath = "/api",
                //    Path = "/playground"
                //});
            }

            //app.UseGraphQL("/api");
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });

            app.UseAuthorization();

            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllers();
            //});
        }
    }
}
