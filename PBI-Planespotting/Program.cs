using PBI_Planespotting.App_Start;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DependencyMapper.Map(builder.Services);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();