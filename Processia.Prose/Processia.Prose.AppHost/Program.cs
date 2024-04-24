using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var mongodb = builder.AddMongoDB("mongodb")
                     .AddDatabase("ProseDb");

var redis = builder.AddRedis("redis");

var api = builder.AddProject<Projects.Processia_Prose_Api>("prose-api")
    .WithReference(mongodb)
    .WithReference(redis)
    .WithReplicas(2);

builder.AddProject<Projects.Processia_Prose_WebApp>("prose-webapp")
    .WithReference(api);

builder.Build().Run();
