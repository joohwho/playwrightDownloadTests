namespace DownloadTests.Pages.Interfaces;

public interface IUploadAppPage : IBaseAppPage
{
    Task PressOnUploadAsync();
    Task UploadAFileAsync(string fileName);
    Task<bool> CheckIfFileUploadedAsync(string fileName);
}