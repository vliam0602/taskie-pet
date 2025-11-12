var builder = DistributedApplication.CreateBuilder(args);

// Create sqlserver container
var sqlPassword = builder.AddParameter("password", "Passw0rd@12345");
var sql = builder.AddSqlServer("sqlserver")
                    .WithHostPort(1434)
                    .WithDataVolume()
                    .WithEnvironment("ACCEPT_EULA", "Y")
                    .WithPassword(sqlPassword)
                    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("taskiepet-db");

var api = builder.AddProject<Projects.TaskiePet_WebApi>("taskiepet-api")
                .WithReference(db)
                .WithHttpHealthCheck("/healthz")
                .WaitFor(db);

var web = builder.AddNpmApp("taskiepet-fe", Path.Combine("..", "..", "TaskiePet.Client"))
                    .WithReference(api)
                    // .WithHttpEndpoint(port: 5173)
                    // .WithExternalHttpEndpoints()
                    // .WithHttpHealthCheck("/index.html")
                    .WaitFor(api);

builder.Build().Run();
