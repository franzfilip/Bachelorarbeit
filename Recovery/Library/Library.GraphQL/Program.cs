using AutoBetter.BusinessLogic.impl;
using AutoBetter.DataAccess.impl;
using AutoMapper;
using Library.BusinessLogic;
using Library.BusinessLogic.Impl;
using Library.DataAccess;
using Library.DataAccess.Impl;
using Library.EF;
using Library.GraphQL.MutationTypes;
using Library.GraphQL.QueryTypes;
using Library.GraphQLTypes.InputTypes.Book;
using Library.GraphQLTypes.ObjectTypes;
using Library.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPooledDbContextFactory<LibraryContext>(item =>
                item.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

builder.Services.AddControllers();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddTransient<IBookService, BookService>();

builder.Services
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddTypeExtension<BookQuery>()
        .AddType<BookType>()
        .AddType<AuthorType>()
        .AddType<BookCreate>()
        .AddType<BookUpdate>()
        .AddMutationType<Mutation>()
        .AddTypeExtension<BookMutation>();

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new BookProfile());
});

builder.Services.AddSingleton<IMapper>(mapperConfig.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseRouting()
    .UseEndpoints(endpoints => {
        endpoints.MapGraphQL();
    });

app.Run();