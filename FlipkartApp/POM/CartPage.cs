using System.Threading.Tasks;
using Microsoft.Playwright;

namespace FlipkartApp.POM;
public class CartPage
{
    private readonly IPage _page;
    public CartPage(IPage page) => _page = page;

    public async Task<bool> IsProductInCart(string expectedProductName)
    {
        var product = await _page.Locator("a.T2CNXf").InnerTextAsync();
        return product.Contains(expectedProductName);
    }
}
