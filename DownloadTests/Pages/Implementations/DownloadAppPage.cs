using Microsoft.Playwright;
using DownloadTests.Pages.Interfaces;
using DownloadTests.Support.Drivers.Interfaces;

namespace DownloadTests.Pages.Implementations;

public class DownloadAppPage(IDriver driver) : BaseAppPage(driver), IDownloadAppPage
{
    private string FilePath { get; set; } = string.Empty;
    private ILocator FirstFileLink => Page.Locator("a[href^='download/']").First;

    public async Task ClickOnFirstFileLink()
    {
        var download = await Page.RunAndWaitForDownloadAsync(async () =>
        {
            await FirstFileLink.ClickAsync();
        });

        string fileName = download.SuggestedFilename;
        FilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Support\\Files\\Download", fileName);

        await download.SaveAsAsync(FilePath);
    }

    public bool IsFileDownloaded() => File.Exists(FilePath);
}
