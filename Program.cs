using Microsoft.EntityFrameworkCore;
using MockTalksAPI.Hubs;
using MockTalksAPI.Services;
using MockTalksAPI.Services.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddScoped<MT_UserService>();
builder.Services.AddScoped<MT_ProfileService>();
builder.Services.AddScoped<MT_MessagingService>();
builder.Services.AddScoped<MT_ScheduleService>();

var connectionString=builder.Configuration.GetConnectionString("MyMockTalksString");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("MtPolicy",
builder => {
    builder.WithOrigins("http://localhost:5150", "http://localhost:3000", "https://mocktalks.vercel.app")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MT_MessagingConnectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MtPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapHub<MT_ChatHubs>(pattern: "/Chat");

app.Run();
