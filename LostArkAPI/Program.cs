using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{

    //options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            },
    //        },
    //        new List<string>()
    //    }
    //});

    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description = @"Введите JWT токен авторизации.",
    //    Name = "APIKey",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.ApiKey,
    //    BearerFormat = "JWT",
    //    Scheme = "Bearer"
    //});


    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "LostArk API",
        //Description = "Пример ASP .NET Core Web API",
        Contact = new OpenApiContact
        {
            Name = "Discord",
            Url = new Uri("https://discordapp.com/users/374250448837804033")
        }
    });
    //var BasePath = AppContext.BaseDirectory;
    //var xmlPath = Path.Combine(BasePath, "Documentation DZGAPIv2.xml");
    //options.IncludeXmlComments(xmlPath);
    //options.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
