using GreenPipes;
using MassTransit;
using Response.Consumers;

var builder = WebApplication.CreateBuilder(args);

var host = builder.Configuration["MassTransit:Host"];
var queue = builder.Configuration["MassTransit:Queue"];
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductInfoRequestConsumer>();

    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
    {
        c.Host(host);
        c.ReceiveEndpoint(queue, e =>
        {
            e.PrefetchCount = 16;
            e.UseMessageRetry(r => r.Interval(2, 3000));
            e.ConfigureConsumer<ProductInfoRequestConsumer>(context);
        });
    }));    
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
