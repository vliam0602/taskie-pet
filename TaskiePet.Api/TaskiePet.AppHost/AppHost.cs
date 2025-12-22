var builder = DistributedApplication.CreateBuilder(args);

// Create sqlserver container
var sqlPassword = builder.AddParameter("password", "Passw0rd@12345");
var sql = builder.AddSqlServer("sqlserver")
                    .WithHostPort(1434)
                    .WithDataVolume()
                    .WithEnvironment("ACCEPT_EULA", "Y")
                    .WithPassword(sqlPassword)
                    .WithLifetime(ContainerLifetime.Persistent);

var taskiepetDb = sql.AddDatabase("taskiepet-db");

var apiService = builder.AddProject<Projects.TaskiePet_WebApi>("taskiepet-api")
                .WithReference(taskiepetDb)
                .WithHttpHealthCheck("/healthz")
                .WaitFor(sql);

var web = builder.AddNpmApp("taskiepet-fe", Path.Combine("..", "..", "TaskiePet.Client"))
                    .WithReference(apiService)
                    // .WithHttpEndpoint(port: 5173)
                    // .WithExternalHttpEndpoints()
                    // .WithHttpHealthCheck("/index.html")
                    .WaitFor(apiService);

builder.Build().Run();
