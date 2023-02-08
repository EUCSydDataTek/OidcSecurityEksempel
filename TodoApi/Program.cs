using TodoApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
                {
                    var scheme = new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri(builder.Configuration.GetValue<string>("Swagger:AuthorizationUrl")),
                                TokenUrl = new Uri(builder.Configuration.GetValue<string>("Swagger:TokenUrl")),
                                Scopes =
                                {
                                    // (SCOPE,COMMENT)
                                    new("openid", "Openid"),
                                    new("api", "Api access")
                                },
                            }
                        },
                        Type = SecuritySchemeType.OAuth2
                    };
                    options.AddSecurityDefinition("OAuth", scheme);

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Id = "OAuth", Type = ReferenceType.SecurityScheme }
                            },
                            new List<string> { }
                        }
                    });
                });
builder.Services.AddSingleton<ITodoService, TodoService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = builder.Configuration.GetValue<string>("Jwt:Authority");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId(builder.Configuration.GetValue<string>("Swagger:ClientId"));
        options.OAuthClientSecret(builder.Configuration.GetValue<string>("Swagger:ClientSecret"));
        options.OAuthScopes("openid","api");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
