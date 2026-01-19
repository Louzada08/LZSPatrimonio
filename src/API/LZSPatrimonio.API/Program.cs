using LZSPatrimonio.Infra.IoC.InjetorServicos;
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


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
