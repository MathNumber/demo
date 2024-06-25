using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CurrentWeatherForcast : IHostedService, IDisposable
{
    private readonly ILogger<CurrentWeatherForcast> _logger;
    private Timer _timer;
    private int _temperatureC;

    public CurrentWeatherForcast(ILogger<CurrentWeatherForcast> logger)
    {
        _logger = logger;
        _temperatureC = 0;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Temperature Update Service is starting.");
        _timer = new Timer(UpdateTemperature, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        return Task.CompletedTask;
    }

    private void UpdateTemperature(object state)
    {
        _temperatureC++;
        _logger.LogInformation($"Temperature updated to {_temperatureC}C.");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Temperature Update Service is stopping.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    public int GetCurrentTemperature()
    {
        return _temperatureC;
    }
}