using System.Diagnostics;

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

app.MapGet("/performancestates", async () =>
{
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        var memoryCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        
        await Task.Delay(1000);

        var states = new PerformanceState[5];
        for (int i = 0; i < states.Length; i++)
        {
            states[i] = new PerformanceState
            {
                CurrentTime = TimeOnly.FromDateTime(DateTime.Now),
                TotalCpuUtilizationPercentage = (int)cpuCounter.NextValue(),
                OccupiedMemoryPercentage = (int)memoryCounter.NextValue(),
                TotalRunningProcessesCount = Process.GetProcesses().Length
            };
            await Task.Delay(1000);
        }
        cpuCounter.Dispose();
        memoryCounter.Dispose();

    return states;
})
.WithName("GetPerformanceStates")
.WithOpenApi();

app.Run();

public class PerformanceState
    {
        //Added time to track system state over time
        public TimeOnly CurrentTime { get; set; }
        public int TotalCpuUtilizationPercentage { get; set; }
        public int OccupiedMemoryPercentage { get; set; }
        public int TotalRunningProcessesCount { get; set; }
    }
