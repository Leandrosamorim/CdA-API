using Domain.Models;
using Hangfire;
using Hangfire.Common;
using Microservices.Services.Queue;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHangfireServer();
builder.Services.AddHangfire(configuration =>
{
    configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
var queueServices = new QueueServices();


app.UseHangfireDashboard("/dash");
app.UseHangfireServer();


app.MapGet("/consume", () => queueServices.Consume());
var manager = new RecurringJobManager();
manager.AddOrUpdate("consume", Job.FromExpression(() => queueServices.Consume()), Cron.Minutely());



app.Run();




