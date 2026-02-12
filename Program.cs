using Amazon.DynamoDBv2;
using Amazon.Lambda.AspNetCoreServer.Hosting;
using Backend_Test_DynamoDB.Database;
using Backend_Test_DynamoDB.Repositories;
using Backend_Test_DynamoDB.Services;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend_Test_DynamoDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            IConfiguration configuration = builder.Configuration;

            // ===============================
            // Firebase Admin SDK (Backend verify token)
            // ===============================
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("sep490firebaseauth-firebase-adminsdk-key.json")
                });
            }

            // ===============================
            // Authentication - Game JWT
            // ===============================
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])
                        )
                    };
                });

            builder.Services.AddAuthorization();

            // ===============================
            // DynamoDB LOCAL (DELETE WHEN DEPLOY)
            // ===============================
            builder.Services.AddSingleton<IAmazonDynamoDB>(_ =>
            {
                var config = new AmazonDynamoDBConfig
                {
                    ServiceURL = configuration["AWS:ServiceURL"]
                };

                return new AmazonDynamoDBClient(
                    "dummy",
                    "dummy",
                    config
                );
            });


            // ===============================
            // Repositories
            // ===============================
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


            // ===============================
            // Services
            // ===============================
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();

            // ===============================
            // Controllers & Swagger
            // ===============================
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ===============================
            // DynamoDB & AWS Lambda Hosting (Cloud)
            // ===============================
            //builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
            //builder.Services.AddAWSService<IAmazonDynamoDB>();

            var app = builder.Build();

            // ===============================
            // Middleware pipeline
            // ===============================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // ===============================
            // DynamoDB Init (DELETE WHEN DEPLOY)
            // ===============================
            using (var scope = app.Services.CreateScope())
            {
                var dynamoDb = scope.ServiceProvider.GetRequiredService<IAmazonDynamoDB>();
                var initializer = new DynamoDbTableInitializer(dynamoDb);
                initializer.InitializeAsync();
            }

            app.Run();
        }
    }
}