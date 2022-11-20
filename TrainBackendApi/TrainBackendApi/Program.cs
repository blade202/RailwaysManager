using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TrainBackendApi.Middelware;
using TrainBackendApi.Repository;
using TrainBackendApi.Services;

var builder = WebApplication.CreateBuilder(args);
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<TrainDbConntext>();
builder.Services.AddTransient<UserManager>();
builder.Services.AddTransient<RailwaysService>();
builder.Services.AddTransient<CityService>();
builder.Services.AddTransient<CacheService>();
builder.Services.AddTransient<GlobalExeptionMiddelware>();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<JwtTokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o=>
{
    o.SaveToken = true;
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = MyConfig.GetValue<string>("Jwt:Issuer"),
        ValidAudience=MyConfig.GetValue<string>("Jwt:Audience"),
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MyConfig.GetValue<string>("Jwt:Key")))
    };
    o.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = c =>
          {
              c.Response.StatusCode = 401;
              return Task.CompletedTask;
          }
    };
   
}
);
builder.Services.AddCors(o =>
o.AddPolicy("vuejs", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
})

);;

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("vuejs");
//app.UseMiddleware<GlobalExeptionMiddelware>();
app.MapControllers();

app.Run();
