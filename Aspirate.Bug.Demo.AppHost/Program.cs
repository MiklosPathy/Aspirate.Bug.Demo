using MyabiDigital.XlmRoberta.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var xlm_roberta = builder.AddRoberta("roberta");

var apiService = builder.AddProject<Projects.Aspirate_Bug_Demo_ApiService>("apiservice");

builder.AddProject<Projects.Aspirate_Bug_Demo_Web>("webfrontend")
    .WithReference(xlm_roberta)
    .WaitFor(xlm_roberta)
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
