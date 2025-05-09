using System.Threading.Tasks;
using Microsoft.Playwright;

namespace FlipkartApp.POM;
public class SearchResultsPage
{
    private readonly IPage _page;
    public SearchResultsPage(IPage page) => _page = page;

    public async Task ClickOnFirstProduct()
    {
        var firstProduct = _page.Locator("div.tUxRFH>a");
        await firstProduct.Nth(1).ClickAsync();
        await _page.WaitForTimeoutAsync(2000); // Wait for tab
    }
}
