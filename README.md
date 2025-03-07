# Playwright Upload and Download Automation with C# .NET

Este projeto implementa testes automatizados para o fluxo de **upload** e **download de arquivos** usando **Playwright** em **C#**.

## Features
- ✅ Upload de arquivos para páginas web
- ✅ Download de arquivos com validação do nome e conteúdo
- ✅ Configuração de ambiente com Playwright
- ✅ Integração com Extent Reports para geração de relatórios
- ✅ Captura de evidências com screenshots e logs
- ✅ Execução de testes com XUnit

## Tecnologias
- C# .NET 6+
- **Microsoft Playwright**
- **Extent Reports** para geração de relatórios
- **NUnit** para execução de testes automatizados

## Estrutura do Projeto

```plaintext
PlaywrightDownloadTests
├── Pages
│   ├── IUploadDownloadPage.cs
│   └── UploadDownloadPage.cs
├── Reports
│   └── ExtentReport.html
├── Support
│   ├── Drivers
│   │   ├── IDriver.cs
│   │   └── Driver.cs
│   ├── StartUp.cs
│   └── ExtentReportManager.cs
├── Tests
│   └── UploadDownloadTests.cs
├── .gitignore
└── README.md
```

## Como Rodar a Automação

### 1️⃣ Instalar Dependências
Para instalar todas as dependências necessárias, execute o comando:

```bash
dotnet restore
```

### 2️⃣ Rodar os Testes
Para executar os testes, utilize o comando:

```bash
dotnet test
```

### 3️⃣ Gerar Relatórios Extent
Os relatórios serão salvos na pasta `/Reports`. Para visualizar:

```bash
start Reports/ExtentReport.html
```

## Configuração dos Relatórios Extent
No arquivo `ExtentReportManager.cs`, inicialize o relatório:

```csharp
var htmlReporter = new ExtentHtmlReporter("Reports/ExtentReport.html");
var extent = new ExtentReports();
extent.AttachReporter(htmlReporter);
```

Finalize o relatório na finalização do teste:

```csharp
extent.Flush();
```

## Capturando Evidências nos Relatórios

### Adicionando Screenshots
Para adicionar screenshots aos relatórios:

```csharp
var screenshotPath = "Reports/screenshot.png";
await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });
test.Log(Status.Pass, "Test passed successfully!", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
```

## Exemplo de Código

Aqui está um exemplo de código para **upload** e **download** com Playwright:

```csharp
using Microsoft.Playwright;
using System.IO;
using System.Threading.Tasks;

public class UploadDownloadTests
{
    private IPage Page;
    private ExtentReports extent;
    private ExtentTest test;

    [SetUp]
    public async Task SetUp()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await browser.NewContextAsync(new BrowserNewContextOptions { AcceptDownloads = true });
        Page = await context.NewPageAsync();
    }

    [Test]
    public async Task TestFileUploadAndDownload()
    {
        // Realiza o upload
        await Page.GotoAsync("https://the-internet.herokuapp.com/upload");
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "file_to_upload.txt");
        await Page.SetInputFilesAsync("input[type='file']", filePath);
        await Page.Locator("button[type='submit']").ClickAsync();
        
        // Validação do upload
        var uploadedFileName = await Page.Locator("div[class='example'] h3").InnerTextAsync();
        Assert.AreEqual("File Uploaded!", uploadedFileName);
        
        // Realiza o download
        await Page.GotoAsync("https://the-internet.herokuapp.com/download");
        var download = await Page.RunAndWaitForDownloadAsync(async () =>
        {
            await Page.Locator("a[href^='download/']").First.ClickAsync();
        });

        // Verifica se o download foi feito corretamente
        string downloadPath = download.Path;
        Assert.IsTrue(File.Exists(downloadPath), "O arquivo não foi baixado corretamente!");
    }

    [TearDown]
    public void TearDown()
    {
        extent.Flush();
    }
}
```

### O que o código faz:
- **Realiza o upload** de um arquivo para o site de exemplo.
- **Verifica se o upload foi bem-sucedido** através da validação do nome do arquivo.
- **Realiza o download** de um arquivo.
- **Valida se o arquivo foi baixado** corretamente, verificando sua existência no caminho de download.

## Relatórios Playwright Trace Viewer
Para visualizar o trace de execução do Playwright, você pode usar o comando abaixo:

```bash
npx playwright show-trace trace.zip
```

## Notas Finais

- **Contribuições** são bem-vindas! Sinta-se à vontade para abrir **issues** ou enviar **pull requests**.
- **Testes** para novas funcionalidades ou correções são altamente recomendados.
- Este projeto está em constante evolução. Caso tenha sugestões ou feedbacks, fique à vontade para compartilhar!

## Contato
Se você tiver dúvidas ou precisar de ajuda, entre em contato pela seção **Issues** no GitHub ou me envie um e-mail diretamente.

# Happy testing! 🎉
