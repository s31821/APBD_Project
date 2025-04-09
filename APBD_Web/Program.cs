using APBD_Web.Interfaces;
using DeviceManager;
using DeviceManager.Devices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

DevMan deviceManager = null;
try
{
    deviceManager = new DevMan(new FileDeviceRepository("input.txt", new DeviceFactory()));
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found. Terminating...");
    Environment.Exit(1);
}

// deviceManager.ListDevices();
app.MapGet("/api/devices", () => deviceManager.ListDevices());
app.MapGet("/api/devices/{id:int}", (int id) => deviceManager.ListDevices(id));
//
// deviceManager.AddDevice();
app.MapPost("/api/devices", (IDevice device) => deviceManager.AddDevice(device));
//
// deviceManager.RemoveDevice();
app.MapDelete("/api/devices/", (int id) => deviceManager.RemoveDevice(id));
//
// deviceManager.TurnOnDevice();
//
// deviceManager.TurnOffDevice();
//
// deviceManager.SaveDevices();
app.MapPut("/api/animals", (IDevice device) => deviceManager.EditDevice(device));
app.Run();