using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
//add services to the container
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    //configuring mediater pipeline for validation behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));  // <,>  meaning generic
});
//injecting validator service
builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddCarter();


builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
var app = builder.Build();

//configure the htttp request pipeline
app.MapCarter();

app.Run();
