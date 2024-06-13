using AspireResearch;

var builder = DistributedApplication.CreateBuilder(args);

if (builder.ExecutionContext.IsPublishMode)
{
    builder.AddAzureVideoIndexer(name:"mynewvi");
}
builder.Build().Run();
