using Reqnroll.BoDi;
using Microsoft.Playwright;
using DownloadTests.Pages.Interfaces;
using DownloadTests.Pages.Implementations;
using DownloadTests.Support.Drivers.Interfaces;
using DownloadTests.Support.Drivers.Implementations;

namespace DownloadTests.Support.StartUp;

[Binding]
public class StartUp(IObjectContainer objectContainer)
{
    private readonly IObjectContainer _objectContainer = objectContainer;

    [BeforeTestRun]
    public static void GlobalSetup(IObjectContainer container)
    {
        var driver = new Driver();

        container.RegisterInstanceAs<IDriver>(driver);
        container.RegisterInstanceAs<IPage>(driver.Page);

        container.RegisterTypeAs<UploadAppPage, IUploadAppPage>();
    }

    [AfterTestRun]
    public static void GlobalTeardown()
    {
        // Se precisar liberar recursos globalmente
    }
}
