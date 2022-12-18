using Catelog.API.Configurations;
using Catelog.API.Interfaces;
using Catelog.API.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding services as DI
//builder.Services.AddSingleton<IProduct, IProductService>();

BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

var mongoDbSetting = builder.Configuration.GetSection("MangoDBConfiguration").Get<MongoDBConfiguration>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDbSetting.ConnectionString);
});

builder.Services.AddSingleton<IProduct, ProductServiceMongoDb>();
builder.Services.AddSingleton<IUserManagement, UserManagementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();  // added to configure endpoints

app.UseAuthorization();

// configured by developer
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();

});

// used to map controller action according to request. ##default flow  
//app.MapControllers();

app.Run();
