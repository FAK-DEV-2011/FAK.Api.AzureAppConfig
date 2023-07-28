using FAK.Api.AzureAppConfig.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = "Endpoint=https://fak-lab-appconfig.azconfig.io;Id=yOOT-le-s0:C/6REhlXDKIQSzR2WLvZ;Secret=Mg4RoOEZItDz6wxn1Gw0pTTnAoKCb/v30DE2n0p4SuA=";
builder.Configuration.AddAzureAppConfiguration(connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("TestApp:Settings"));

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
