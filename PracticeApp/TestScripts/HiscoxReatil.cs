
namespace PracticeApp.TestScripts;

public class HiscoxReatil : BaseClass
{
    [SetUp]
    public async Task setup()
    {
        await StartAsync(false);
        await _page.GotoAsync("https://www.hiscox.com/small-business-insurance/professional-business-insurance/retail-insurance");
    }

    [TearDown]
    public async Task tearDown()
    {
        await StopAsync();
    }


    [Test, Category("Print the all review comments")]
    public async Task PrintAllReviewComments()
    {
        var elm = await  _page.Locator("//div/h2[text()='Hiscox Customer Reviews']/ancestor::div[contains(@class,'grid-container')]/following-sibling::div[1]//p").AllAsync();
        var reviewers = await _page.Locator("//div/h2[text()='Hiscox Customer Reviews']/ancestor::div[contains(@class,'grid-container')]/following-sibling::div[1]//p/strong").AllAsync();
        foreach (var reviewer in reviewers)
        {
            string user = await reviewer.InnerTextAsync();
            string review = await reviewer.Locator("../following-sibling::p[1]").InnerTextAsync();

            Console.WriteLine($"User: {user}");
            Console.WriteLine($"Review: {review}");
            
        }



    }

}