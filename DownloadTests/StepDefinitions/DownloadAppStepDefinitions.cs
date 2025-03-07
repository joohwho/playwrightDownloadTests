using DownloadTests.Pages.Interfaces;

namespace DownloadTests.StepDefinitions;

[Binding]
public class DownloadAppStepDefinitions(IDownloadAppPage downloadAppPage)
{
    private readonly IDownloadAppPage Page = downloadAppPage;

    [When("I click on the first File Link in the list")]
    public async Task WhenIClickOnTheFirstFileLinkInTheList() => await Page.ClickOnFirstFileLink();

    [Then("the File should be Downloaded")]
    public void ThenTheFileShouldBeDownloaded() => Assert.IsTrue(Page.IsFileDownloaded());
}
