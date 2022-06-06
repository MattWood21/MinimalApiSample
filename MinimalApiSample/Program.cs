using MinimalApiSample.Interfaces;
using MinimalApiSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add routeable services
builder.Services.AddTransient<BlogService>();
builder.Services.AddTransient<PostService>();

// Add other services
builder.Services.AddSingleton<RandomNumberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

MapRouteableServices(builder, app);
app.Run();

static bool IsRouteableService(ServiceDescriptor serviceDescriptor)
{
    var type = serviceDescriptor.ServiceType;
    return typeof(IRouteableService).IsAssignableFrom(type);
}

static void MapRouteableServices(WebApplicationBuilder builder, WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();
    var serviceProvider = serviceScope.ServiceProvider;
    var routeableServices = builder.Services
        .Where(IsRouteableService);

    foreach (var service in routeableServices)
    {
        if (service.ImplementationType is null)
        {
            continue;
        }

        if (serviceProvider.GetRequiredService(service.ImplementationType) is not IRouteableService routeableService)
        {
            continue;
        }

        routeableService.MapRoutes(app);
    }
}