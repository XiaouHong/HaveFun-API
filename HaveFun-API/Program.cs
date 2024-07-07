using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Repositories;
using HaveFun_API.Schafold;
using HaveFun_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HaveFunContext>(options =>
{
	options.UseSqlServer(configuration.GetSection("ConnectionStrings:SQLServer").Value);
});
Global.ClientId = configuration.GetSection("OATH:ClientId").Value ?? "";
Global.ClientSecret = configuration.GetSection("OATH:ClientSecret").Value ?? "";
Global.RedirectUri = configuration.GetSection("OATH:RedirectUri").Value ?? "";
Global.JWTSecret = configuration.GetSection("JwtConfig:Secret").Value ?? "";
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//	googleOptions.ClientId = configuration.GetSection("OATH:ClientId").Value;
//	googleOptions.ClientSecret = configuration.GetSection("OATH:ClientSecret").Value;
//});
// HttpClientFactory https://www.dotblogs.com.tw/Null/2020/05/04/211830
// MemoryCache
builder.Services.AddMvc().AddDataAnnotationsLocalization()
						 .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter()));

// NLog https://medium.com/appxtech/nlog-%E6%95%99%E5%AD%B8-%E5%BF%AB%E9%80%9F%E5%BB%BA%E7%AB%8B%E8%87%AA%E8%A8%82%E6%97%A5%E8%AA%8C%E7%B4%80%E9%8C%84-%E5%9F%BA%E7%A4%8E%E7%AF%87-8b4f27739f30
// Official https://nlog-project.org/

builder.Services.AddHttpClient();

// Repositories
builder.Services.AddTransient<IMemberRepository, MemberRepository>();

// Services
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IJWTService, JWTService>();

builder.Services.AddSwaggerGen(option =>
{
	option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "API.xml"));
	option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Version = "v1",
		Title = "HaveFun 2024/07/05"
	});
});

//JWT
byte[] Key = Encoding.UTF8.GetBytes(Global.JWTSecret);
var tokenValidationParameters = new TokenValidationParameters
{
	ValidateIssuer = false,
	ValidateAudience = false,
	ValidateIssuerSigningKey = true,
	IssuerSigningKey = new SymmetricSecurityKey(Key),
	ValidateLifetime = false,
	ClockSkew = TimeSpan.Zero
};
builder.Services.AddSingleton(tokenValidationParameters);
builder.Services.AddAuthentication(option =>
{
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
	option.RequireHttpsMetadata = false;
	option.IncludeErrorDetails = true;
	option.SaveToken = true;
	option.TokenValidationParameters = tokenValidationParameters;
});
// Hangfire ±Æµ{ https://blog.darkthread.net/blog/category/hangfire
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(option =>
{
	option.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
	option.DocumentTitle = "HaveFun";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
