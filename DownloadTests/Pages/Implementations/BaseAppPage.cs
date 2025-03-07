using Microsoft.Playwright;
using DownloadTests.Support.Drivers.Interfaces;
using DownloadTests.Pages.Interfaces;

namespace DownloadTests.Pages.Implementations;

public class BaseAppPage(IDriver driver) : IBaseAppPage
{
    public IPage Page { get; } = driver.Page;
}
