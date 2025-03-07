namespace DownloadTests.Pages.Interfaces;

public interface IDownloadAppPage : IBaseAppPage
{
    bool IsFileDownloaded();
    Task ClickOnFirstFileLink();
}