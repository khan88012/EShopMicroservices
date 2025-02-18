using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    //configuring mediater pipeline for validation behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));  // <,>  meaning generic
});
//injecting validator service
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
var app = builder.Build();

//configure the htttp request pipeline
app.MapCarter();

app.Run();
