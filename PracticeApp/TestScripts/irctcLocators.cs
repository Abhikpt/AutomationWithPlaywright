

using System.Threading.Tasks;

namespace PracticeApp.TestScripts;
public class irctcLocators : BaseClass
{

    [SetUp]
    public async Task setup()
    {
        await StartAsync(false);
        await _page.GotoAsync("https://www.irctc.co.in/nget/train-search");
    }

    [TearDown]
    public async Task tearDown()
    {
        await StopAsync();
    }


    [Test, Category("Print the all Holidays Packages")]
    public async Task PrintAllHolidaysPackages()
    {
       var ContainerElement =  _page.Locator("//div[@class='container']//div[@class='blogdetail']").AllAsync().Result;
       foreach(var element in ContainerElement)
       {
        string headingtext = await element.Locator("h3").InnerTextAsync();
        string descriptiontext = await element.Locator("p").InnerTextAsync();
        Console.WriteLine($"Heading: {headingtext}");
        Console.WriteLine($"Description: {descriptiontext}");
        Console.WriteLine("--------------------------------------------------");
       }

    }

    [Test, Category("IRCTC Page scrools")]  
    public async Task LocatorsPageScrolls()
    {
        // Smooth scroll to the bottom of the page
        await _page.EvaluateAsync(@"window.scrollTo(0, document.body.scrollHeight);");
        await Task.Delay(2000);

        // Scroll back to the top of the page
        await _page.EvaluateAsync(@"window.scrollTo(0, 0);");
        await Task.Delay(2000);

        // Scroll to a specific element
        var element = await _page.QuerySelectorAsync("//div[@class='container']//div[@class='blogdetail']/h3[text()='Bharat Gaurav Tourist Train']");
        if (element != null)
        {
            await element.ScrollIntoViewIfNeededAsync();
            await Task.Delay(2000);
        }
    }


}