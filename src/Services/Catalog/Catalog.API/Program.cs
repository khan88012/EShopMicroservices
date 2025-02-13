var builder = WebApplication.CreateBuilder(args);

//add services to the container
var app = builder.Build();

//configure the htttp request pipeline

app.Run();
