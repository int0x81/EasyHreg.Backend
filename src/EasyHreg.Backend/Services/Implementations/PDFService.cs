using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace EasyHreg.Backend.Services.Implementations;

public class PdfService
{
    private readonly SemaphoreSlim _semaphore = new(5, 5);
    private readonly IBrowser _browser;

    public PdfService()
    {
        var chromeDriverPath = Environment.GetEnvironmentVariable("CHROME_DRIVER_PATH");
        // var chromeDriverPath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
        _browser ??= Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            ExecutablePath = chromeDriverPath,
            Args =
            [
                "--no-sandbox",
                "--disable-setuid-sandbox",
                "--disable-dev-shm-usage",
                "--disable-accelerated-2d-canvas",
                "--no-first-run",
                "--no-zygote",
                "--disable-gpu"
            ]
        }).Result;
    }

    public async Task<byte[]> CreatePdfFromHtml(string htmlTemplate)
    {
        await _semaphore.WaitAsync();
        
        await using var currentPage = await _browser.NewPageAsync();
        await currentPage.SetContentAsync(htmlTemplate);
        var pdfFile = await currentPage.PdfDataAsync(new PdfOptions
        {
            PrintBackground = true,
            MarginOptions = new MarginOptions
            {
                Bottom = "2cm",
                Left = "1cm",
                Right = "1cm",
                Top = "2cm"
            }
        });

        return pdfFile;
    }

    public void Dispose()
    {
        _browser?.Dispose();
        _semaphore?.Dispose();
    }
}