using DownloadTests.Pages.Interfaces;
using DownloadTests.Support.Drivers.Interfaces;

namespace DownloadTests.StepDefinitions;

[Binding]
public class UploadAppStepDefinitions(
    IDriver driver,
    IUploadAppPage page
    )
{
    private readonly IDriver Driver = driver;
    private readonly IUploadAppPage Page = page;

    [Given("I am on the {string} Page")]
    public void GivenIAmOnThePage(string url) => Driver.Page.GotoAsync(url);

    [Given("I select the {string} File to upload")]
    public async Task GivenISelectTheFileToUpload(string fileName) => await Page.UploadAFileAsync(fileName);

    [When("I click on the Upload button")]
    public async Task WhenIClickOnTheUploadButton() => await Page.PressOnUploadAsync();

    [Then("the {string} File should be Uploaded")]
    public async Task ThenTheFileShouldBeUploaded(string fileName) => Assert.IsTrue(await Page.CheckIfFileUploadedAsync(fileName));
}
