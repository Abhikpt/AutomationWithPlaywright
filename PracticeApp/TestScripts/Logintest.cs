

using Microsoft.Playwright;

namespace PlaywrightPractice.TestScripts;

public class Logintest
{
    [Test]
    public async Task TC_01_LoginTest()
    {   
        // Get the username and password from environment variables (directly from CI/CD pipline or GIthub repository secret)
        // You can set these variables in your CI/CD pipeline or GitHub repository secrets
        var username = Environment.GetEnvironmentVariable("USERNAME");
        var password = Environment.GetEnvironmentVariable("PASSWORD");


        Console.WriteLine($"Username: {username} and Password: {password}");
        Console.WriteLine("Login Test Started");

         var playwright = await Playwright.CreateAsync();
         var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50 // Slow down operations by 50ms to see the actions in the browser
            });

         var page = await browser.NewPageAsync();

         await page.GotoAsync("https://practicetestautomation.com/practice-test-login/"); // Replace with your login URL

         Console.WriteLine($"PageTitle: { await page.TitleAsync()}"); 

        await page.FillAsync("#username", username);
        await page.FillAsync("#password", password); 
        await page.ClickAsync("#submit");
        string message = await page.Locator("#loop-container > div > article > div.post-header > h1").InnerTextAsync();
        Console.WriteLine($"Login Message: {message}");

        Assert.That(message, Is.EqualTo("Logged In Successfully"));

      
        Console.WriteLine("Login Test Completed");

    }
}
