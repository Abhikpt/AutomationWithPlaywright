

using System.Threading.Tasks;

namespace PlaywrightPractice.PracticeScripts;
public class irctcLocators : BaseClass
{

    [SetUp]
    public async Task setup()
    {
        await StartAsync();
        await _page.GotoAsync("https://www.irctc.co.in/nget/train-search");
    }

    [TearDown]
    public async Task tearDown()
    {
        await StopAsync();
    }


    // [Test, Category("IRCTC Locators")]  
    // public void Locators


}