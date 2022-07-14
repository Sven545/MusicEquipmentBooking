using Microsoft.OpenApi.Models;
using MusicEquipmentBooking.BusinessLogicLayer.Interfaces;
using MusicEquipmentBooking.BusinessLogicLayer.Services;
using MusicEquipmentBooking.BusinessLogicLayer.DataTransferObjects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddTransient<ICrudService<ServiceObjectDTO>,ServiceObjectCrudService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Music", Version = "v1" });
});

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
   
}
app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music v1"));
//app.MapGet("/", () => "Hello World!");

app.Run();
