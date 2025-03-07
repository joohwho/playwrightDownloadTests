using Microsoft.Playwright;

namespace DownloadTests.Pages.Interfaces;

public interface IBaseAppPage
{
    IPage Page { get; }
}
