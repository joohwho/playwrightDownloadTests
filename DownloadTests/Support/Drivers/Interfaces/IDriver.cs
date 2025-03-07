using Microsoft.Playwright;

namespace DownloadTests.Support.Drivers.Interfaces;

public interface IDriver : IDisposable
{
    IPage Page { get; }
    Task<IPage> InitializePlaywright();
}
