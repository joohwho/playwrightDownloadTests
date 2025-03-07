using Microsoft.Playwright;
using DownloadTests.Pages.Interfaces;
using DownloadTests.Support.Drivers.Interfaces;

namespace DownloadTests.Pages.Implementations;

public class UploadAppPage(IDriver driver) : BaseAppPage(driver), IUploadAppPage
{
    private ILocator FileUploadedInput => Page.Locator("#uploaded-files");
    private ILocator FileInput => Page.Locator("#file-upload");
    private ILocator UploadButton => Page.GetByRole(AriaRole.Button, new() { Name = "Upload" });

    public async Task PressOnUploadAsync() => await UploadButton.ClickAsync();
    public async Task UploadAFileAsync(string fileName) => await FileInput.SetInputFilesAsync(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Support\\Files\\Upload", fileName));
    public async Task<bool> CheckIfFileUploadedAsync(string fileName) => await FileUploadedInput.InnerTextAsync() == fileName;
}
