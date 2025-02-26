




var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
//add services to the container
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    //configuring mediater pipeline for validation behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));  // <,>  meaning generic
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
//injecting validator service
builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddCarter();


builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

// the exception lambda handler is removed as IException is more suitable for microservices architecture hence registering it
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();




//configure the htttp request pipeline
app.MapCarter();
// configuring the application to use our CustomExceptionHandler pipeline
app.UseExceptionHandler(options => { });
    

app.Run();
