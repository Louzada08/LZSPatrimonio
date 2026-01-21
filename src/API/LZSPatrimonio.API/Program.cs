using LZSPatrimonio.API.Configuracoes;
using LZSPatrimonio.Infra.IoC.InjetorServicos;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddIdentityInject(builder.Configuration);
//builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddMediatorInjector();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    //cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly);
});
builder.Services.AddServicesInjectors();
builder.Services.AddDbInjector();
builder.Services.AddAutoMapperInjector();

#region Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Development",
        b =>
            b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Rest API´s de 0 a Azure com ASP.NET Core 8 e Docker",
        Version = "v1",
        Description = "API RESTful desenvolvida no curso de ASP.NET Core 8",
        Contact = new()
        {
            Name = "Leandro Costa",
            Url = new Uri("https://github.com/leandrocgsi")
        }
    });

    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira apenas o token, sem a palavra-chave 'Bearer'",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });

    c.OperationFilter<AuthenticationRequirementsOperationFilter>();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x =>
x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();