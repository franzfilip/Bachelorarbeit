using AutoBetter.BusinessLogic.impl;
using AutoBetter.DataAccess.impl;
using AutoMapper;
using Library.BusinessLogic;
using Library.BusinessLogic.Impl;
using Library.DataAccess;
using Library.DataAccess.Impl;
using Library.Datamodel.TokenAuth;
using Library.EF;
using Library.GraphQL.DataLoaders;
using Library.GraphQL.MutationTypes;
using Library.GraphQL.QueryTypes;
using Library.GraphQLTypes.InputTypes.Author;
using Library.GraphQLTypes.InputTypes.Book;
using Library.GraphQLTypes.ObjectTypes;
using Library.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

// Add services to the container.

builder.Services.AddPooledDbContextFactory<LibraryContext>(item =>
                item.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

builder.Services.AddControllers();

builder.Services.Configure<TokenSettings>(configuration.GetSection("JWT"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    var tokenSettings = configuration
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

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IBookRepository), typeof(BookRepository));
builder.Services.AddTransient(typeof(IAuthorRepository), typeof(AuthorRepository));
builder.Services.AddTransient(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services
        .AddGraphQLServer()
        .AddProjections()
        .AddFiltering()
        .AddSorting()
        .AddQueryType<Query>()
        .AddTypeExtension<BookQuery>()
        .AddTypeExtension<AuthorQuery>()
        .AddMutationType<Mutation>()
        .AddTypeExtension<BookMutation>()
        .AddTypeExtension<AuthorMutation>()
        .AddTypeExtension<ReviewMutation>()
        .AddTypeExtension<AuthMutationTypeExtension>()
        .AddDataLoader<AuthorByIdDataLoader>()
        .AddType<BookType>()
        .AddType<AuthorType>()
        .AddType<BookCreate>()
        .AddType<BookUpdate>()
        .AddType<AuthorCreate>()
        .AddType<AuthorUpdate>()
        .AddType<UserType>();

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new BookProfile());
    mc.AddProfile(new AuthorProfile());
    mc.AddProfile(new ReviewProfile());
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